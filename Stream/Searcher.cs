using Exceptions.Stream;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Stream
{
    public class Searcher
    {
        public static List<string> GetDirectories(
            string path, string searchPattern = "*",
            SearchOption searchOption = SearchOption.AllDirectories)
        {
            try
            {
                var directories = Directory.GetDirectories(
                    path, searchPattern, searchOption).ToList();

                if (searchOption == SearchOption.TopDirectoryOnly)
                {
                    return new List<string>() { path };
                }
                else if (searchOption == SearchOption.AllDirectories)
                {
                    directories.Add(path);
                }

                return directories;
            }
            catch (UnauthorizedAccessException)
            {
                return new List<string>();
            }
            catch (Exception ex)
            {
                throw new ReaderException(
                    $"Ошибка при получении списка каталогов " +
                    $"для пути: {path}", ex
                    );
            }
        }
    }
}
