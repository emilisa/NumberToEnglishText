using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace NumberToEnglishText
{
    class NumberToEnglishText
    {
        /// <Exercise goal>
        /// Write a program that converts a number in the range [0...999] to a text corresponding 
        /// to its English pronunciation. Examples:
	    /// 0 - "Zero"
	    /// 273 - "Two hundred seventy three"
	    /// 400 - "Four hundred"
	    /// 501 - "Five hundred and one"
	    /// 711 - "Seven hundred and eleven"
        /// </summary>        
        
        static void Main()
        {
            Console.Title = "Number To English Text";

            Console.BufferHeight = 1010;

            //int input = int.Parse(Console.ReadLine()); // Manualy check for given number its text representation

            //Database numbers names from 0 to 19

            List<string> numbers0to19 =
                new List<string>() {"Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", 
                    "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"};

            //Database numbers names from 20 to 99

            List<string> numbers20to90 =
                new List<string>() { "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

            int input = 0;

            while (input <= 999) // While loop automaticly check all the numbers from 0 to 999
            {
                string inputString = input.ToString();
                
                Console.Write("{0} :", input);

                Console.ForegroundColor = ConsoleColor.Yellow;

                if (input >= 0 && input < 20) //Reads numbers from 0 to 19
                {
                    Console.WriteLine(numbers0to19[input]);
                }

                else if (input >= 20 && input <= 99) //Reads numbers from 20 to 99
                {
                    int num0 = inputString[0] - 48;

                    int num1 = inputString[1] - 48;

                    if (num1 == 0) //Reads numbers from 20,30,40,50,60,70,80,90 (always zero in the end)
                    {
                        Console.WriteLine(numbers20to90[num0 - 2]);
                    }

                    else // Reads all other numbers in range 20 to 99
                    {
                        Console.WriteLine(numbers20to90[num0 - 2] + " " + numbers0to19[num1].ToLower());
                    }
                }

                else if (input >= 100 && input <= 999) //Reads numbers from 100 to 999
                {
                    int num0 = inputString[0] - 48;

                    int num1 = inputString[1] - 48;

                    int num2 = inputString[2] - 48;


                    if (num1 == 0 && num2 == 0) //Reads numbers 100,200,300,400,500,600,700,800,900 (always two zeros)
                    {
                        Console.WriteLine(numbers0to19[num0] + " hundred");
                    }

                    else if (num1 != 1 && num2 == 0) //Reads numbers like 720, 990, 880, 640, 360, 540 (always zero in the end)
                    {
                        Console.WriteLine(numbers0to19[num0] + " hundred and "
                            + numbers20to90[num1 - 2].ToLower());
                    }

                    else if (num1 == 0 && num2 > 0) //Reads numbers like 909, 808, 604, 306, 504 (always zero in the middle)
                    {
                        Console.WriteLine(numbers0to19[num0] + " hundred and "
                            + numbers0to19[num2].ToLower());
                    }

                    else if (num1 == 1 && num2 >= 0) // Reads numbers like 919, 818, 614, 316, 514 (always one in the middle)
                    {
                        Console.WriteLine(numbers0to19[num0] + " hundred and "
                            + numbers0to19[num2 + 10].ToLower());
                    }

                    else // Reads all other numbers in range 100 to 999
                    {
                        Console.WriteLine(numbers0to19[num0] + " hundred "
                            + numbers20to90[num1 - 2].ToLower() + " " + numbers0to19[num2].ToLower());
                    }
                }

                input++;

                Thread.Sleep(25);

                Console.ResetColor();
            }

            //CharToInt();
        }

        static void CharToInt()
        {
            int input = int.Parse(Console.ReadLine());

            string inputString = Convert.ToString(input);

            #region Variant0

            //int num0 = inputString[0] - 48;

            //int num1 = inputString[1] - 48;

            //int num2 = inputString[2] - 48;

            //Console.WriteLine(num0 + num1 + num2);

            #endregion

            #region Variant1

            //int num0 = (int)Char.GetNumericValue(inputString[0]);

            //int num1 = (int)Char.GetNumericValue(inputString[1]);

            //int num2 = (int)Char.GetNumericValue(inputString[2]);

            //Console.WriteLine(num0 + num1 + num2);

            #endregion

            #region Variant2

            //int num0 = int.Parse(Convert.ToString(inputString[0]));

            //int num1 = int.Parse(Convert.ToString(inputString[1]));

            //int num2 = int.Parse(Convert.ToString(inputString[2]));

            //Console.WriteLine(num0 + num1 + num2);

            #endregion

        }
    }
}
