using System.IO;

namespace CodeBenchmark.Utils
{
    public static class FileSystemHelper
    {
        public static void SafePath(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            var fi = new FileInfo(fileName);
            if (fi.Directory != null &&  !fi.Directory.Exists)
            {
                fi.Directory.Create();
            }
        }
    }
}
