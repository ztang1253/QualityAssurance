/*  UnitConversion.cs
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

namespace ZTPROG2070Assign3
{
    /// <summary>
    /// Class to convert a length unit to another length unit
    /// </summary>
    public static class UnitConversion
    {
        public static double Convert(double value, string convertFrom, string convertTo)
        {
            double result = 0.0;
            string modConvertFrom = ModifyInputStub(convertFrom);
            string modConvertTo = ModifyInputStub(convertTo);

            result = value * GetMultiplierStub(modConvertFrom, modConvertTo);
            return result;
        }

        public static string ModifyInputStub(string input)
        {            
            return "inches";
        }

        public static double GetMultiplierStub(string convertFrom, string convertTo)
        {
            return 3.0;
        }

        public static string ModifyInput(string input)
        {
            string modInput = "";

            if (input == "i" || input == "I" || input == "inches" || input == "Inches")
            {
                modInput = "inches";
            }
            else if (input == "f" || input == "F" || input == "feet" || input == "Feet")
            {
                modInput = "feet";
            }
            else if (input == "y" || input == "Y" || input == "yards" || input == "Yards")
            {
                modInput = "yards";
            }
            else if (input == "m" || input == "M" || input == "miles" || input == "Miles")
            {
                modInput = "miles";
            }
            else
            {
                throw new ArgumentException("Incorrect Conversion Unit");
            }

            return modInput;
        }

        public static double GetMultiplier(string convertFrom, string convertTo)
        {
            double multiplier = 1.0;

            switch (convertFrom.ToLower())
            {
                case "inches":
                    if (convertTo == "feet")
                    {
                        multiplier = 1.0 / 12.0;
                    }
                    else if (convertTo == "yards")
                    {
                        multiplier = 1.0 / 12.0 / 3.0;
                    }
                    else if (convertTo == "miles")
                    {
                        multiplier = 1.0 / 12.0 / 3.0 / 1760.0;
                    }
                    break;
                case "feet":
                    if (convertTo == "inches")
                    {
                        multiplier = 12.0;
                    }
                    else if (convertTo == "yards")
                    {
                        multiplier = 1.0 / 3.0;
                    }
                    else if (convertTo == "miles")
                    {
                        multiplier = 1.0 / 3.0 / 1760.0;
                    }
                    break;
                case "yards":
                    if (convertTo == "inches")
                    {
                        multiplier = 3.0 * 12.0;
                    }
                    else if (convertTo == "feet")
                    {
                        multiplier = 3.0;
                    }
                    else if (convertTo == "miles")
                    {
                        multiplier = 1.0 / 1760.0;
                    }
                    break;
                case "miles":
                    if (convertTo == "inches")
                    {
                        multiplier = 12.0 * 3.0 * 1760.0;
                    }
                    else if (convertTo == "yards")
                    {
                        multiplier = 1760.0;
                    }
                    else if (convertTo == "feet")
                    {
                        multiplier = 3.0 * 1760.0;
                    }
                    break;
            }

            return multiplier;
        }
    }
}
