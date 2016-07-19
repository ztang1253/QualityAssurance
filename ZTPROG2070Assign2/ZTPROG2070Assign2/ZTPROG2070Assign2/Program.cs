/*  Program.cs
 *  Assignment 2
 * 
 *  Revision History
 *      Zhenzhen Tang, 2016.02.09: Created
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTPROG2070Assign2
{
    /// <summary>
    /// Demo class
    /// </summary>
    public class Program
    {
        private static string inputString = "";
        private static int edgeOne = 0;
        private static int edgeTwo = 0;
        private static int edgeThree = 0;
        private static TriangleFinder triangle = null;


        static void Main(string[] args)
        {
            triangle = new TriangleFinder();

            while (true)
            {
                Console.WriteLine("1. Enter triangle dimensions");
                Console.WriteLine("2. Exit");
                Console.WriteLine("");

                inputString = Console.ReadLine();
                Console.WriteLine("");

                if (inputString == "1")
                {
                    try
                    {
                        Console.WriteLine("Enter three integers. Please enter the first integer: ");
                        edgeOne = int.Parse(Console.ReadLine());
                        Console.WriteLine("Please enter the second integer: ");
                        edgeTwo = int.Parse(Console.ReadLine());
                        Console.WriteLine("Please enter the third integer: ");
                        edgeThree = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Please only input integers. ");
                        Console.WriteLine("");
                        continue;
                    }
                    Console.WriteLine(triangle.Analyze(edgeOne, edgeTwo, edgeThree));
                    Console.WriteLine("");
                }
                else if (inputString == "2")
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
