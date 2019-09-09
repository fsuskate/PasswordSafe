using System;
using System.IO;
using System.Xml.Serialization;

namespace PasswordSafeWeb.Database
{
    public class XmlStorage : IStoreData
    {
        public bool Save<T>(T obj, string dataFilePath)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                TextWriter tw = new StreamWriter(dataFilePath, append: false);
                xs.Serialize(tw, obj);
                tw.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public T Load<T>(string dataFilePath)
        {
            T result;
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                using (var sr = new StreamReader(dataFilePath))
                {
                    result = (T)xs.Deserialize(sr);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default(T);
            }
            return result;
        }
    }
}