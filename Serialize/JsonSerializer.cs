using System;
using System.IO;
using Newtonsoft.Json;

namespace Serialize
{
    public static class JsonSerializer
    {
        public static string Serialize<T>(T collection)
        {
            try
            {
                return JsonConvert.SerializeObject(collection, 
                    new JsonSerializerSettings() 
                    {
                        TypeNameHandling = TypeNameHandling.Auto,
                        NullValueHandling = NullValueHandling.Ignore,
                        Formatting = Formatting.Indented
                    }
                );
            }
            catch (Exception)
            {
                throw new Exception(
                    "Ошибка при сериализации данных!"
                    );
            }
        }

        public static T Deserialize<T>(string data)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(data, 
                    new JsonSerializerSettings() 
                    {
                        TypeNameHandling = TypeNameHandling.Auto,
                        NullValueHandling = NullValueHandling.Ignore,
                        Formatting = Formatting.Indented
                    }
                );
            }
            catch (Exception)
            {
                throw new Exception(
                    "Ошибка при десериализации данных!"
                    );
            }
        }
    }
}
