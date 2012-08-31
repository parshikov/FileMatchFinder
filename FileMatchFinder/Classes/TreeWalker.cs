using System.Collections.Generic;
using System.IO;

namespace FilesMatchFinder
{
    public static class TreeWalker
    {
        public static void FindFiles(Torrent torrent, List<FileInfo> files, string destinationPath, bool copyFile)
        {
            //int i = 0;

            for (int i = 0; i < torrent.Files.Count; i++)// (LostFile fileInTorrent in torrent.Files)
            {
                LostFile fileInTorrent = torrent.Files[i];

                for (int j = 0; j < files.Count; j++)
                {
                    FileInfo fileOnDisk = files[j];

                    // Ищем файл с таким разширением
                    if (fileOnDisk.Extension != Path.GetExtension(fileInTorrent.Name))
                        continue;
                    // Проверяем хэш
                    if (!torrent.CheckHash(i, fileOnDisk))
                        continue;

                    // Все проверки пройдены. перед нами искомый файл
                    // Перемещаем его
                    FileInfo fileToMove = new FileInfo(destinationPath + @"\" + fileInTorrent.Name);

                    if (!Directory.Exists(fileToMove.DirectoryName))
                        Directory.CreateDirectory(fileToMove.DirectoryName);

                    if (!fileToMove.Exists)
                    {
                        if (copyFile)
                            File.Copy(fileOnDisk.FullName, fileToMove.FullName);
                        else
                            File.Move(fileOnDisk.FullName, fileToMove.FullName);

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
