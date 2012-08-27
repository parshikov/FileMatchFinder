using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace FilesMatchFinder
{
    public class Torrent
    {
        public Torrent(string name, List<LostFile> files, int pieceLength, char[] hash, string fileName)
        {
            if (name != null)
                Name = name;
            else
                throw new ArgumentNullException(name, "Имя файла не может быть null");

            if (files != null)
                Files = files;
            else
                throw new ArgumentNullException("Список файлов не может быть null");

            if (pieceLength > 0)
                PieceLength = pieceLength;
            else
                throw new ArgumentNullException("Размер куска не может быть меньше нуля");

            Hash = hash;
            FileName= fileName;

        }

        public string Name;
        public int PieceLength;
        public char[] Hash;
        public List<LostFile> Files;
        public string FileName;

        public bool CheckHash(int index, FileInfo fileOnDisk)
        {
            LostFile checkingFile = this.Files[index];

            if (checkingFile.Length < this.PieceLength * 2 - 1)
                return false;

            long start = 0;
            long firstChunkNumber = 0;
            
            long bytesOverhead = checkingFile.BeginFrom % this.PieceLength;

            if (bytesOverhead == 0)
            {
                start = checkingFile.BeginFrom;
                firstChunkNumber = checkingFile.BeginFrom / this.PieceLength;
            }
            else
            {
                firstChunkNumber = checkingFile.BeginFrom / this.PieceLength + 1;
                start = firstChunkNumber * this.PieceLength - checkingFile.BeginFrom;
            }

            char[] hashInTorrent = new char[20];
            Array.Copy(this.Hash, firstChunkNumber * 20, hashInTorrent, 0, 20);
            
            // считаем хэш файла с start до finish
            char[] fileHash = new char[this.PieceLength];

            using (BinaryReader fs = new BinaryReader(new FileStream(fileOnDisk.FullName, FileMode.Open)))
            {
                using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider())
                {
                    byte[] piece = new byte[this.PieceLength];

                    fs.BaseStream.Position = start;

                    fs.Read(piece, 0, this.PieceLength);

                    fileHash = Encoding.GetEncoding(437).GetString(sha1.ComputeHash(piece)).ToCharArray();
                }
            }

            for (int i = 0; i < fileHash.Length; i++)
                if (fileHash[i] != hashInTorrent[i])
                    return false;

            return true;
        }
        
    }
}
