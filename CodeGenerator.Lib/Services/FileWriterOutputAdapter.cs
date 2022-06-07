using System.IO;

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

            foreach (string directory in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                CreateDirectory(directory.Replace(sourcePath, targetPath));
            }

            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                Copy(newPath, sourcePath, targetPath);
            }
        }

        private void CreateDirectory(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (System.Exception e)
            {
                if (FileIsWriteProtected(e)) return;

                throw;
            }
        }

        private void Copy(string newPath, string sourcePath, string targetPath)
        {
            try
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
            catch (System.Exception e)
            {
                if (FileIsWriteProtected(e)) return;

                throw;
            }
        }

        private static bool FileIsWriteProtected(System.Exception e)
        {
            return e.Message.StartsWith("Access to the path") && e.Message.EndsWith("is denied.");
        }
    }
}