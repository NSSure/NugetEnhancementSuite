namespace NupkgManager
{
    partial class MainPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.pushPackagesButton = new System.Windows.Forms.Button();
            this.nuspecSearchResults = new System.Windows.Forms.CheckedListBox();
            this.buildPackagesButton = new System.Windows.Forms.Button();
            this.nupkgSearchResults = new System.Windows.Forms.CheckedListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetCheckedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.majorVersionTo0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minorVersionTo0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildNumberTo0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showHideCmdOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.packagesPathTextBox = new System.Windows.Forms.TextBox();
            this.majorCheckBox = new System.Windows.Forms.CheckBox();
            this.minorCheckBox = new System.Windows.Forms.CheckBox();
            this.buildNumberCheckBox = new System.Windows.Forms.CheckBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.commandPromptOutputTextBox = new System.Windows.Forms.TextBox();
            this.deletePackagesButton = new System.Windows.Forms.Button();
            this.preReleaseCheckbox = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pushPackagesButton
            // 
            this.pushPackagesButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.pushPackagesButton.Enabled = false;
            this.pushPackagesButton.Location = new System.Drawing.Point(4, 734);
            this.pushPackagesButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pushPackagesButton.Name = "pushPackagesButton";
            this.pushPackagesButton.Size = new System.Drawing.Size(116, 35);
            this.pushPackagesButton.TabIndex = 3;
            this.pushPackagesButton.Text = "Push";
            this.pushPackagesButton.UseVisualStyleBackColor = true;
            this.pushPackagesButton.Click += new System.EventHandler(this.pushPackagesButton_Click);
            // 
            // nuspecSearchResults
            // 
            this.nuspecSearchResults.CheckOnClick = true;
            this.tableLayoutPanel1.SetColumnSpan(this.nuspecSearchResults, 5);
            this.nuspecSearchResults.FormattingEnabled = true;
            this.nuspecSearchResults.HorizontalScrollbar = true;
            this.nuspecSearchResults.Location = new System.Drawing.Point(4, 86);
            this.nuspecSearchResults.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nuspecSearchResults.Name = "nuspecSearchResults";
            this.nuspecSearchResults.Size = new System.Drawing.Size(534, 303);
            this.nuspecSearchResults.TabIndex = 5;
            this.nuspecSearchResults.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.nuspecSearchResults_ItemCheck);
            // 
            // buildPackagesButton
            // 
            this.buildPackagesButton.Enabled = false;
            this.buildPackagesButton.Location = new System.Drawing.Point(4, 399);
            this.buildPackagesButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buildPackagesButton.Name = "buildPackagesButton";
            this.buildPackagesButton.Size = new System.Drawing.Size(112, 35);
            this.buildPackagesButton.TabIndex = 6;
            this.buildPackagesButton.Text = "Build";
            this.buildPackagesButton.UseVisualStyleBackColor = true;
            this.buildPackagesButton.Click += new System.EventHandler(this.buildPackagesButton_Click);
            // 
            // nupkgSearchResults
            // 
            this.nupkgSearchResults.CheckOnClick = true;
            this.tableLayoutPanel1.SetColumnSpan(this.nupkgSearchResults, 5);
            this.nupkgSearchResults.FormattingEnabled = true;
            this.nupkgSearchResults.HorizontalScrollbar = true;
            this.nupkgSearchResults.Location = new System.Drawing.Point(4, 444);
            this.nupkgSearchResults.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nupkgSearchResults.Name = "nupkgSearchResults";
            this.nupkgSearchResults.Size = new System.Drawing.Size(534, 280);
            this.nupkgSearchResults.TabIndex = 7;
            this.nupkgSearchResults.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.nupkgSearchResults_ItemCheck);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.SetColumnSpan(this.menuStrip1, 6);
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1082, 36);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem,
            this.resetCheckedToolStripMenuItem,
            this.refreshSearchToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 30);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(242, 34);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // resetCheckedToolStripMenuItem
            // 
            this.resetCheckedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.majorVersionTo0ToolStripMenuItem,
            this.minorVersionTo0ToolStripMenuItem,
            this.buildNumberTo0ToolStripMenuItem});
            this.resetCheckedToolStripMenuItem.Name = "resetCheckedToolStripMenuItem";
            this.resetCheckedToolStripMenuItem.Size = new System.Drawing.Size(242, 34);
            this.resetCheckedToolStripMenuItem.Text = "Reset checked ...";
            // 
            // majorVersionTo0ToolStripMenuItem
            // 
            this.majorVersionTo0ToolStripMenuItem.CheckOnClick = true;
            this.majorVersionTo0ToolStripMenuItem.Enabled = false;
            this.majorVersionTo0ToolStripMenuItem.Name = "majorVersionTo0ToolStripMenuItem";
            this.majorVersionTo0ToolStripMenuItem.Size = new System.Drawing.Size(260, 34);
            this.majorVersionTo0ToolStripMenuItem.Text = "Major version to 0";
            this.majorVersionTo0ToolStripMenuItem.Click += new System.EventHandler(this.majorVersionTo0ToolStripMenuItem_Click);
            // 
            // minorVersionTo0ToolStripMenuItem
            // 
            this.minorVersionTo0ToolStripMenuItem.CheckOnClick = true;
            this.minorVersionTo0ToolStripMenuItem.Enabled = false;
            this.minorVersionTo0ToolStripMenuItem.Name = "minorVersionTo0ToolStripMenuItem";
            this.minorVersionTo0ToolStripMenuItem.Size = new System.Drawing.Size(260, 34);
            this.minorVersionTo0ToolStripMenuItem.Text = "Minor version to 0";
            this.minorVersionTo0ToolStripMenuItem.Click += new System.EventHandler(this.minorVersionTo0ToolStripMenuItem_Click);
            // 
            // buildNumberTo0ToolStripMenuItem
            // 
            this.buildNumberTo0ToolStripMenuItem.CheckOnClick = true;
            this.buildNumberTo0ToolStripMenuItem.Enabled = false;
            this.buildNumberTo0ToolStripMenuItem.Name = "buildNumberTo0ToolStripMenuItem";
            this.buildNumberTo0ToolStripMenuItem.Size = new System.Drawing.Size(260, 34);
            this.buildNumberTo0ToolStripMenuItem.Text = "Build number to 0";
            this.buildNumberTo0ToolStripMenuItem.Click += new System.EventHandler(this.buildNumberTo0ToolStripMenuItem_Click);
            // 
            // refreshSearchToolStripMenuItem
            // 
            this.refreshSearchToolStripMenuItem.Name = "refreshSearchToolStripMenuItem";
            this.refreshSearchToolStripMenuItem.Size = new System.Drawing.Size(242, 34);
            this.refreshSearchToolStripMenuItem.Text = "Refresh search";
            this.refreshSearchToolStripMenuItem.Click += new System.EventHandler(this.refreshSearchToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(239, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(242, 34);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showHideCmdOutputToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(65, 30);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // showHideCmdOutputToolStripMenuItem
            // 
            this.showHideCmdOutputToolStripMenuItem.Name = "showHideCmdOutputToolStripMenuItem";
            this.showHideCmdOutputToolStripMenuItem.Size = new System.Drawing.Size(301, 34);
            this.showHideCmdOutputToolStripMenuItem.Text = "Show/Hide cmd output";
            this.showHideCmdOutputToolStripMenuItem.Click += new System.EventHandler(this.showHideCmdOutputToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 532F));
            this.tableLayoutPanel1.Controls.Add(this.pushPackagesButton, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.nupkgSearchResults, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.packagesPathTextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buildPackagesButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.nuspecSearchResults, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.browseButton, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.commandPromptOutputTextBox, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.deletePackagesButton, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.majorCheckBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.minorCheckBox, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.buildNumberCheckBox, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.preReleaseCheckbox, 4, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(549, 789);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // packagesPathTextBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.packagesPathTextBox, 3);
            this.packagesPathTextBox.Enabled = false;
            this.packagesPathTextBox.Location = new System.Drawing.Point(4, 41);
            this.packagesPathTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.packagesPathTextBox.Name = "packagesPathTextBox";
            this.packagesPathTextBox.Size = new System.Drawing.Size(319, 26);
            this.packagesPathTextBox.TabIndex = 4;
            // 
            // majorCheckBox
            // 
            this.majorCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.majorCheckBox.AutoSize = true;
            this.majorCheckBox.Enabled = false;
            this.majorCheckBox.Location = new System.Drawing.Point(128, 404);
            this.majorCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.majorCheckBox.Name = "majorCheckBox";
            this.majorCheckBox.Size = new System.Drawing.Size(74, 24);
            this.majorCheckBox.TabIndex = 10;
            this.majorCheckBox.Text = "Major";
            this.majorCheckBox.UseVisualStyleBackColor = true;
            // 
            // minorCheckBox
            // 
            this.minorCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.minorCheckBox.AutoSize = true;
            this.minorCheckBox.Enabled = false;
            this.minorCheckBox.Location = new System.Drawing.Point(239, 404);
            this.minorCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.minorCheckBox.Name = "minorCheckBox";
            this.minorCheckBox.Size = new System.Drawing.Size(74, 24);
            this.minorCheckBox.TabIndex = 11;
            this.minorCheckBox.Text = "Minor";
            this.minorCheckBox.UseVisualStyleBackColor = true;
            // 
            // buildNumberCheckBox
            // 
            this.buildNumberCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buildNumberCheckBox.AutoSize = true;
            this.buildNumberCheckBox.Enabled = false;
            this.buildNumberCheckBox.Location = new System.Drawing.Point(333, 404);
            this.buildNumberCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buildNumberCheckBox.Name = "buildNumberCheckBox";
            this.buildNumberCheckBox.Size = new System.Drawing.Size(85, 24);
            this.buildNumberCheckBox.TabIndex = 12;
            this.buildNumberCheckBox.Text = "Build no.";
            this.buildNumberCheckBox.UseVisualStyleBackColor = true;
            // 
            // browseButton
            // 
            this.browseButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tableLayoutPanel1.SetColumnSpan(this.browseButton, 2);
            this.browseButton.Location = new System.Drawing.Point(434, 41);
            this.browseButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(112, 35);
            this.browseButton.TabIndex = 0;
            this.browseButton.Text = "Browse ...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // commandPromptOutputTextBox
            // 
            this.commandPromptOutputTextBox.BackColor = System.Drawing.Color.Black;
            this.commandPromptOutputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandPromptOutputTextBox.Font = new System.Drawing.Font("Consolas", 10F);
            this.commandPromptOutputTextBox.ForeColor = System.Drawing.Color.Lime;
            this.commandPromptOutputTextBox.Location = new System.Drawing.Point(554, 41);
            this.commandPromptOutputTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.commandPromptOutputTextBox.Multiline = true;
            this.commandPromptOutputTextBox.Name = "commandPromptOutputTextBox";
            this.tableLayoutPanel1.SetRowSpan(this.commandPromptOutputTextBox, 5);
            this.commandPromptOutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.commandPromptOutputTextBox.Size = new System.Drawing.Size(524, 813);
            this.commandPromptOutputTextBox.TabIndex = 14;
            // 
            // deletePackagesButton
            // 
            this.deletePackagesButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.deletePackagesButton.Enabled = false;
            this.deletePackagesButton.Location = new System.Drawing.Point(426, 734);
            this.deletePackagesButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deletePackagesButton.Name = "deletePackagesButton";
            this.deletePackagesButton.Size = new System.Drawing.Size(120, 35);
            this.deletePackagesButton.TabIndex = 15;
            this.deletePackagesButton.Text = "Delete";
            this.deletePackagesButton.UseVisualStyleBackColor = true;
            this.deletePackagesButton.Click += new System.EventHandler(this.deletePackagesButton_Click);
            // 
            // preReleaseCheckbox
            // 
            this.preReleaseCheckbox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.preReleaseCheckbox.AutoSize = true;
            this.preReleaseCheckbox.Enabled = false;
            this.preReleaseCheckbox.Location = new System.Drawing.Point(426, 404);
            this.preReleaseCheckbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.preReleaseCheckbox.Name = "preReleaseCheckbox";
            this.preReleaseCheckbox.Size = new System.Drawing.Size(116, 24);
            this.preReleaseCheckbox.TabIndex = 16;
            this.preReleaseCheckbox.Text = "Pre-release";
            this.preReleaseCheckbox.UseVisualStyleBackColor = true;
            // 
            // MainPage
            // 
            this.AcceptButton = this.buildPackagesButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 789);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainPage";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Nupkg Manager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button pushPackagesButton;
        private System.Windows.Forms.CheckedListBox nuspecSearchResults;
        private System.Windows.Forms.Button buildPackagesButton;
        private System.Windows.Forms.CheckedListBox nupkgSearchResults;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem refreshSearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.CheckBox majorCheckBox;
        private System.Windows.Forms.CheckBox minorCheckBox;
        private System.Windows.Forms.CheckBox buildNumberCheckBox;
        private System.Windows.Forms.TextBox packagesPathTextBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.ToolStripMenuItem resetCheckedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem majorVersionTo0ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minorVersionTo0ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildNumberTo0ToolStripMenuItem;
        private System.Windows.Forms.TextBox commandPromptOutputTextBox;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showHideCmdOutputToolStripMenuItem;
        private System.Windows.Forms.Button deletePackagesButton;
        private System.Windows.Forms.CheckBox preReleaseCheckbox;
    }
}

