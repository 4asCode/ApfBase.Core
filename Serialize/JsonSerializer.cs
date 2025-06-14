using System;
using System.IO;
using Newtonsoft.Json;

namespace Serialize
{
    public class JsonSerializer
    {
        public string Serialize<T>(T collection)
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
                throw new Exception(ex.Message);
            }
        }

        public T Deserialize<T>(string data)
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
                throw new Exception(ex.Message);
            }
        }
    }
}
