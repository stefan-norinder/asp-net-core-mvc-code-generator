using System.IO;

namespace CodeGenerator.Lib.Services
{
    public interface IOutputAdapter
    {
        void Write(string[] strings);
    }

    public class FileWriterOutputAdapter : IOutputAdapter
    {
        public void Write(string[] strings)
        {
            foreach(var str in strings) File.WriteAllText("output.cs", str);
        }
    }
}