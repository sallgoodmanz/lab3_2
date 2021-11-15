using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CustomProvider<T>
    {
        DataProvider dataProvider;
        IFormatter binFormatter = new BinaryFormatter();

        public CustomProvider(string path)
        {
            dataProvider = new DataProvider($@"{path}.cstm");
        }

        public void Serialize(T obj)
        {
            using (var file = new FileStream(dataProvider.FilePath, FileMode.OpenOrCreate))
            {
                binFormatter.Serialize(file, obj);
            }
        }

        public T Deserialize()
        {
            if (dataProvider.FileExists() == false) { throw new MyExeption("Немає даних для десеріалізації"); }

            using (var file = new FileStream(dataProvider.FilePath, FileMode.OpenOrCreate))
            {
                return (T)binFormatter.Deserialize(file);
            }
        }
        public void ClearDataFile() { dataProvider.ClearFileData(); }
        public bool FileExists() { return dataProvider.FileExists(); }
    }
}
