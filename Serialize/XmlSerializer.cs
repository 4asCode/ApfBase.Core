﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialize
{
    public class XmlSerializer
    {
        public void Serialize<T>(List<T> settingList, string fileName)
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
                throw new Exception(ex.Message);
            }
        }

        public List<T> Deserialize<T>(string fileName)
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
                throw new Exception(ex.Message);
            }

            return settingList;
        }
    }
}
