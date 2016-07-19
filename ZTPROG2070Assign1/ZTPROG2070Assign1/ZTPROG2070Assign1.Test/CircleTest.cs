/*  CircleTest.cs
 *  Assignment 1
 * 
 *  Revision History
 *      Zhenzhen Tang, 2016.02.02: Created
 */

using NUnit.Framework;
using System;

namespace ZTPROG2070Assign1.Test
{
    /// <summary>
    /// Class to test the methods in Circle class
    /// </summary>
    public class CircleTest
    {
        private double previousRadius;
        private double radius;
        private double inputNumber;
        private double circumference;
        private double area;
        private Circle circle;

        [SetUp]
        public void SetUp()
        {
            previousRadius = 0d;
            radius = 0d;
            inputNumber = 0d;
            circumference = 0d;
            area = 0d;
            circle = new Circle(radius);
        }

        [TearDown]
        public void CleanUp()
        {
            previousRadius = 0d;
            radius = 0d;
            inputNumber = 0d;
            circumference = 0d;
            area = 0d;
            circle = null;
        }

        #region Test Non-default Constructor
        [Test]
        public void NonDefaultConstructor_Input0_ShouldWork()
        {
            // Arrange
            radius = 0;

            // Act
            try
            {
                circle = new Circle(radius);
            }

            // Assert
            catch (Exception)
            {
                Assert.Fail();
            }

            Assert.AreEqual(circle.radius, 0);
        }

        [Test]
        public void NonDefaultConstructor_InputMinus1_ShouldThrowException()
        {
            // Arrange
            radius = -1.0;

            // Act
            try
            {
                circle = new Circle(radius);
            }

            // Assert
            catch (Exception ex)
            {
                if (ex.Message == "Radius should be a double zero or higher only. ")
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail();
                }
            }

            Assert.Fail();
        }
        #endregion

        #region Test AddToRadius
        [Test]
        public void AddToRadius_Input0_RadiusDoesNotChange()
        {
            // Arrange
            inputNumber = 0;
            circle.radius = 99999999.99;
            previousRadius = circle.radius;

            // Act
            circle.AddToRadius(inputNumber);

            // Assert
            Assert.AreEqual(previousRadius, circle.radius);
        }

        [Test]
        public void AddToRadius_InputMinusNumberToMakeRadiusLessThan0_ShouldThrowException()
        {
            // Arrange
            inputNumber = -999999999;
            circle.radius = 1;

            // Act
            try
            {
                circle.AddToRadius(inputNumber);
            }

            // Assert
            catch (Exception ex)
            {
                if (ex.Message == "Radius should be a double zero or higher only. ")
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail();
                }
            }

            Assert.Fail();
        }
        #endregion

        #region Test SubtractFromRadius
        [Test]
        public void SubtractFromRadius_Input0_RadiusDoesNotChange()
        {
            // Arrange
            inputNumber = 0;
            circle.radius = 0.00000001;
            previousRadius = circle.radius;

            // Act
            circle.SubtractFromRadius(inputNumber);

            // Assert
            Assert.AreEqual(previousRadius, circle.radius);
        }

        [Test]
        public void SubtractFromRadius_InputNumberToMakeRadiusLessThan0_ShouldThrowException()
        {
            // Arrange
            inputNumber = 0.00000002;
            circle.radius = 0.00000001;

            // Act
            try
            {
                circle.SubtractFromRadius(inputNumber);
            }

            // Assert
            catch (Exception ex)
            {
                if (ex.Message == "Radius should be a double zero or higher only. ")
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail();
                }
            }

            Assert.Fail();
        }
        #endregion

        #region Test GetCircumference
        [Test]
        public void GetCircumference_RadiusIs0_ResultIs0()
        {
            // Arrange
            circle.radius = 0;

            // Act
            circumference = circle.GetCircumference();

            // Assert
            Assert.AreEqual(circumference, 0);
        }

        [Test]
        public void GetCircumference_RadiusIsPoint00000001_ShouldPass()
        {
            // Arrange
            circle.radius = 0.00000001d;

            // Act
            circumference = circle.GetCircumference();

            // Assert
            Assert.AreEqual(2 * Math.PI * 0.00000001d, circle.GetCircumference());
        }
        #endregion

        #region Test GetArea
        [Test]
        public void GetArea_RadiusIs0_ResultIs0()
        {
            // Arrange
            circle.radius = 0;

            // Act
            area = circle.GetArea();

            // Assert
            Assert.AreEqual(area, 0);
        }

        [Test]
        public void GetArea_RadiusIsMinus1_ShouldThrowException()
        {
            // Arrange
            circle.radius = -1;

            // Act
            try
            {
                area = circle.GetArea();
            }

            // Assert
            catch (Exception ex)
            {
                if (ex.Message == "Radius should be a double zero or higher only. ")
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail();
                }
            }

            Assert.Fail();
        }
        #endregion

    }
}