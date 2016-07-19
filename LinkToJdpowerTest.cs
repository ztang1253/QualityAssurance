/*  LinkToJdpowerTest.cs
 *  Assignment 4
 * 
 *  Revision History
 *      Zhenzhen Tang, 2016.03.23: Created
 */

using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace ZTPROG2070Assign4.Test
{
    /// <summary>
    /// Class to test the whole website, car info validation, 
    /// link to jdpower.com, show car list, etc.
    /// </summary>
    [TestFixture]
    public class LinkToJdpowerTest
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;

        private string newFormTitle;
        private string sellerName;
        private string address;
        private string city;
        private string phoneNumber;
        private string email;
        private string vehicleMake;
        private string model;
        private string year;

        private string sellerNameRequiredMessage;
        private string addressRequiredMessage;
        private string cityRequiredMessage;
        private string phoneRequiredMessage;
        private string phoneFormatError;
        private string emailRequiredMessage;
        private string vehicleMakeRequiredMessage;
        private string modelRequiredMessage;
        private string yearRequiredMessage;


        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http:////127.0.0.1:8383";
            verificationErrors = new StringBuilder();

            newFormTitle = "Enter the Car Information";
            sellerName = "ztang";
            address = "299 Doon Valley Drive";
            city = "kitchener";
            phoneNumber = "519-748-5220";
            email = "ztang1253@conestogac.on.ca";
            //vehicleMake = "BMW";
            //model = "X5";
            //year = "2009";
            vehicleMake = "Chrysler";
            model = "Town & Country";
            year = "2015";
            //vehicleMake = "Ford";
            //model = "F-150";
            //year = "2013";

            sellerNameRequiredMessage = "Seller Name is required.";
            addressRequiredMessage = "Address is required.";
            cityRequiredMessage = "City is required.";
            phoneRequiredMessage = "Phone Number is required.";
            phoneFormatError = "Phone Number is invalid. " +
                    "Please enter valid phone number like 123-123-1234 or (123)123-1234.";
            emailRequiredMessage = "Email Address is required.";
            vehicleMakeRequiredMessage = "Vehicle Make is required.";
            modelRequiredMessage = "Model is required.";
            yearRequiredMessage = "Year is required.";

        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void EnterNewCarInfo_AllCorrectInput_ShouldShowInfoAndFindCarOnJdpower()
        {
            driver.Navigate().GoToUrl(baseURL + "/ZTPROG2070Assign4/index.html");

            driver.FindElement(By.LinkText("New")).Click();
            driver.FindElement(By.Id("sellerName")).Clear();
            driver.FindElement(By.Id("sellerName")).SendKeys(sellerName);
            driver.FindElement(By.Id("address")).Clear();
            driver.FindElement(By.Id("address")).SendKeys(address);
            driver.FindElement(By.Id("city")).Clear();
            driver.FindElement(By.Id("city")).SendKeys(city);
            driver.FindElement(By.Id("phoneNumber")).Clear();
            driver.FindElement(By.Id("phoneNumber")).SendKeys(phoneNumber);
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys(email);
            driver.FindElement(By.Id("vehicleMake")).Clear();
            driver.FindElement(By.Id("vehicleMake")).SendKeys(vehicleMake);
            driver.FindElement(By.Id("model")).Clear();
            driver.FindElement(By.Id("model")).SendKeys(model);
            driver.FindElement(By.Id("year")).Clear();
            driver.FindElement(By.Id("year")).SendKeys(year);
            driver.FindElement(By.Id("btnSave")).Click();
            Assert.AreEqual(sellerName, 
                    driver.FindElement(By.Id("sellerNameSaved")).GetAttribute("value"));
            Assert.AreEqual(address, 
                    driver.FindElement(By.Id("addressSaved")).GetAttribute("value"));
            Assert.AreEqual(city, 
                    driver.FindElement(By.Id("citySaved")).GetAttribute("value"));
            Assert.AreEqual(phoneNumber, 
                    driver.FindElement(By.Id("phoneNumberSaved")).GetAttribute("value"));
            Assert.AreEqual(email, 
                    driver.FindElement(By.Id("emailSaved")).GetAttribute("value"));
            Assert.AreEqual(vehicleMake, 
                    driver.FindElement(By.Id("vehicleMakeSaved")).GetAttribute("value"));
            Assert.AreEqual(model, 
                    driver.FindElement(By.Id("modelSaved")).GetAttribute("value"));
            Assert.AreEqual(year, 
                    driver.FindElement(By.Id("yearSaved")).GetAttribute("value"));
            Assert.AreEqual("Link for the car " + year + "-" + 
                    vehicleMake + "-" + model + " on www.jdpower.com",
                    driver.FindElement(By.Id("carLink")).Text);

            string carURL = driver.FindElement(By.Id("carLink")).GetAttribute("href");
            driver.Navigate().GoToUrl(carURL);
            Assert.AreEqual(year + " " + vehicleMake + " " + model,
                    driver.FindElement(By.ClassName("car-title")).Text);

            // Yesterday I tried this below and it did did did did work!!!!!! Why this does not work now ?????????
            // 1 minute after!!! because I just changed the link <a> to open in a new blank window!!!!!
            // <a target="_blank"!!!!!!!!!!!!! So the code below does not work as yesterday!!!
            // wahahahahahahahahahahahahahaaaaaaaaaaaaaaaaaaaaaaaaa
            //driver.FindElement(By.Id("carLink")).Click();
            //Assert.AreEqual(year + " " + vehicleMake + " " + model,
            //        driver.FindElement(By.ClassName("car-title")).Text);

            //driver.FindElement(By.Id("edit-submit-cars-search")).Click();
            //System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
        }

        [Test]
        public void EnterNewCarInfo_EmptyInput_ShouldShowCustomErrorsMsgAndStaySamePage()
        {
            // Arrange
            sellerName = "";
            address = "";
            city = "";
            phoneNumber = "";
            email = "";
            vehicleMake = "";
            model = "";
            year = "";

            // Act
            driver.Navigate().GoToUrl(baseURL + "/ZTPROG2070Assign4/index.html");
            driver.FindElement(By.LinkText("New")).Click();
            driver.FindElement(By.Id("sellerName")).Clear();
            driver.FindElement(By.Id("sellerName")).SendKeys(sellerName);
            driver.FindElement(By.Id("address")).Clear();
            driver.FindElement(By.Id("address")).SendKeys(address);
            driver.FindElement(By.Id("city")).Clear();
            driver.FindElement(By.Id("city")).SendKeys(city);
            driver.FindElement(By.Id("phoneNumber")).Clear();
            driver.FindElement(By.Id("phoneNumber")).SendKeys(phoneNumber);
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys(email);
            driver.FindElement(By.Id("vehicleMake")).Clear();
            driver.FindElement(By.Id("vehicleMake")).SendKeys(vehicleMake);
            driver.FindElement(By.Id("model")).Clear();
            driver.FindElement(By.Id("model")).SendKeys(model);
            driver.FindElement(By.Id("year")).Clear();
            driver.FindElement(By.Id("year")).SendKeys(year);
            driver.FindElement(By.Id("btnSave")).Click();

            // Assert
            Assert.AreEqual(sellerNameRequiredMessage, 
                    driver.FindElement(By.Id("sellerName-error")).Text);
            Assert.AreEqual(addressRequiredMessage, 
                    driver.FindElement(By.Id("address-error")).Text);
            Assert.AreEqual(cityRequiredMessage, 
                    driver.FindElement(By.Id("city-error")).Text);
            Assert.AreEqual(phoneRequiredMessage, 
                    driver.FindElement(By.Id("phoneNumber-error")).Text);
            Assert.AreEqual(emailRequiredMessage, 
                    driver.FindElement(By.Id("email-error")).Text);
            Assert.AreEqual(vehicleMakeRequiredMessage, 
                    driver.FindElement(By.Id("vehicleMake-error")).Text);
            Assert.AreEqual(modelRequiredMessage, 
                    driver.FindElement(By.Id("model-error")).Text);
            Assert.AreEqual(yearRequiredMessage, 
                    driver.FindElement(By.Id("year-error")).Text);

            Assert.AreEqual(newFormTitle, driver.FindElement(By.TagName("h2")).Text);
        }

        [Test]
        public void EnterNewCarInfo_WrongYear_ShouldCatchSeleniumNoSuchElementException()
        {
            // Arrange
            year = "1900";

            // Act
            driver.Navigate().GoToUrl(baseURL + "/ZTPROG2070Assign4/index.html");
            driver.FindElement(By.LinkText("New")).Click();
            driver.FindElement(By.Id("sellerName")).Clear();
            driver.FindElement(By.Id("sellerName")).SendKeys(sellerName);
            driver.FindElement(By.Id("address")).Clear();
            driver.FindElement(By.Id("address")).SendKeys(address);
            driver.FindElement(By.Id("city")).Clear();
            driver.FindElement(By.Id("city")).SendKeys(city);
            driver.FindElement(By.Id("phoneNumber")).Clear();
            driver.FindElement(By.Id("phoneNumber")).SendKeys(phoneNumber);
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys(email);
            driver.FindElement(By.Id("vehicleMake")).Clear();
            driver.FindElement(By.Id("vehicleMake")).SendKeys(vehicleMake);
            driver.FindElement(By.Id("model")).Clear();
            driver.FindElement(By.Id("model")).SendKeys(model);
            driver.FindElement(By.Id("year")).Clear();
            driver.FindElement(By.Id("year")).SendKeys(year);
            driver.FindElement(By.Id("btnSave")).Click();

            // Assert
            Assert.AreEqual(sellerName,
                    driver.FindElement(By.Id("sellerNameSaved")).GetAttribute("value"));
            Assert.AreEqual(address,
                    driver.FindElement(By.Id("addressSaved")).GetAttribute("value"));
            Assert.AreEqual(city,
                    driver.FindElement(By.Id("citySaved")).GetAttribute("value"));
            Assert.AreEqual(phoneNumber,
                    driver.FindElement(By.Id("phoneNumberSaved")).GetAttribute("value"));
            Assert.AreEqual(email,
                    driver.FindElement(By.Id("emailSaved")).GetAttribute("value"));
            Assert.AreEqual(vehicleMake,
                    driver.FindElement(By.Id("vehicleMakeSaved")).GetAttribute("value"));
            Assert.AreEqual(model,
                    driver.FindElement(By.Id("modelSaved")).GetAttribute("value"));
            Assert.AreEqual(year,
                    driver.FindElement(By.Id("yearSaved")).GetAttribute("value"));
            Assert.AreEqual("Link for the car " + year + "-" +
                vehicleMake + "-" + model + " on www.jdpower.com",
                    driver.FindElement(By.Id("carLink")).Text);

            string carURL = driver.FindElement(By.Id("carLink")).GetAttribute("href");
            driver.Navigate().GoToUrl(carURL);

            try
            {
                driver.FindElement(By.Id("edit-submit-cars-search"));
            }
            catch (Exception)
            {
                Assert.Fail("Link for the car does not work. ");
            }

            try
            {
                driver.FindElement(By.ClassName("car-title"));
            }
            catch (OpenQA.Selenium.NoSuchElementException)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test]
        public void EnterNewCarInfo_WrongFormatPhone_ShouldShowPhoneFormatError()
        {
            // Arrange
            phoneNumber = "1231231234";

            // Act
            driver.Navigate().GoToUrl(baseURL + "/ZTPROG2070Assign4/index.html");
            driver.FindElement(By.LinkText("New")).Click();
            driver.FindElement(By.Id("sellerName")).Clear();
            driver.FindElement(By.Id("sellerName")).SendKeys(sellerName);
            driver.FindElement(By.Id("address")).Clear();
            driver.FindElement(By.Id("address")).SendKeys(address);
            driver.FindElement(By.Id("city")).Clear();
            driver.FindElement(By.Id("city")).SendKeys(city);
            driver.FindElement(By.Id("phoneNumber")).Clear();
            driver.FindElement(By.Id("phoneNumber")).SendKeys(phoneNumber);
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys(email);
            driver.FindElement(By.Id("vehicleMake")).Clear();
            driver.FindElement(By.Id("vehicleMake")).SendKeys(vehicleMake);
            driver.FindElement(By.Id("model")).Clear();
            driver.FindElement(By.Id("model")).SendKeys(model);
            driver.FindElement(By.Id("year")).Clear();
            driver.FindElement(By.Id("year")).SendKeys(year);
            driver.FindElement(By.Id("btnSave")).Click();

            // Assert
            Assert.AreEqual(phoneFormatError,
                driver.FindElement(By.Id("phoneNumber-error")).Text);
        }

        [Test]
        public void Search_EnterValidData_ShouldShowAllCarsInfo()
        {
            driver.Navigate().GoToUrl(baseURL + "/ZTPROG2070Assign4/index.html");

            int total = 10;
            for (int i = 0; i < total; i++)
            {
                year = "200" + i;
                vehicleMake = "BMW" + i;
                model = "X3" + i;
                driver.FindElement(By.LinkText("New")).Click();
                driver.FindElement(By.Id("sellerName")).Clear();
                driver.FindElement(By.Id("sellerName")).SendKeys(sellerName);
                driver.FindElement(By.Id("address")).Clear();
                driver.FindElement(By.Id("address")).SendKeys(address);
                driver.FindElement(By.Id("city")).Clear();
                driver.FindElement(By.Id("city")).SendKeys(city);
                driver.FindElement(By.Id("phoneNumber")).Clear();
                driver.FindElement(By.Id("phoneNumber")).SendKeys(phoneNumber);
                driver.FindElement(By.Id("email")).Clear();
                driver.FindElement(By.Id("email")).SendKeys(email);
                driver.FindElement(By.Id("vehicleMake")).Clear();
                driver.FindElement(By.Id("vehicleMake")).SendKeys(vehicleMake);
                driver.FindElement(By.Id("model")).Clear();
                driver.FindElement(By.Id("model")).SendKeys(model);
                driver.FindElement(By.Id("year")).Clear();
                driver.FindElement(By.Id("year")).SendKeys(year);
                driver.FindElement(By.Id("btnSave")).Click();
                driver.FindElement(By.Id("homeLink")).Click();
                driver.FindElement(By.Id("searchLink")).Click();

                Assert.AreEqual("Link for the car " + year + "-" +
                        vehicleMake + "-" + model + " on www.jdpower.com",
                        driver.FindElement(By.Id("lastCarLink")).Text);
                driver.FindElement(By.Id("homeLink")).Click();
            }
        }
    }
}
