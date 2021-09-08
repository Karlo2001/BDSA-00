using System;

namespace BDSA_00
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Insert a year to see if it is a leap year: ");
            string input = Console.ReadLine();
            int year = Convert.ToInt32(input);

            if(IsLeapYear(year))
            {
                Console.WriteLine("yay");
            } else {
                Console.WriteLine("nay");
            }
        }

        public static bool IsLeapYear(int year)
        {
            if(year % 4 == 0 && (year % 100 != 0 || year % 400 == 0))
            {
                return true;
            }
            return false;
        }
    }
}
