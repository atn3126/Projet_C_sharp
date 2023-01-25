/*using Projet_C_sharp;
using System;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.IO.Pipes;
using System.Runtime;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApp
{
    public static class ClassSerialization
    {
        private static string filePath = "map.bin";

        public static Save(Map)
        {
            FileStream fs = File.Create(filePath);

            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(fs, Map);

            fs.Close();
        }

        public static Map Open(string filePath)
        {
            Map = new Map;

            if (File.Exists(filePath)
            {
                FileStream fs = null;

                try
                {
                    fs = File.OpenRead(filePath);

                    BinaryFormatter bf = new BinaryFormatter();

                    Map = (Map)bf.Deserialize(fs;
                }
                catch (Exception e)
                {

                    throw e;
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Close();
                    }
                }
            }
        }


        return Map;
    }
}*/