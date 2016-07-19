/*  Circle.cs
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

namespace ZTPROG2070Assign1
{
    /// <summary>
    /// Class to manage the circles
    /// </summary>
    public class Circle
    {
        public double radius;

        public Circle()
        {

        }

        public Circle(double radius)
        {
            if (radius < 0)
            {
                throw new Exception("Radius should be a double zero or higher only. ");
            }
            else
            {
                this.radius = radius;
            }
        }

        public void AddToRadius(double num)
        {
            if (radius + num < 0)
            {
                throw new Exception("Radius should be a double zero or higher only. ");
            }
            else
            {
                radius = radius + num;
            }
        }

        public void SubtractFromRadius(double num)
        {
            if (radius - num < 0)
            {
                throw new Exception("Radius should be a double zero or higher only. ");
            }
            else
            {
                radius = radius - num;
            }
        }

        public double GetCircumference()
        {
            if (radius < 0)
            {
                throw new Exception("Radius should be a double zero or higher only. ");
            }
            else
            {
                return radius * 2 * Math.PI;
            }
        }

        public double GetArea()
        {
            if (radius < 0)
            {
                throw new Exception("Radius should be a double zero or higher only. ");
            }
            else
            {
                return Math.PI * radius * radius;
            }
        }

    }
}
