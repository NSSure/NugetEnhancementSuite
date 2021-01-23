using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NupkgManager
{
    public partial class MainPage : Form
    {
        static string GetAssemblyLocalPathFrom(Type type)
        {
            string codebase = type.Assembly.CodeBase;
            var uri = new Uri(codebase, UriKind.Absolute);
            return uri.LocalPath;
        }

        Process commandPrompt;
        string nugetExe = GetAssemblyLocalPathFrom(typeof(NupkgManagerPackage))
            .Substring(0, GetAssemblyLocalPathFrom(typeof(NupkgManagerPackage))
            .LastIndexOf("\\") + 1).Replace("\\", "/") + "nuget.exe";
        string userProfile = Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\source\repos\");
        private StringBuilder outputBuilder;
        System.Timers.Timer cmdBuildTimer = new System.Timers.Timer(2000);
        System.Timers.Timer cmdPushTimer = new System.Timers.Timer(5000);
        ProgressDialogForm progressDialogForm;

        public MainPage()
        {
            InitializeComponent();
            progressDialogForm = new ProgressDialogForm("Searching ...");
            commandPromptOutputTextBox.ReadOnly = true;

            cmdBuildTimer.Elapsed += CmdBuildTimer_Elapsed;
            cmdBuildTimer.AutoReset = false;
            cmdPushTimer.Elapsed += CmdPushTimer_Elapsed;
            cmdPushTimer.AutoReset = false;

            if (Properties.Settings.Default.DefaultSearchFolder == "")
            {
                packagesPathTextBox.Text = userProfile;
            }
            else
            {
                packagesPathTextBox.Text = Properties.Settings.Default.DefaultSearchFolder;
            }
        }

        private void CmdPushTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.DeletePushedPackages();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            progressDialogForm.UpdateMessage("Searching ...");
            progressDialogForm.Show(this);
            var nuspecFiles = await Task.Run(() => { return NuspecSearch(packagesPathTextBox.Text); });
            var nupkgFiles = await Task.Run(() => { return NupkgSearch(packagesPathTextBox.Text); });
            PopulateListBox(nuspecSearchResults, nuspecFiles);
            PopulateListBox(nupkgSearchResults, nupkgFiles);
            CloseProgressForm();
        }

        public void CloseProgressForm()
        {
            if (progressDialogForm.InvokeRequired)
            {
                Action a = new Action(CloseProgressForm);
                progressDialogForm.Invoke(a);
            }
            else
            {
                progressDialogForm.Hide();
            }
        }

        private void refreshSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetButtonsCheckboxShowProgressDialog(packagesPathTextBox.Text);
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Preferences().Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            ChooseFolder();
        }

        private void majorVersionTo0ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (majorVersionTo0ToolStripMenuItem.Checked)
            {
                majorCheckBox.Enabled
                    = majorCheckBox.Checked = false;
            }
            else majorCheckBox.Enabled = true;
        }

        private void minorVersionTo0ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (minorVersionTo0ToolStripMenuItem.Checked)
            {
                minorCheckBox.Enabled
                    = minorCheckBox.Checked = false;
            }
            else minorCheckBox.Enabled = true;
        }

        private void buildNumberTo0ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (buildNumberTo0ToolStripMenuItem.Checked)
            {
                buildNumberCheckBox.Enabled
                    = buildNumberCheckBox.Checked = false;
            }
            else buildNumberCheckBox.Enabled = true;
        }

        private void showHideCmdOutputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int caseSwitch = 2;
            if (ActiveForm.Width == 386) caseSwitch = 2;
            if (ActiveForm.Width == 742) caseSwitch = 1;

            switch (caseSwitch)
            {
                case 1:
                    ActiveForm.Size = new System.Drawing.Size(386, 556);
                    break;
                case 2:
                    ActiveForm.Size = new System.Drawing.Size(742, 556);
                    break;
                default:
                    ActiveForm.Size = new System.Drawing.Size(386, 556);
                    break;
            }
        }

        private int GetItemCount(CheckedListBox listBox, CheckState checkState)
        {
            var itemCount = listBox.CheckedItems.Count;
            if (checkState == CheckState.Checked)
                itemCount++;
            else
                itemCount--;

            return itemCount;
        }

        private void nuspecSearchResults_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var itemCount = GetItemCount(sender as CheckedListBox, e.NewValue);
            EnableToolStripMenuItem(majorVersionTo0ToolStripMenuItem, itemCount);
            EnableToolStripMenuItem(minorVersionTo0ToolStripMenuItem, itemCount);
            EnableToolStripMenuItem(buildNumberTo0ToolStripMenuItem, itemCount);
            EnableButton(buildPackagesButton, itemCount);
            EnableCheckBox(majorCheckBox, itemCount);
            EnableCheckBox(minorCheckBox, itemCount);
            EnableCheckBox(buildNumberCheckBox, itemCount);
        }

        private void nupkgSearchResults_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var itemCount = GetItemCount(sender as CheckedListBox, e.NewValue);
            EnableButton(pushPackagesButton, itemCount);
            EnableButton(deletePackagesButton, itemCount);
        }

        private void buildPackagesButton_Click(object sender, EventArgs e)
        {
            BuildPackages();
        }

        private void pushPackagesButton_Click(object sender, EventArgs e)
        {
            PushPackages();
        }

        private void deletePackagesButton_Click(object sender, EventArgs e)
        {
            DeletePushedPackages();
        }

        //private void CommandPromptBuild_OutputUpdated(object sender, EventArgs<string> e)
        //{
        //    cmdBuildTimer.Stop();
        //    cmdBuildTimer.Start();

        //    if (outputBuilder == null)
        //        outputBuilder = new StringBuilder();
        //        outputBuilder.AppendLine(e.Data);
        //        WriteTextSafe(outputBuilder.ToString());
        //}

        //private void CommandPromptPush_OutputUpdated(object sender, EventArgs<string> eventArgs)
        //{
        //    cmdPushTimer.Stop();
        //    cmdPushTimer.Start();

        //    if (outputBuilder == null)
        //        outputBuilder = new StringBuilder();
        //    outputBuilder.AppendLine(eventArgs.Data);
        //    try
        //    {
        //        WriteTextSafe(outputBuilder.ToString());
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show("An error occured while outputting command prompt: " + e, "Console Output Error",
        //                MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
            
        //}

        private delegate void SafeCallDelegate(string text);

        private void WriteTextSafe(string text)
        {
            if (commandPromptOutputTextBox.InvokeRequired)
            {
                var d = new SafeCallDelegate(WriteTextSafe);
                Invoke(d, new object[] { text });
            }
            else
            {
                commandPromptOutputTextBox.Text = text;
                commandPromptOutputTextBox.SelectionStart = commandPromptOutputTextBox.TextLength;
                commandPromptOutputTextBox.ScrollToCaret();
            }
        }

        private async void FinishedBuilding()
        {
            if (progressDialogForm.InvokeRequired)
            {
                Action a = FinishedBuilding;
                Invoke(a);
            }
            else
            {
                progressDialogForm.Hide();
                var nupkgFiles = await Task.Run(() => { return NupkgSearch(packagesPathTextBox.Text); });
                PopulateListBox(nupkgSearchResults, nupkgFiles);
            }
        }

        public void PopulateListBox(CheckedListBox whichListBox, string[] files)
        {
            whichListBox.Items.Clear();

            if (files.Count() != 0)
            {
                foreach (var file in files)
                {
                    int pos = file.LastIndexOf("\\") + 1;

                    whichListBox.Items.Add(new CheckedListBoxItem()
                    {
                        Text = file.Substring(pos, file.Length - pos),
                        Tag = file
                    });
                }
            }
        }

        public string[] NuspecSearch(string dirToSearch)
        {
            string[] nuspecFiles = { };

            try
            {
                nuspecFiles = Directory.GetFiles(dirToSearch, "*.nuspec", SearchOption.AllDirectories).Where(d => !d.Contains("packages")).ToArray();
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e);
            }

            return nuspecFiles;
        }

        public string[] NupkgSearch(string dirToSearch)
        {
            string[] nupkgFiles = { };

            try
            {
                nupkgFiles = Directory.GetFiles(dirToSearch, "*.nupkg", SearchOption.AllDirectories).Where(d => !d.Contains("packages")).ToArray();
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e);
            }

            return nupkgFiles;
        }

        public void ChooseFolder()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (Properties.Settings.Default.DefaultSearchFolder == "")
            {
                fbd.RootFolder = Environment.SpecialFolder.MyComputer;
                fbd.SelectedPath = userProfile;
            }
            else
            {
                fbd.SelectedPath = Properties.Settings.Default.DefaultSearchFolder;
            }

            fbd.Description = "Select packages folder:";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                packagesPathTextBox.Text = fbd.SelectedPath;
                ResetButtonsCheckboxShowProgressDialog(fbd.SelectedPath);
            }
        }

        private async void ResetButtonsCheckboxShowProgressDialog(string pathToSearch)
        {
            if (progressDialogForm.InvokeRequired)
            {
                Action a = FinishedBuilding;
                Invoke(a);
            }
            else
            {
                progressDialogForm.UpdateMessage("Searching ...");
                progressDialogForm.Show(this);
                var nuspecFiles = await Task.Run(() => { return NuspecSearch(packagesPathTextBox.Text); });
                var nupkgFiles = await Task.Run(() => { return NupkgSearch(packagesPathTextBox.Text); });
                PopulateListBox(nuspecSearchResults, nuspecFiles);
                PopulateListBox(nupkgSearchResults, nupkgFiles);
                CloseProgressForm();            
                buildPackagesButton.Enabled
                    = pushPackagesButton.Enabled
                    = deletePackagesButton.Enabled
                    = majorCheckBox.Enabled
                    = majorCheckBox.Checked
                    = minorCheckBox.Enabled
                    = minorCheckBox.Checked
                    = buildNumberCheckBox.Enabled
                    = buildNumberCheckBox.Checked
                    = majorVersionTo0ToolStripMenuItem.Checked
                    = majorVersionTo0ToolStripMenuItem.Enabled
                    = minorVersionTo0ToolStripMenuItem.Checked
                    = minorVersionTo0ToolStripMenuItem.Enabled
                    = buildNumberTo0ToolStripMenuItem.Checked
                    = buildNumberTo0ToolStripMenuItem.Enabled
                    = false;
            }
        }

        protected List<string> PackagesToBuild = new List<string>();

        public void BuildPackages()
        {
            progressDialogForm.UpdateMessage("Building ...");
            progressDialogForm.Show(this);
            
            foreach (CheckedListBoxItem file in nuspecSearchResults.CheckedItems)
            {
                PackagesToBuild.Add(file.Tag);
            }

            BuildNextPackage();
        }

        public async void BuildNextPackage()
        {
            if (!PackagesToBuild.Any())
            {
                Task finishedBuildingTask = Task.Factory.StartNew(() =>
                {
                    FinishedBuilding();
                });

                await finishedBuildingTask;
                return;
            }

            var path = PackagesToBuild.First();
            PackagesToBuild.Remove(path);

            IncrementVersionNumber(path);

            string fileNoExt = path.Substring(0, path.LastIndexOf(".") + 1).Replace("\\", "/");
            string outputDir = fileNoExt.Substring(0, fileNoExt.LastIndexOf("/") + 1) + "bin/Release";

            this.commandPrompt = new Process();

            ProcessStartInfo startInfo = new ProcessStartInfo();

            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = $"/C \"{nugetExe}\" pack \"{fileNoExt}csproj\" -Build -Prop Configuration=Release -OutputDirectory \"{outputDir}\" -IncludeReferencedProjects";

            this.commandPrompt.StartInfo = startInfo;

            this.commandPrompt.Start();

            //commandPrompt.OutputUpdated += CommandPromptBuild_OutputUpdated;
        }

        public void IncrementVersionNumber(string dirToNuspecFile)
        {
            string fileNoExt = dirToNuspecFile.Substring(0, dirToNuspecFile.LastIndexOf(".")).Replace("\\", "/");
            string assemblyInfoDir = fileNoExt.Substring(0, fileNoExt.LastIndexOf("/") + 1) + "Properties/";
            string assemblyInfoFile = File.ReadAllText(assemblyInfoDir + "AssemblyInfo.cs");
            int majorNumber;
            int minorNumber;
            int buildNumber;
            string betaInfo;
            string versionNumberReplaced;

            try
            {
                Regex rx = new Regex("AssemblyInformationalVersion");
                Match match = rx.Match(assemblyInfoFile);

                if (match.Value == "AssemblyInformationalVersion")
                {
                    Regex rx1 = new Regex(@"^[^//].*AssemblyInformationalVersion.\""(\d{0,2})\.(\d{0,2})\.(\d{0,2})(.{0,128})\""", RegexOptions.Multiline | RegexOptions.ECMAScript);
                    Match match1 = rx1.Match(assemblyInfoFile);

                    majorNumber = int.Parse(match1.Groups[1].Value);
                    minorNumber = int.Parse(match1.Groups[2].Value);
                    buildNumber = int.Parse(match1.Groups[3].Value);
                    betaInfo = match1.Groups[4].Value;

                    if (majorCheckBox.Checked) majorNumber++;
                    if (minorCheckBox.Checked) minorNumber++;
                    if (buildNumberCheckBox.Checked) buildNumber++;
                    if (majorVersionTo0ToolStripMenuItem.Checked) majorNumber = 0;
                    if (minorVersionTo0ToolStripMenuItem.Checked) minorNumber = 0;
                    if (buildNumberTo0ToolStripMenuItem.Checked) buildNumber = 0;

                    versionNumberReplaced = assemblyInfoFile.Replace($@"AssemblyInformationalVersion(""{match1.Groups[1].Value}.{match1.Groups[2].Value}.{match1.Groups[3].Value}{match1.Groups[4].Value}""", $@"AssemblyInformationalVersion(""{majorNumber}.{minorNumber}.{buildNumber}{betaInfo}""");
                    //versionNumberReplaced = Regex.Replace(assemblyInfoFile, rx1.ToString(), $@"[assembly: AssemblyInformationalVersion(""{majorNumber}.{minorNumber}.{buildNumber}{betaInfo}""");
                    File.WriteAllText(assemblyInfoDir + "AssemblyInfo.cs", versionNumberReplaced);
                }
                else
                {
                    Regex rx2 = new Regex(@"\""(\d{0,2})\.(\d{0,2})\.(\d{0,2})(.{0,128})\""", RegexOptions.Multiline);
                    Match match2 = rx2.Match(assemblyInfoFile);

                    majorNumber = int.Parse(match2.Groups[1].Value);
                    minorNumber = int.Parse(match2.Groups[2].Value);
                    buildNumber = int.Parse(match2.Groups[3].Value.Replace("*","0"));
                    betaInfo = match2.Groups[4].Value;

                    if (String.IsNullOrEmpty(match2.Groups[3].Value)) buildNumber = 0;

                    try
                    {
                        if (majorCheckBox.Checked) majorNumber++;
                        if (minorCheckBox.Checked) minorNumber++;
                        if (buildNumberCheckBox.Checked) buildNumber++;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Unrecognised version number in Assembly info: " + e, "Assembly Info Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                    if (majorVersionTo0ToolStripMenuItem.Checked) majorNumber = 0;
                    if (minorVersionTo0ToolStripMenuItem.Checked) minorNumber = 0;
                    if (buildNumberTo0ToolStripMenuItem.Checked) buildNumber = 0;

                    versionNumberReplaced = Regex.Replace(assemblyInfoFile, rx2.ToString(), $@"""{majorNumber}.{minorNumber}.{buildNumber}{betaInfo}""");
                    File.WriteAllText(assemblyInfoDir + "AssemblyInfo.cs", versionNumberReplaced);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("An error occured while attempting to build: " + e, "Build Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void PushPackages()
        {
            string key = string.Empty;
            string packageServer = string.Empty;
            bool pushNotCancelled = false;

            try
            {
                if (Properties.Settings.Default.ApiKey[0] == string.Empty || Properties.Settings.Default.NugetRepositories[0] == string.Empty)
                {
                    new MissingInfoDialog().Show();
                    pushNotCancelled = false;
                }
                else
                {
                    pushNotCancelled = true;
                    key = Properties.Settings.Default.ApiKey[0];
                    packageServer = Properties.Settings.Default.NugetRepositories[0];
                }
            }
            catch (Exception)
            {
                new MissingInfoDialog().Show();
                pushNotCancelled = false;
            }
            
            

            if (pushNotCancelled)
            {
                progressDialogForm.UpdateMessage("Pushing to Server ...");
                progressDialogForm.Show(this);
                foreach (CheckedListBoxItem file in nupkgSearchResults.CheckedItems)
                {
                    //commandPrompt = new CommandPrompt(true);

                    //string packagePathNoBackslash = file.Tag.Replace("\\", "/");
                    //string pushPackageUpdateCmd = $"\"{nugetExe}\" push \"{packagePathNoBackslash}\" {key} -Source {packageServer}";

                    //commandPrompt.ExecuteCommand(pushPackageUpdateCmd);
                    //commandPrompt.ExecuteCommand(key);
                    //commandPrompt.ExecuteCommand("");

                    //commandPrompt.OutputUpdated += CommandPromptPush_OutputUpdated;
                }
            }
        }

        private void DeletePushedPackages()
        {
            foreach (CheckedListBoxItem file in nupkgSearchResults.CheckedItems)
            {
                try
                {
                    File.Delete(file.Tag);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error while removing pushed packages: " + e);
                }
            }

            ResetButtonsCheckboxShowProgressDialog(packagesPathTextBox.Text);
            NupkgSearch(packagesPathTextBox.Text);
        }

        public void EnableButton(Button whichButton, int fileCount)
        {
            if (fileCount != 0)
            {
                whichButton.Enabled = true;
            }
            else
            {
                whichButton.Enabled = false;
            }
        }

        public void EnableCheckBox(CheckBox whichCheckBox, int fileCount)
        {
            if (fileCount != 0)
            {
                whichCheckBox.Enabled = true;
            }
            else
            {
                whichCheckBox.Enabled = false;
            }
        }

        public void EnableToolStripMenuItem(ToolStripMenuItem whichToolStripMenuItem, int fileCount)
        {
            if (fileCount != 0)
            {
                whichToolStripMenuItem.Enabled = true;
            }
            else
            {
                whichToolStripMenuItem.Enabled
                    = whichToolStripMenuItem.Checked
                    = majorCheckBox.Checked
                    = minorCheckBox.Checked
                    = buildNumberCheckBox.Checked
                    = false;
            }
        }

        private void CmdBuildTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.BuildNextPackage();
        }
    }
}
