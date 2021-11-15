using System;
using System.Collections.Generic;
using System.Text;
using DAL;

namespace BLL
{
    public class EntityService<T>
    {
        BinProvider<T> bn;
        XMLProvider<T> xml;
        JSONProvider<T> json;
        CustomProvider<T> cstm;
        public EntityService(string path)
        {
            bn = new BinProvider<T>(path);
            xml = new XMLProvider<T>(path);
            json = new JSONProvider<T>(path);
            cstm = new CustomProvider<T>(path);
        }

        public void BinarySerialization(T obj) { bn.Serialize(obj); }
        public void XMLSerialization(T obj) { xml.Serialize(obj); }
        public void JSONSerialization(T obj) { json.Serialize(obj); }
        public void CustomSerialization(T obj) { cstm.Serialize(obj); }


        public T BinaryDeSerialization() { return bn.Deserialize(); }
        public T XMLDeSerialization() { return xml.Deserialize(); }
        public T JSONDeSerialization() { return json.Deserialize(); }
        public T CustomDeSerialization() { return cstm.Deserialize(); }

        public void ClearBinFileData() { bn.ClearDataFile(); }
        public void ClearXMLFileData() { xml.ClearDataFile(); }
        public void ClearJSONFileData() { json.ClearDataFile(); }
        public void ClearCustomFileData() { cstm.ClearDataFile(); }

        public bool FileExists() { return bn.FileExists() || xml.FileExists() || json.FileExists() || cstm.FileExists(); }
    }
}
