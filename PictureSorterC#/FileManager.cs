using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureSorterC_
{
    public partial class Form1
    {
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

        private void DeleteRaw()
        {
            List<string> RAWimages = new List<string>(Directory.GetFiles(Path.Combine(WorkingFolder, "RAW")));
            string NameRAWFile;
            int indexJPGList;
            int indexRAWList;

            int NumberOfRaw = RAWimages.Count;
            int NbDeleted = 0;

            for (int i = 0; i < NumberOfRaw; i++)
            {
                indexRAWList = i - NbDeleted;
                NameRAWFile = Path.GetFileNameWithoutExtension(RAWimages[indexRAWList]);
                indexJPGList = ImagesToDelete.IndexOf(NameRAWFile);

                if (indexJPGList > -1)
                {
                    File.Delete(RAWimages[indexRAWList]);
                    ImagesToDelete.RemoveAt(indexJPGList);
                    RAWimages.RemoveAt(indexRAWList);
                    NbDeleted++;
                }
            }
            MessageBox.Show("La suppression des RAWs est terminée");
        }

        private void DeleteImageAtIndex(int index)
        {
            string[] images = Directory.GetFiles(Path.Combine(WorkingFolder, "JPG"));
            listView1.Items.RemoveAt(index);
            pictureBox1.Image.Dispose();

            ImagesToDelete.Add(Path.GetFileNameWithoutExtension(images[index]));

            File.Delete(images[index]);
        }
    }
}
