﻿using System.IO;

namespace CodeGenerator.Lib.Services
{
    public interface IOutputAdapter
    {
        void Write(string basePath, string filename, string content);
        void CopyFoldersAndFilesFromSourceToTarge(string sourcePath, string targetPath);
    }

    public class FileWriterOutputAdapter : IOutputAdapter
    {
        public void Write(string basePath, string filename, string content)
        {
            try
            {
                Directory.CreateDirectory(basePath);
                var path = Path.Combine(basePath, filename);
                File.WriteAllText(path, content);
            }
            catch (System.Exception e)
            {
                if (FileIsWriteProtected(e)) return;

                throw;
            }
        }

        public void CopyFoldersAndFilesFromSourceToTarge(string sourcePath, string targetPath)
        {
            Directory.CreateDirectory(targetPath);

            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }

            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }

        private static bool FileIsWriteProtected(System.Exception e)
        {
            return e.Message.StartsWith("Access to the path") && e.Message.EndsWith("is denied.");
        }
    }
}