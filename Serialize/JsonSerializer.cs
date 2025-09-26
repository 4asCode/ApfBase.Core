using Exceptions.Serialize;
using Newtonsoft.Json;
using System;

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
            catch (Exception ex)
            {
                throw new SerializerException(
                    $"Ошибка при сериализации данных", ex
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
            catch (Exception ex)
            {
                throw new SerializerException(
                    $"Ошибка при десериализации данных", ex
                    );
            }
        }
    }
}
