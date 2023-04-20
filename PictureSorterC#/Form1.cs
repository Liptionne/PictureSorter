using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;

namespace PictureSorterC_
{
    public partial class Form1 : Form
    {
        string SDFolder = "";
        string WorkingFolder = "";
        string AdditionnalCopyFolder = "";

        bool SeparateFoldersByFormat = false;

        List<string> extensionsRaw;
        List<string> extensionsImage;

        int IndexOfSelectedImage = 0;
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;

            LabelAdditionnalFolderPath.Text = string.Empty;
            LabelPathToTargetFolder.Text = string.Empty;
            LabelPathToFolder.Text = string.Empty;
            ButtonStartImport.Enabled = false;
            extensionsRaw = new List<string> { ".NEF", ".CR2", ".ARW", ".ORF", ".RW2", ".DNG" };
            extensionsImage = new List<string> { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff" };

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

        private Size GetImageDisplaySize(Image image, Size maxSize)
        {
            double widthRatio = (double)maxSize.Width / image.Width;
            double heightRatio = (double)maxSize.Height / image.Height;
            double ratio = Math.Min(widthRatio, heightRatio);

            int displayWidth = (int)(image.Width * ratio);
            int displayHeight = (int)(image.Height * ratio);

            return new Size(displayWidth, displayHeight);
        }

        public void LoadDataGridViewImages(string folder)
        {

            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(100, 100);
            listView1.View = View.LargeIcon;
            imageList.ColorDepth = ColorDepth.Depth32Bit;

            double POURCENTAGE_IMAGE = 0.03;

            int maxSize = 0;
            int maxSizeReduite = 0;
            string[] fileNames = Directory.GetFiles(folder);
            foreach (string fileName in fileNames)
            {
                Image image = Image.FromFile(fileName);
                maxSize = Math.Max(image.Width, image.Height);
                maxSizeReduite = Convert.ToInt32(maxSize * POURCENTAGE_IMAGE);
                imageList.Images.Add(image.GetThumbnailImage(maxSizeReduite, maxSizeReduite, null, IntPtr.Zero));
                image.Dispose();
                ListViewItem item = new ListViewItem(fileName, imageList.Images.Count - 1);
                listView1.Items.Add(item);
            }

            imageList.ImageSize = new Size(maxSizeReduite, maxSizeReduite);

            listView1.LargeImageList = imageList;
            // Afficher les images dans le ListView


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

            string cr2Folder = Path.Combine(WorkingFolder, "RAW");
            string jpgFolder = Path.Combine(WorkingFolder, "JPG");



            switch (ComboBoxChoixModeDeplacement.SelectedItem.ToString())
            {
                case "Déplacer":
                    if (CheckBoxSeparateFolders.Checked)
                    {
                        // Créer les dossiers CR2 et JPG si ils n'existent pas
                        Directory.CreateDirectory(cr2Folder);
                        Directory.CreateDirectory(jpgFolder);

                        foreach (FileInfo fileInfo in files)
                        {
                            string extension = fileInfo.Extension;

                            // Si l'extension est .CR2, déplacer le fichier dans le dossier CR2
                            if (extensionsRaw.Contains(extension))
                            {
                                string targetFilePath = Path.Combine(cr2Folder, fileInfo.Name);
                                fileInfo.MoveTo(targetFilePath);
                            }

                            // Si l'extension est .JPG, déplacer le fichier dans le dossier JPG
                            else if (extensionsImage.Contains(extension))
                            {
                                string targetFilePath = Path.Combine(jpgFolder, fileInfo.Name);
                                fileInfo.MoveTo(targetFilePath);
                            }
                        }
                    }

                    else
                    {
                        foreach (FileInfo file in files)
                        {
                            string targetFilePath = Path.Combine(WorkingFolder, file.Name);
                            file.MoveTo(targetFilePath);
                        }
                    }

                    break;

                case "Copier":

                    if (CheckBoxSeparateFolders.Checked)
                    {
                        // Créer les dossiers CR2 et JPG si ils n'existent pas
                        Directory.CreateDirectory(cr2Folder);
                        Directory.CreateDirectory(jpgFolder);

                        foreach (FileInfo fileInfo in files)
                        {
                            string extension = fileInfo.Extension;

                            // Si l'extension est .CR2, déplacer le fichier dans le dossier CR2
                            if (extensionsRaw.Contains(extension))
                            {
                                string targetFilePath = Path.Combine(cr2Folder, fileInfo.Name);
                                fileInfo.CopyTo(targetFilePath);
                            }

                            // Si l'extension est .JPG, déplacer le fichier dans le dossier JPG
                            else if (extensionsImage.Contains(extension))
                            {
                                string targetFilePath = Path.Combine(jpgFolder, fileInfo.Name);
                                fileInfo.CopyTo(targetFilePath);
                            }
                        }
                    }

                    else
                    {
                        foreach (FileInfo file in files)
                        {
                            string targetFilePath = Path.Combine(WorkingFolder, file.Name);
                            file.CopyTo(targetFilePath);
                        }
                    }

                    break;

                case "Copier et déplacer":



                    if (AdditionnalCopyFolder == "")
                    {
                        MessageBox.Show("Vous n'avez pas selectionné de dossier où copier vos fichiers");
                        return;
                    }

                    string cr2FolderCopy = Path.Combine(AdditionnalCopyFolder, "RAW");
                    string jpgFolderCopy = Path.Combine(AdditionnalCopyFolder, "JPG");
                    if (CheckBoxSeparateFolders.Checked)
                    {
                        // Créer les dossiers CR2 et JPG si ils n'existent pas
                        Directory.CreateDirectory(cr2Folder);
                        Directory.CreateDirectory(jpgFolder);
                        Directory.CreateDirectory(cr2FolderCopy);
                        Directory.CreateDirectory(jpgFolderCopy);

                        foreach (FileInfo fileInfo in files)
                        {
                            string extension = fileInfo.Extension;

                            // Si l'extension est .CR2, déplacer le fichier dans le dossier CR2
                            if (extensionsRaw.Contains(extension))
                            {
                                string targetFilePath = Path.Combine(cr2Folder, fileInfo.Name);
                                fileInfo.MoveTo(targetFilePath);
                                string targetCopypath = Path.Combine(cr2FolderCopy, fileInfo.Name);
                                fileInfo.CopyTo(targetCopypath);
                            }

                            // Si l'extension est .JPG, déplacer le fichier dans le dossier JPG
                            else if (extensionsImage.Contains(extension))
                            {
                                string targetFilePath = Path.Combine(jpgFolder, fileInfo.Name);
                                fileInfo.MoveTo(targetFilePath);
                                string targetCopypath = Path.Combine(jpgFolderCopy, fileInfo.Name);
                                fileInfo.CopyTo(targetCopypath);
                            }
                        }
                    }
                    else
                    {
                        foreach (FileInfo file in files)
                        {
                            string targetFilePath = Path.Combine(WorkingFolder, file.Name);
                            file.MoveTo(targetFilePath);
                            string targetCopyPath = Path.Combine(AdditionnalCopyFolder, file.Name);
                            file.CopyTo(targetCopyPath);
                        }
                    }

                    break;

            }
            MessageBox.Show("Le déplacement des fichiers est terminé.");
            LoadDataGridViewImages(Path.Combine(WorkingFolder, "JPG"));

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

        private void visualisationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            listView1.Visible = false;
            pictureBox1.Visible = true;
            if (listView1.SelectedIndices.Count > 0)
            {
                IndexOfSelectedImage = listView1.SelectedIndices[0];
            }
            LoadImageViewer();
        }

        private void modeGrilleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            listView1.Visible = true;
            pictureBox1.Visible = false;
        }

        public void LoadImageViewer()
        {
            //Load image from targetDirectory + jpg at index .
            pictureBox1.Image.Dispose();
            string[] images = Directory.GetFiles(Path.Combine(WorkingFolder, "JPG"));
            pictureBox1.Image = Image.FromFile(images[IndexOfSelectedImage]);


        }

        private void ChangeIndexOfSelectedItem(int numberToAdd)
        {
            int newIndex = IndexOfSelectedImage + numberToAdd;

            if(newIndex < 0 || newIndex >= listView1.Items.Count)
            {
                return;
            }
            
            IndexOfSelectedImage = newIndex;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                //fleche de droite
                ChangeIndexOfSelectedItem(1);
                LoadImageViewer();
                

            }

            if (e.KeyCode == Keys.Left)
            {
                //fleche de gauche
                ChangeIndexOfSelectedItem(-1);
                LoadImageViewer();
            }
        }
    }
}

/*TODO Travailler l'UI et l'UX (grille des images, visualiseur d'images, infos sur l'image en visualisation)

TODO Ajouter une logique de tri des images (en fonctionn de critères : ISO? ouverture, date, nom, lieu, taille, résolution)

TODO Créer la méthode de suppression des RAWs

TODO Ajouter des tests automatiques au projet

TODO Méthode de renommage des fichiers (peut etre des REGEX ?)

TODO Gestion d'erreurs

*/ 