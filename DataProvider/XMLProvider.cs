using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace DAL
{
    public class XMLProvider<T>
    {
        DataProvider dataProvider;
        XmlSerializer xmlFormatter = new XmlSerializer(typeof(T));
        public XMLProvider(string path)
        {
            dataProvider = new DataProvider($@"{path}.xml");
        }

        public void Serialize(T obj)
        {
            using (var file = new FileStream(dataProvider.FilePath, FileMode.OpenOrCreate))
            {
                xmlFormatter.Serialize(file, obj);
            }
        }

        public T Deserialize()
        {
            if (dataProvider.FileExists() == false) { throw new MyExeption("Немає даних для десеріалізації"); }

            using (var file = new FileStream(dataProvider.FilePath, FileMode.OpenOrCreate))
            {
                return (T)xmlFormatter.Deserialize(file);
            }
        }

        public void ClearDataFile() { dataProvider.ClearFileData(); }
        public bool FileExists() { return dataProvider.FileExists(); }
    }
}
