/*  Program.cs
 *  Assignment 3
 * 
 *  Revision History
 *      Zhenzhen Tang, 2016.03.16: Created
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTPROG2070Assign3;

namespace ProjectC
{
    /// <summary>
    /// Test class
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = "";
            double distance = 0;
            string originalUnit = "";
            string wishUnit = "";
            string resultDistance = "";

            while (true)
            {
                Console.WriteLine("------------- Please enter a valid distance (number) -------------");
                inputString = Console.ReadLine();
                try
                {
                    distance = Convert.ToDouble(inputString);
                }
                catch (Exception)
                {
                    continue;
                }
                Console.WriteLine("");

                while (true)
                {
                    try
                    {
                        Console.WriteLine("------------- Please enter the original unit -------------");
                        Console.WriteLine("( i/I/inches/Inches/f/F/feet/Feet/y/Y/yards/Yards/m/M/miles/Miles )");
                        originalUnit = Console.ReadLine();
                        Console.WriteLine("");
                        resultDistance = UnitConversion.Convert(distance, originalUnit, "i").ToString();
                        break;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                        continue;
                    }
                }

                while (true)
                {
                    try
                    {
                        Console.WriteLine("------------- Please enter the unit you wish to convert to -------------");
                        Console.WriteLine("( i/I/inches/Inches/f/F/feet/Feet/y/Y/yards/Yards/m/M/miles/Miles )");
                        wishUnit = Console.ReadLine();
                        Console.WriteLine("");
                        resultDistance = UnitConversion.Convert(distance, originalUnit, wishUnit).ToString();
                        break;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                        continue;
                    }
                }

                resultDistance = UnitConversion.Convert(distance, originalUnit, wishUnit).ToString();
                Console.WriteLine(distance + " " + originalUnit + " = " + resultDistance + " " + wishUnit);
                Console.WriteLine("");

                Console.WriteLine("------------- Do you want to exit ? -------------");
                Console.WriteLine("------------- Press y to exit, any other key to continue -------------");
                inputString = Console.ReadLine().ToLower();
                if (inputString == "y")
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
