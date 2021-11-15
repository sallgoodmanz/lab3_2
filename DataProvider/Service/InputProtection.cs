using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public static class InputProtection
    {
        public static bool ProtectedLetters(string input)
        {
            foreach (char c in input)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }
        public static bool ProtectedIntegers(int input, int maxValue, int maxLength)
        {
            if ((input >= 0 && input <= maxValue) && (input.ToString().Length <= maxLength))
            {
                return true; 
            }
            return false;
        }
    }
}
