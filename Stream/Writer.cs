using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Stream
{
    public class Writer
    {
        public void Write(string path, string text)
        {
            try
            {
                using (FileStream fs =
                    new FileStream(path, FileMode.Create))
                {
                    var writer = new StreamWriter(fs, Encoding.Default);

                    writer.WriteLine(text);
                    writer.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
