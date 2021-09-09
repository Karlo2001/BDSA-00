using System;

namespace BDSA_00
{
    public class Program
    {
        public const string ERROR_INPUT_YEAR_BELOW_1582 = "You can only test years from 1582";
        public const string ERROR_INPUT_CANT_CONVERT = "The input is not a valid number";
        public const string ERROR_INPUT_OVERFLOW = "The input was either too large or too small";
        public static void Main(string[] args)
        {
            Console.Write("Insert a year to see if it is a leap year: ");
            string input = Console.ReadLine();
            int year = 0;
            try
            {
                year = Convert.ToInt32(input);
            } 
            catch (FormatException e)
            {
                Console.WriteLine(ERROR_INPUT_CANT_CONVERT);
                return;
            }
            catch (OverflowException e)
            {
                Console.WriteLine(ERROR_INPUT_OVERFLOW);
                return;
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.ToString());
                return;
            }

            if(year >= 1582) 
            {
                if(IsLeapYear(year))
                {
                    Console.WriteLine("yay");
                } else {
                    Console.WriteLine("nay");
                }
            }
            else
            {
                Console.WriteLine(ERROR_INPUT_YEAR_BELOW_1582);
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
