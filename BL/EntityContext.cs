using System;
using System.Collections.Generic;
using System.Text;
using DAL;

namespace BLL
{
    public class EntityContext
    {
        public Student student;
        public Baker baker;
        public Entrepreneur entrepreneur;
        #region serialization
        public void BINSerializator(string path, Student student)
        {
            BinProvider bn = new BinProvider(path);
            bn.Serialize(student);
           // this.student = student;
        }
        public void BINSerializator(string path, Baker baker)
        {
            BinProvider bn = new BinProvider(path);
            bn.Serialize(baker);
        }
        public void BINSerializator(string path, Entrepreneur entrepreneur)
        {
            BinProvider bn = new BinProvider(path);
            bn.Serialize(entrepreneur);
        }
        #endregion

        #region deserialization
        public static Student BINDeSerializator(string path, Student student)
        {
            BinProvider bn = new BinProvider(path);
           return bn.Deserialize(student);
        }
        public static Baker BINDeSerializator(string path, Baker baker)
        {
            BinProvider bn = new BinProvider(path);
           return bn.Deserialize(baker);
        }
        public static Entrepreneur BINDeSerializator(string path, Entrepreneur entrepreneur)
        {
            BinProvider bn = new BinProvider(path);
            return bn.Deserialize(entrepreneur);
        }
        #endregion
    }
}
