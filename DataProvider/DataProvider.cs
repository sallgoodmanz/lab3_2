using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DAL
{
    class DataProvider : IDataProvider
    {
        public string FilePath { get; set; }

        public DataProvider(string path)
        {
            FilePath = path;
        }

        public void ClearFileData()
        {
            File.WriteAllText(FilePath, string.Empty);
        }
        public bool FileExists()
        {
            if (File.Exists(FilePath))
            {
                return true;
            }
            return false;
        }

        public bool FileHasData()
        {
            if (FileExists()) 
            { 
                if (File.ReadAllText(FilePath) != string.Empty) 
                    return true; 
            }
            return false;
        }

        public void DeleteFile()
        {
            File.Delete(FilePath);
        }
    }
}
