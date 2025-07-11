﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Stream
{
    public static class Reader
    {
        public static List<(string FullPath, string Name)> GetFileName(
            string directory, string pattern = "*")
        {
            var files = new List<(string FullPath, string Name)>();
            try
            {
                Directory
                .GetFiles(directory, pattern, SearchOption.TopDirectoryOnly)
                .ToList()
                .ForEach(f => files.Add(
                    (Path.GetFullPath(f), Path.GetFileName(f))
                    )
                );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return files;
        }

        public static string Read(string path)
        {
            try
            {
                using (FileStream fs = 
                    new FileStream(path, FileMode.Open))
                {
                    var reader = new StreamReader(fs, Encoding.Default);
                    string str = reader.ReadToEnd();
                    return str;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
