using System;
using System.Collections.Generic;
using System.Text;
using DAL;

namespace BLL
{

    public static class EntityService 
    {
        public static Student student;
        public static Student AddStudent(string name, string surname, int age, int ID, int year, int studentTicket)
        {
            Student student = new Student(name, surname, age, ID, year, studentTicket);
           
            return student;
        }

        public static Baker AddBaker(string name, string surname, int age, int ID)
        {
            Baker baker = new Baker(name, surname, age, ID);
            return baker;
        }

        public static Entrepreneur AddEntrepreneur(string name, string surname, int age, int ID)
        {
            Entrepreneur entrepreneur = new Entrepreneur(name, surname, age, ID);
            return entrepreneur;
        }

        
    }
}
