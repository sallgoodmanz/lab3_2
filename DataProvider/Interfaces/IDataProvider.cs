using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IDataProvider
    {
        string FilePath{ get; set; }
        void ClearFileData();
        bool FileExists();
        bool FileHasData();
        void DeleteFile();
    }

}
