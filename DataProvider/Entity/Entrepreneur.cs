using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DAL
{

    [Serializable]
    public class Entrepreneur : Person, ISerializable
    {
        public int Year { get; set; }
        public Entrepreneur() : base()
        {
            Year = default;
        }
        public Entrepreneur(string name, string surname, int age, int ID, int year, DateTime dateOfBirth)
             : base(name, surname, age, ID)
        {
            this.dateOfBirth = dateOfBirth;
            Year = year;
        }
        public override decimal GetMoney() { return 33000; }
        public override bool CanSkyDive() { return true; }
        public override string DoWork() { return "Виконую роботу підприємця..."; }

        #region custom
        protected Entrepreneur(SerializationInfo info, StreamingContext context)
           : base(info, context)
        {
            dateOfBirth = info.GetDateTime("BORN_ON");
            Year = info.GetInt32("WORK_EXPERIENCE");
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("BORN_ON", dateOfBirth);
            info.AddValue("WORK_EXPERIENCE", Year);
            #endregion
        }
    }
}
