using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DAL
{
    [Serializable]
    public class Baker : Person, ISerializable
    {
        public Baker() : base()
        {
        }
        public Baker(string name, string surname, int age, int ID, DateTime dateOfBirth)
           : base(name, surname, age, ID)
        {
            this.dateOfBirth = dateOfBirth;
        }
        public override decimal GetMoney() { return 13000; }
        public override bool CanSkyDive() { return true; }
        public override string DoWork() { return "Виконую роботу пекаря..."; }
        #region custom
        protected Baker(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            dateOfBirth = info.GetDateTime("BORN_ON");
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("BORN_ON", dateOfBirth);
        }
        #endregion
    }
}
