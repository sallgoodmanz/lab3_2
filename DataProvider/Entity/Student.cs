using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;


namespace DAL
{

    [Serializable]
    public class Student : Person, ISerializable
    {
        public int Year { get; set; }
        public int StudentTicket { get; set; }
        public Student() : base()
        {
            Year = default;
            StudentTicket = default;
        }
        public Student(string name, string surname, int age, int ID, int year, int studentTicket, DateTime dateOfBirth)
            : base(name, surname, age, ID)
        {
            if (InputProtection.ProtectedIntegers(year, 6, 2) && InputProtection.ProtectedIntegers(studentTicket, 999999, 6))
            {
                this.dateOfBirth = dateOfBirth;
                Year = year;
                StudentTicket = studentTicket;
            }
            else throw new MyExeption();
        }


        public override decimal GetMoney() { return 2000; }
        public override bool CanSkyDive() { return true; }
        public override string DoWork() { return "Виконую лабораторну роботу..."; }
      
        #region custom
        protected Student(SerializationInfo info, StreamingContext context)
             : base(info, context)
        {
            dateOfBirth = info.GetDateTime("BORN_ON");
            Year = info.GetInt32("YEAR");
            StudentTicket = info.GetInt32("STUDENT_TICKET");
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("BORN_ON", dateOfBirth);
            info.AddValue("YEAR", Year);
            info.AddValue("STUDENT_TICKET", StudentTicket);
        }
        #endregion
    }
}

