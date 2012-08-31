using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BencodeLibrary;
using System.IO;
using System.Security.Cryptography;
using System.Threading;

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

            // Сканируем директорию с торрентами
            DirectoryInfo torrentDir = new DirectoryInfo(torrentDirectoryTextBox.Text);
            List<FileInfo> torrentFileList;

            if (recursiveTorrentSearchCheckbox.Checked)
                torrentFileList = new List<FileInfo>(torrentDir.GetFiles("*.torrent", SearchOption.AllDirectories));
            else
                torrentFileList = new List<FileInfo>(torrentDir.GetFiles("*.torrent", SearchOption.TopDirectoryOnly));

            // Сканируем директорию с файлами
            DirectoryInfo filesDir = new DirectoryInfo(fileSourceTextBox.Text);
            List<FileInfo> searchesFileList = new List<FileInfo>(filesDir.GetFiles("*.*", SearchOption.AllDirectories));

            // Чистим таблицу результатов
            resulDataGrid.Rows.Clear();

            // Читаем каждый торрент

            foreach (FileInfo file in torrentFileList)
            {
                Torrent torrent = TorrentReader.ReadTorrent(file.FullName);

                // Сортируем файлы и подсчитываем количество обработанных
                int before = torrent.Files.Count;
                TreeWalker.FindFiles(torrent, searchesFileList, fileDestinationTextBox.Text, copyFileCheckbox.Checked);
                int after = torrent.Files.Count;

                // Рисуем результаты
                resulDataGrid.Rows.Add(1);
                resulDataGrid.Rows[resulDataGrid.Rows.Count - 1].Cells["FileName"].Value = torrent.FileName.ToLower();
                resulDataGrid.Rows[resulDataGrid.Rows.Count - 1].Cells["FileProc"].Value = String.Format("{0}/{1} ({2:f2} %)", before - after, before, (before - after) * 100.0 / before);
            }
            startButton.Enabled = true;
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
        }

        private void chooseDestinationFolderButton_Click(object sender, EventArgs e)
        {
            destinationFolderBrowser.ShowDialog();
            fileDestinationTextBox.Text = destinationFolderBrowser.SelectedPath;
        }
    }
}
