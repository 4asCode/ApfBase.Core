using Exceptions.Serialize;
using System;
using System.Collections.Generic;
using System.IO;


namespace Serialize
{
    public static class XmlSerializer
    {
        public static void Serialize<T>(List<T> settingList, string fileName)
        {
            try
            {
                System.Xml.Serialization.XmlSerializer serializer =
                    new System.Xml.Serialization.XmlSerializer(typeof(List<T>)
                    );

                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    serializer.Serialize(fs, settingList);
                }
            }
            catch (Exception ex)
            {
                throw new SerializerException(
                    $"Ошибка при сериализации данных в файл: " +
                    $"{fileName}", ex
                    );
            }
        }

        public static List<T> Deserialize<T>(string fileName)
        {
            var settingList = new List<T>();

            try
            {
                System.Xml.Serialization.XmlSerializer serializer = 
                    new System.Xml.Serialization.XmlSerializer(typeof(List<T>)
                    );

                using (FileStream fs = 
                    new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    if (fs.Length != 0)
                        settingList = (List<T>)
                            serializer.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                throw new SerializerException(
                    $"Ошибка при десериализации данных из файла: " +
                    $"{fileName}", ex
                    );
            }

            return settingList;
        }
    }
}
