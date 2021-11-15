using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    class MyExeption : Exception
    {
        public MyExeption() : base("Некоректне введення даних!") { }

        public MyExeption(string message) : base(message) { }
    }
}
