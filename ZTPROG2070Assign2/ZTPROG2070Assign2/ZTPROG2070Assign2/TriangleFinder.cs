/*  TriangleFinder.cs
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
    public class TriangleFinder
    {
        /// <summary>
        /// Class to check triangles
        /// </summary>
        public TriangleFinder()
        {

        }

        public string Analyze(int edgeOne, int edgeTwo, int edgeThree)
        {
            string result = "";

            if (edgeOne <= 0 || edgeTwo <= 0 || edgeThree <= 0)
            {
                result = "The three integers cannot form a triangle. ";
            }
            else if ((edgeOne + edgeTwo > edgeThree) && (edgeOne + edgeThree > edgeTwo)
                    && (edgeTwo + edgeThree > edgeOne))
            {
                if (edgeOne == edgeTwo && edgeOne == edgeThree)
                {
                    result = "This is an equilateral triangle. ";
                }
                else if (edgeOne == edgeTwo || edgeOne == edgeThree || edgeTwo == edgeThree)
                {
                    result = "This is an isosceles triangle. ";
                }
                else
                {
                    result = "This is a scalene triangle. ";
                }
            }
            else
            {
                result = "The three integers cannot form a triangle. ";
            }

            return result;
        }
    }
}
