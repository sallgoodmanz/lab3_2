using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class JSONProvider<T>
    {
        DataProvider dataProvider;
        DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(T));
        public JSONProvider(string path)
        {
            dataProvider = new DataProvider($@"{path}.json");
        }

        public void Serialize(T obj)
        {
            using (var file = new FileStream(dataProvider.FilePath, FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(file, obj);
            }
        }

        public T Deserialize()
        {
            if (dataProvider.FileExists() == false) { throw new MyExeption("Немає даних для десеріалізації"); }

            using (var file = new FileStream(dataProvider.FilePath, FileMode.OpenOrCreate))
            {
                return (T)jsonFormatter.ReadObject(file);
            }
        }
        public void ClearDataFile() { dataProvider.ClearFileData(); }
        public bool FileExists() { return dataProvider.FileExists(); }
        public void DeleteFile() { dataProvider.DeleteFile(); }
    }
}
