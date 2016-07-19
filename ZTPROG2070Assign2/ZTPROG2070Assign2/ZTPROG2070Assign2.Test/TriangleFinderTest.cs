/*  TriangleFinderTest.cs
 *  Assignment 2
 * 
 *  Revision History
 *      Zhenzhen Tang, 2016.02.09: Created
 */

using NUnit.Framework;
using System;

namespace ZTPROG2070Assign2.Test
{
    /// <summary>
    /// Class to test the methods in TriangleFinder class
    /// </summary>
    [TestFixture]
    public class TriangleFinderTest
    {
        private string resultNotTriangle;
        private string resultIsScalene;
        private string resultIsIsosceles;
        private string resultIsEquilateral;
        private string returnString;
        private int edgeOne;
        private int edgeTwo;
        private int edgeThree;
        private TriangleFinder triangle;

        [SetUp]
        public void SetUp()
        {
            resultNotTriangle = "The three integers cannot form a triangle. ";
            resultIsScalene = "This is a scalene triangle. ";
            resultIsIsosceles = "This is an isosceles triangle. ";
            resultIsEquilateral = "This is an equilateral triangle. ";
            triangle = new TriangleFinder();
        }

        [TearDown]
        public void CleanUp()
        {
            resultNotTriangle = "";
            resultIsScalene = "";
            resultIsIsosceles = "";
            resultIsEquilateral = "";
            edgeOne = 0;
            edgeTwo = 0;
            edgeThree = 0;
            triangle = null;
        }

        [Test]
        public void Analyze_InputIntegersLessThan0_ReturnStringShouldBeNotTriangle()
        {
            // Arrange
            edgeOne = -1;
            edgeTwo = 5;
            edgeThree = 6;

            // Act
            returnString = triangle.Analyze(edgeOne, edgeTwo, edgeThree);

            // Assert
            if (resultNotTriangle.Equals(returnString))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void Analyze_InputOneEdgeAs0_ReturnStringShouldBeNotTriangle()
        {
            // Arrange
            edgeOne = 1;
            edgeTwo = 0;
            edgeThree = 2;

            // Act
            returnString = triangle.Analyze(edgeOne, edgeTwo, edgeThree);

            // Assert
            if (resultNotTriangle.Equals(returnString))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void Analyze_InputThreeSameNumbers_ReturnStringShouldBeEquilateral()
        {
            // Arrange
            edgeOne = 3;
            edgeTwo = 3;
            edgeThree = 3;

            // Act
            returnString = triangle.Analyze(edgeOne, edgeTwo, edgeThree);

            // Assert
            if (resultIsEquilateral.Equals(returnString))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void Analyze_InputTwoSameNumbersSumLargerThanThirdNumber_ReturnStringShouldBeIsosceles()
        {
            // Arrange
            edgeOne = 6;
            edgeTwo = 6;
            edgeThree = 8;

            // Act
            returnString = triangle.Analyze(edgeOne, edgeTwo, edgeThree);

            // Assert
            if (resultIsIsosceles.Equals(returnString))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void Analyze_InputTwoSameNumbersSumLessThanThirdNumber_ReturnStringShouldBeNotTriangle()
        {
            // Arrange
            edgeOne = 7;
            edgeTwo = 7;
            edgeThree = 14;

            // Act
            returnString = triangle.Analyze(edgeOne, edgeTwo, edgeThree);

            // Assert
            if (resultNotTriangle.Equals(returnString))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void 
            Analyze_InputTwoDifferentNumbersSumLessThanThirdNumber_ReturnStringShouldBeNotTriangle()
        {
            // Arrange
            edgeOne = 9999999;
            edgeTwo = 999999;
            edgeThree = 10999999;

            // Act
            returnString = triangle.Analyze(edgeOne, edgeTwo, edgeThree);

            // Assert
            if (resultNotTriangle.Equals(returnString))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
        
        [Test]
        public void Analyze_InputTwoDifferentNumbersSumEqualsThirdNumber_ReturnStringShouldBeNotTriangle()
        {
            // Arrange
            edgeOne = 99999999;
            edgeTwo = 9999999;
            edgeThree = 109999998;

            // Act
            returnString = triangle.Analyze(edgeOne, edgeTwo, edgeThree);

            // Assert
            if (resultNotTriangle.Equals(returnString))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
        
        [Test]
        public void Analyze_InputTwoDifferentNumbersSumLargerThanThirdNumber_ReturnStringShouldBeScalene()
        {
            // Arrange
            edgeOne = 2;
            edgeTwo = 3;
            edgeThree = 4;

            // Act
            returnString = triangle.Analyze(edgeOne, edgeTwo, edgeThree);

            // Assert
            if (resultIsScalene.Equals(returnString))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

    }
}
