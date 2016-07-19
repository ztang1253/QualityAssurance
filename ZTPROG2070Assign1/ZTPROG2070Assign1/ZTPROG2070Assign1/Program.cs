/*  Program.cs
 *  Assignment 1
 * 
 *  Revision History
 *      Zhenzhen Tang, 2016.02.02: Created
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ZTPROG2070Assign1
{
    /// <summary>
    /// Demo class
    /// </summary>
    public class Program
    {
        private static string inputString = "";
        private static Circle circle = null;

        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Please enter the radius of the circle: ");
                Console.WriteLine("");
                inputString = Console.ReadLine();
                Console.WriteLine("");
                try
                {
                    circle = new Circle(double.Parse(inputString));
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Radius should be a double zero or higher only. ");
                }
            }

            while (true)
            {
                Console.WriteLine("*************************");
                Console.WriteLine("1. Add to Circle Radius");
                Console.WriteLine("2. Subtract from Circle Radius");
                Console.WriteLine("3. Calculate Circle Circumference");
                Console.WriteLine("4. Calculate Circle Area");
                Console.WriteLine("5. Exit");
                Console.WriteLine("");

                inputString = Console.ReadLine();
                Console.WriteLine("");

                if (inputString == "1")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Please input a number you want to add to the radius: ");
                    Console.WriteLine("");
                    inputString = Console.ReadLine();
                    Console.WriteLine("");
                    try
                    {
                        circle.AddToRadius(double.Parse(inputString));
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Incorrect input. ");
                        Console.WriteLine("");
                        continue;
                    }
                    Console.WriteLine("Radius is " + circle.radius + ". ");
                    Console.WriteLine("");
                }
                else if (inputString == "2")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Please input a number you want to subtract from the radius: ");
                    Console.WriteLine("");
                    inputString = Console.ReadLine();
                    Console.WriteLine("");
                    try
                    {
                        circle.SubtractFromRadius(double.Parse(inputString));
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Incorrect input. ");
                        Console.WriteLine("");
                        continue;
                    }
                    Console.WriteLine("Radius is " + circle.radius + ". ");
                    Console.WriteLine("");
                }
                else if (inputString == "3")
                {
                    try
                    {
                        Console.WriteLine("Circumference is " + circle.GetCircumference() + ". ");
                        Console.WriteLine("");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (inputString == "4")
                {
                    try
                    {
                        Console.WriteLine("Area is " + circle.GetArea() + ". ");
                        Console.WriteLine("");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (inputString == "5")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Incorrect input. ");
                    Console.WriteLine("");
                }
            }

        }
    }
}