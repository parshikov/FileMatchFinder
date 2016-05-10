using System.Collections.Generic;
using System.Text;
using BencodeLibrary;
using System.IO;

namespace FilesMatchFinder
{
    public static class TorrentReader
    {
        public static Torrent ReadTorrent(string filename)
        {
            // Читаем файл торрента и берем необходимый словарь info
            List<LostFile> files = new List<LostFile>();
            BDict torrent = (BDict)BencodingUtils.DecodeFile(filename, Encoding.UTF8);
            BDict fileInfo = (BDict)torrent["info"];

            string name = ((BString)fileInfo["name"]).Value;
            int pieceLength = (int)((BInt)fileInfo["piece length"]).Value;

            // Перечитываем торрент еще раз, чтобы взять хеш в нужном виде
            torrent = (BDict)BencodingUtils.DecodeFile(filename, Encoding.GetEncoding(437));
            char[] pieces = ((BString)((BDict)torrent["info"])["pieces"]).Value.ToCharArray();

            if (fileInfo.ContainsKey("files")) // Multifile torrent
            {
                BList filesData = (BList)fileInfo["files"];
                long begin = 0;

                foreach (BDict file in filesData)
                {
                    BList filePaths = (BList)file["path"];
                    long length = ((BInt)file["length"]).Value;

                    string fullPath = name;
                    foreach (BString partOfPath in filePaths)
                    {
                        fullPath += Path.DirectorySeparatorChar + partOfPath.Value;
                    }
                    files.Add(new LostFile(fullPath, length, begin));

                    begin += length;
                }
            }
            else // Singlefile torrent
            {
                long Length = ((BInt)fileInfo["length"]).Value;
                files.Add(new LostFile(name, Length, 0));
            }
            
            return new Torrent(name, files, pieceLength, pieces, filename);
        }
    }
} 