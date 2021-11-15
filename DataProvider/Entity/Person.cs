using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;



namespace DAL
{

    [Serializable]
    abstract public class Person : ISerializable, IGettibleMoney, ISkyDivable, IWorkable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int ID { get; set; }

        public DateTime dateOfBirth = new DateTime();
        public Person()
        {
            Name = default;
            Surname = default;
            Age = default;
            ID = default;
        }
        public Person(string name, string surname, int age, int ID)
        {
            if (InputProtection.ProtectedLetters(name) && InputProtection.ProtectedLetters(surname)
                && InputProtection.ProtectedIntegers(age, 100, 3) && InputProtection.ProtectedIntegers(ID, 999999, 6))
            {
                Name = name;
                Surname = surname;
                Age = age;
                this.ID = ID;
            }
            else throw new MyExeption();
        }

        public abstract decimal GetMoney();
        public abstract bool CanSkyDive();
        public abstract string DoWork();

        #region custom
        protected Person(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("NAME");
            Surname = info.GetString("SURNAME");
            Age = info.GetInt32("AGE");
            ID = info.GetInt32("ID");
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("NAME", Name);
            info.AddValue("SURNAME", Surname);
            info.AddValue("AGE", Age);
            info.AddValue("ID", ID);
        }
        #endregion
    }
}
