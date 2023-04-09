using System.Windows.Forms;

namespace PictureSorterC_
{
    public partial class Form1 : Form
    {
        string SDFolder = "";
        string WorkingFolder = "";
        string AdditionnalCopyFolder = "";
        public Form1()
        {
            InitializeComponent();
            LabelAdditionnalFolderPath.Text = string.Empty;
            LabelPathToTargetFolder.Text = string.Empty;
            LabelPathToFolder.Text = string.Empty;
            ButtonStartImport.Enabled = false;
        }


        public string SelectFolder()
        {
            string folderPath = "";

            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    folderPath = folderBrowserDialog.SelectedPath;
                }
            }

            return folderPath;
        }

        public void MoveFiles()
        {
            if (!Directory.Exists(SDFolder))
            {
                throw new DirectoryNotFoundException($"Le dossier source {SDFolder} n'existe pas.");
            }

            if (!Directory.Exists(WorkingFolder))
            {
                Directory.CreateDirectory(WorkingFolder);
            }

            DirectoryInfo sourceDir = new DirectoryInfo(SDFolder);
            FileInfo[] files = sourceDir.GetFiles();
            if (ComboBoxChoixModeDeplacement.SelectedItem.ToString() == "Déplacer")
            {
                foreach (FileInfo file in files)
                {
                    string targetFilePath = Path.Combine(WorkingFolder, file.Name);
                    file.MoveTo(targetFilePath);
                }
            }

            if (ComboBoxChoixModeDeplacement.SelectedItem.ToString() == "Copier")
            {
                foreach (FileInfo file in files)
                {
                    string targetFilePath = Path.Combine(WorkingFolder, file.Name);
                    file.CopyTo(targetFilePath);
                }
            }

            if (ComboBoxChoixModeDeplacement.SelectedItem.ToString() == "Copier et déplacer")
            {
                if(AdditionnalCopyFolder == "")
                {
                    MessageBox.Show("Vous n'avez pas selectionné de dossier où copier vos fichiers");
                    return;
                }
                foreach (FileInfo file in files)
                {
                    string targetFilePath = Path.Combine(WorkingFolder, file.Name);
                    file.MoveTo(targetFilePath);
                    string targetCopyPath = Path.Combine(AdditionnalCopyFolder, file.Name);
                    file.CopyTo(targetCopyPath);
                }
            }



            MessageBox.Show("Le déplacement des fichiers est terminé.");
        }

        private void CheckIfImportButtonIsEnabled()
        {
            if (SDFolder != "" && WorkingFolder != "" && ComboBoxChoixModeDeplacement.SelectedIndex >= 0)
            {
                ButtonStartImport.Enabled = true;
            }
        }



        private void ButtonChooseFolder_Click(object sender, EventArgs e)
        {
            SDFolder = SelectFolder();
            LabelPathToFolder.Text = Path.GetFileName(SDFolder);

            CheckIfImportButtonIsEnabled();
        }

        private void ButtonChooseTargetFolder_Click(object sender, EventArgs e)
        {
            WorkingFolder = SelectFolder();
            LabelPathToTargetFolder.Text = Path.GetFileName(WorkingFolder);

            CheckIfImportButtonIsEnabled();


        }

        private void ButtonChooseAdditionnalFolder_Click(object sender, EventArgs e)
        {
            AdditionnalCopyFolder = SelectFolder();
            LabelAdditionnalFolderPath.Text = Path.GetFileName(AdditionnalCopyFolder);
        }

        private void ButtonStartImport_Click(object sender, EventArgs e)
        {
            MoveFiles();
        }

        private void ComboBoxChoixModeDeplacement_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckIfImportButtonIsEnabled();
        }
    }
}