using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace FilesMatchFinder
{
    public partial class fileFinderMainForm : Form
    {

        public fileFinderMainForm()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;

            // Чистим таблицу результатов
            resulDataGrid.Rows.Clear();

            if (fileFindWorker.IsBusy != true)
            {
                // Start the asynchronous operation.
                fileFindWorker.RunWorkerAsync();
            }
        }

        private void chooseTorrentFolderButton_Click(object sender, EventArgs e)
        {
            torrentFolderBrowser.ShowDialog();
            torrentDirectoryTextBox.Text = torrentFolderBrowser.SelectedPath;
        }

        private void chooseCollectionFolderButton_Click(object sender, EventArgs e)
        {
            sourceFolderBrowser.ShowDialog();
            fileSourceTextBox.Text = sourceFolderBrowser.SelectedPath;

            // Проверка на возможность использования жестких ссылок
            bool canUseHardLink = checkForHardLinkPossibility();
            useHardLink.Enabled = canUseHardLink;
            if (!canUseHardLink)
                useHardLink.Checked = false;
        }

        private void chooseDestinationFolderButton_Click(object sender, EventArgs e)
        {
            destinationFolderBrowser.ShowDialog();
            fileDestinationTextBox.Text = destinationFolderBrowser.SelectedPath;

            // Проверка на возможность использования жестких ссылок
            bool canUseHardLink = checkForHardLinkPossibility();
            useHardLink.Enabled = canUseHardLink;
            if (!canUseHardLink)
                useHardLink.Checked = false;
        }

        private bool checkForHardLinkPossibility()
        {
            string sourceLetter = "";
            string destinationLetter = "";

            Regex letterFound = new Regex("^([a-z]){1}:*", RegexOptions.IgnoreCase);

            // Буквы дисков источника и назначения
            sourceLetter = letterFound.Match(sourceFolderBrowser.SelectedPath).Value;
            destinationLetter = letterFound.Match(destinationFolderBrowser.SelectedPath).Value;

            // Буквы должны совпадать
            if (sourceLetter != destinationLetter)
                return false;

            DriveInfo dr = new DriveInfo(sourceLetter);

            // Файловая система должна поддерживать жесткие ссылки
            if (dr.DriveFormat != "NTFS")
                return false;

            // TODO Проверить для XP

            return true;
        }

        private void fileFindWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Сканируем директорию с торрентами
            DirectoryInfo torrentDir = new DirectoryInfo(torrentDirectoryTextBox.Text);
            List<FileInfo> torrentFileList=new List<FileInfo>();

            if (recursiveTorrentSearchCheckbox.Checked)
                torrentFileList = new List<FileInfo>(torrentDir.GetFiles("*.torrent", SearchOption.AllDirectories));
            else
                torrentFileList = new List<FileInfo>(torrentDir.GetFiles("*.torrent", SearchOption.TopDirectoryOnly));

            // Сканируем директорию с файлами
            DirectoryInfo filesDir = new DirectoryInfo(fileSourceTextBox.Text);
            List<FileInfo> searchesFileList = new List<FileInfo>(filesDir.GetFiles("*.*", SearchOption.AllDirectories));

            // Читаем каждый торрент

            foreach (FileInfo file in torrentFileList)
            {
                // Читаем .torrent
                Torrent torrent = TorrentReader.ReadTorrent(file.FullName);

                int filesBefore = torrent.Files.Count;
                // Сортируем файлы
                //TreeWalker.FindFiles(torrent, searchesFileList, fileDestinationTextBox.Text, checkOnlyFirstPiece.Checked, copyFileCheckbox.Checked, );

                fileFindWorker.ReportProgress(filesBefore, torrent);
            }
        }

        private void fileFindWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Torrent torrent = e.UserState as Torrent;
            int filesBefore = e.ProgressPercentage;
            int filesProcessed = filesBefore - torrent.Files.Count;

            // Рисуем результаты
            resulDataGrid.Rows.Add(1);
            resulDataGrid.Rows[resulDataGrid.Rows.Count - 1].Cells["FileName"].Value = torrent.FileName.ToLower();
            resulDataGrid.Rows[resulDataGrid.Rows.Count - 1].Cells["FileProc"].Value =
                String.Format("{0}/{1} ({2:f2} %)", filesProcessed, filesBefore, filesProcessed * 100.0 / filesBefore);
        }

        private void fileFindWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            startButton.Enabled = true;
        }
    }
}
