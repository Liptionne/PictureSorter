namespace PictureSorterC_
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fichierToolStripMenuItem = new ToolStripMenuItem();
            editionToolStripMenuItem = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            LabelFolderName = new Label();
            LabelPathToFolder = new Label();
            ButtonChooseFolder = new Button();
            LabelChoixModeDeplacement = new Label();
            ComboBoxChoixModeDeplacement = new ComboBox();
            LabelTargetFolder = new Label();
            LabelPathToTargetFolder = new Label();
            ButtonChooseTargetFolder = new Button();
            LabelAdditionalFolder = new Label();
            LabelAdditionnalFolderPath = new Label();
            ButtonChooseAdditionnalFolder = new Button();
            CheckBoxSeparateFolders = new CheckBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fichierToolStripMenuItem, editionToolStripMenuItem, optionsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1315, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            fichierToolStripMenuItem.Size = new Size(66, 24);
            fichierToolStripMenuItem.Text = "Fichier";
            // 
            // editionToolStripMenuItem
            // 
            editionToolStripMenuItem.Name = "editionToolStripMenuItem";
            editionToolStripMenuItem.Size = new Size(70, 24);
            editionToolStripMenuItem.Text = "Edition";
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(75, 24);
            optionsToolStripMenuItem.Text = "Options";
            // 
            // LabelFolderName
            // 
            LabelFolderName.AutoSize = true;
            LabelFolderName.Location = new Point(13, 42);
            LabelFolderName.Name = "LabelFolderName";
            LabelFolderName.Size = new Size(121, 20);
            LabelFolderName.TabIndex = 1;
            LabelFolderName.Text = "Nom du dossier :";
            // 
            // LabelPathToFolder
            // 
            LabelPathToFolder.AutoSize = true;
            LabelPathToFolder.Location = new Point(152, 52);
            LabelPathToFolder.Name = "LabelPathToFolder";
            LabelPathToFolder.Size = new Size(0, 20);
            LabelPathToFolder.TabIndex = 2;
            // 
            // ButtonChooseFolder
            // 
            ButtonChooseFolder.Location = new Point(13, 75);
            ButtonChooseFolder.Name = "ButtonChooseFolder";
            ButtonChooseFolder.Size = new Size(237, 29);
            ButtonChooseFolder.TabIndex = 3;
            ButtonChooseFolder.Text = "Choisir mon dossier";
            ButtonChooseFolder.UseVisualStyleBackColor = true;
            // 
            // LabelChoixModeDeplacement
            // 
            LabelChoixModeDeplacement.AutoSize = true;
            LabelChoixModeDeplacement.Location = new Point(13, 124);
            LabelChoixModeDeplacement.Name = "LabelChoixModeDeplacement";
            LabelChoixModeDeplacement.Size = new Size(167, 20);
            LabelChoixModeDeplacement.TabIndex = 4;
            LabelChoixModeDeplacement.Text = "Mode de déplacement :";
            // 
            // ComboBoxChoixModeDeplacement
            // 
            ComboBoxChoixModeDeplacement.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxChoixModeDeplacement.FormattingEnabled = true;
            ComboBoxChoixModeDeplacement.Items.AddRange(new object[] { "Déplacer", "Copier", "Copier et déplacer" });
            ComboBoxChoixModeDeplacement.Location = new Point(184, 121);
            ComboBoxChoixModeDeplacement.Name = "ComboBoxChoixModeDeplacement";
            ComboBoxChoixModeDeplacement.Size = new Size(151, 28);
            ComboBoxChoixModeDeplacement.TabIndex = 5;
            // 
            // LabelTargetFolder
            // 
            LabelTargetFolder.AutoSize = true;
            LabelTargetFolder.Location = new Point(13, 158);
            LabelTargetFolder.Name = "LabelTargetFolder";
            LabelTargetFolder.Size = new Size(148, 20);
            LabelTargetFolder.TabIndex = 6;
            LabelTargetFolder.Text = "Dossier où déplacer :";
            // 
            // LabelPathToTargetFolder
            // 
            LabelPathToTargetFolder.AutoSize = true;
            LabelPathToTargetFolder.Location = new Point(167, 158);
            LabelPathToTargetFolder.Name = "LabelPathToTargetFolder";
            LabelPathToTargetFolder.Size = new Size(0, 20);
            LabelPathToTargetFolder.TabIndex = 7;
            // 
            // ButtonChooseTargetFolder
            // 
            ButtonChooseTargetFolder.Location = new Point(13, 193);
            ButtonChooseTargetFolder.Name = "ButtonChooseTargetFolder";
            ButtonChooseTargetFolder.Size = new Size(237, 29);
            ButtonChooseTargetFolder.TabIndex = 8;
            ButtonChooseTargetFolder.Text = "Choisir le dossier où déplacer";
            ButtonChooseTargetFolder.UseVisualStyleBackColor = true;
            // 
            // LabelAdditionalFolder
            // 
            LabelAdditionalFolder.AutoSize = true;
            LabelAdditionalFolder.Location = new Point(13, 240);
            LabelAdditionalFolder.Name = "LabelAdditionalFolder";
            LabelAdditionalFolder.Size = new Size(247, 20);
            LabelAdditionalFolder.TabIndex = 9;
            LabelAdditionalFolder.Text = "Dossier supplémentaire de recopie :";
            // 
            // LabelAdditionnalFolderPath
            // 
            LabelAdditionnalFolderPath.AutoSize = true;
            LabelAdditionnalFolderPath.Location = new Point(266, 240);
            LabelAdditionnalFolderPath.Name = "LabelAdditionnalFolderPath";
            LabelAdditionnalFolderPath.Size = new Size(0, 20);
            LabelAdditionnalFolderPath.TabIndex = 10;
            // 
            // ButtonChooseAdditionnalFolder
            // 
            ButtonChooseAdditionnalFolder.Location = new Point(13, 274);
            ButtonChooseAdditionnalFolder.Name = "ButtonChooseAdditionnalFolder";
            ButtonChooseAdditionnalFolder.Size = new Size(237, 29);
            ButtonChooseAdditionnalFolder.TabIndex = 11;
            ButtonChooseAdditionnalFolder.Text = "Choisir dossier supplémentaire";
            ButtonChooseAdditionnalFolder.UseVisualStyleBackColor = true;
            // 
            // CheckBoxSeparateFolders
            // 
            CheckBoxSeparateFolders.AutoSize = true;
            CheckBoxSeparateFolders.Location = new Point(13, 320);
            CheckBoxSeparateFolders.Name = "CheckBoxSeparateFolders";
            CheckBoxSeparateFolders.Size = new Size(272, 24);
            CheckBoxSeparateFolders.TabIndex = 12;
            CheckBoxSeparateFolders.Text = "Séparer en 2 dossiers (RAW et JPG) ?";
            CheckBoxSeparateFolders.UseVisualStyleBackColor = true;
            CheckBoxSeparateFolders.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1315, 727);
            Controls.Add(CheckBoxSeparateFolders);
            Controls.Add(ButtonChooseAdditionnalFolder);
            Controls.Add(LabelAdditionnalFolderPath);
            Controls.Add(LabelAdditionalFolder);
            Controls.Add(ButtonChooseTargetFolder);
            Controls.Add(LabelPathToTargetFolder);
            Controls.Add(LabelTargetFolder);
            Controls.Add(ComboBoxChoixModeDeplacement);
            Controls.Add(LabelChoixModeDeplacement);
            Controls.Add(ButtonChooseFolder);
            Controls.Add(LabelPathToFolder);
            Controls.Add(LabelFolderName);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fichierToolStripMenuItem;
        private ToolStripMenuItem editionToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private Label LabelFolderName;
        private Label LabelPathToFolder;
        private Button ButtonChooseFolder;
        private Label LabelChoixModeDeplacement;
        private ComboBox ComboBoxChoixModeDeplacement;
        private Label LabelTargetFolder;
        private Label LabelPathToTargetFolder;
        private Button ButtonChooseTargetFolder;
        private Label LabelAdditionalFolder;
        private Label LabelAdditionnalFolderPath;
        private Button ButtonChooseAdditionnalFolder;
        private CheckBox CheckBoxSeparateFolders;
    }
}