using System;
using System.IO;
using System.Text;

namespace Stream
{
    public static class Writer
    {
        public static void Write(string path, string text)
        {
            try
            {
                var dir = Path.GetDirectoryName(path);
                if (!string.IsNullOrEmpty(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                using (FileStream fs =
                    new FileStream(path, FileMode.Create))
                {
                    var writer = new StreamWriter(fs, Encoding.UTF8);

                    writer.WriteLine(text);
                    writer.Flush();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
