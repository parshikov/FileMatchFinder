using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace FilesMatchFinder
{
    public static class TreeWalker
    {
        [DllImport("Kernel32.dll", CharSet = CharSet.Unicode)]
        static extern bool CreateHardLink(
        string lpFileName,
        string lpExistingFileName,
        IntPtr lpSecurityAttributes
        );

        public static void ScanFileTree(string path, string pattern, List<FileInfo> files)
        {
            foreach (string dir in Directory.GetDirectories(path))
            {
                try
                {
                    DirectoryInfo currentDir = new DirectoryInfo(dir);
                    files.AddRange(currentDir.GetFiles(pattern, SearchOption.TopDirectoryOnly));

                    ScanFileTree(dir, pattern, files);
                }
                catch (UnauthorizedAccessException e)
                {
                    continue;
                }
            }
        }

        public static List<FileInfo> ScanFileTree(string path, string pattern, SearchOption searchOption)
        {
            List<FileInfo> files = new List<FileInfo>();

            DirectoryInfo dirInfo = new DirectoryInfo(path);
            files.AddRange(dirInfo.GetFiles(pattern, SearchOption.TopDirectoryOnly));

            if (searchOption == SearchOption.AllDirectories)
                ScanFileTree(path, pattern, files);

            return files;
        }

        public static void FindFiles(Torrent torrent, List<FileInfo> files, string destinationPath, bool checkFirstOnly, bool copyFile, bool useHardlink)
        {
            //int i = 0;

            for (int i = 0; i < torrent.Files.Count; i++)
            {
                LostFile fileInTorrent = torrent.Files[i];

                for (int j = 0; j < files.Count; j++)
                {
                    FileInfo fileOnDisk = files[j];

                    // Ищем файл с таким разширением
                    if (fileOnDisk.Extension.ToLower() != Path.GetExtension(fileInTorrent.Name).ToLower())
                        continue;
                    // Проверяем хэш
                    if (!torrent.CheckHash(i, fileOnDisk, checkFirstOnly))
                        continue;

                    // Все проверки пройдены. перед нами искомый файл
                    // Перемещаем его
                    FileInfo fileToMove = new FileInfo(destinationPath + @"\" + fileInTorrent.Name);

                    if (!Directory.Exists(fileToMove.DirectoryName))
                        Directory.CreateDirectory(fileToMove.DirectoryName);

                    if (!fileToMove.Exists)
                    {
                        if (!useHardlink)
                        {
                            if (copyFile)
                                File.Copy(fileOnDisk.FullName, fileToMove.FullName);
                            else
                                File.Move(fileOnDisk.FullName, fileToMove.FullName);
                        }
                        else
                        {
                            CreateHardLink(fileToMove.FullName, fileOnDisk.FullName, IntPtr.Zero);
                        }

                        // И убираем из списка рассматириваемых
                        files.Remove(fileOnDisk);
                        // Убираем из описания торрента
                        torrent.Files.RemoveAt(i--);

                        break;
                    }
                }
            }
        }
    }
}
