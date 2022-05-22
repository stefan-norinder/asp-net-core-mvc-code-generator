using System.IO;

namespace CodeGenerator.Lib.Services
{
    public interface IOutputAdapter
    {
        void Write(string basePath, string filename, string content);
    }

    public class FileWriterOutputAdapter : IOutputAdapter
    {
        public void Write(string basePath, string filename, string content)
        {
            Directory.CreateDirectory(basePath);
            var path = Path.Combine(basePath, filename);
            File.WriteAllText(path, content);
        }
    }
}