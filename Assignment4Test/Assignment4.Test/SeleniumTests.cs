using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Assignment4.Test
{
    [TestFixture]
    public class SeleniumTests
    {
        private IWebDriver driver;
        private string baseURL;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
        }

        [TearDown]
        public void TeardownTest()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }


        [Test]
        public void Assignment4_EnterInvalidPhoneNumber_ErrorMessageAppears()
        {
            var path =
                "file:///F:/Users/Rawa/Desktop/Computer%20Programmer%20Analyst/Winter%202018/Programming%20Software%20Quality%20Assurance/Assignment4/index.html";
            driver.Navigate().GoToUrl(path);
            driver.FindElement(By.Id("phone")).Clear();
            driver.FindElement(By.Id("phone")).SendKeys("22-44-9966");
            driver.FindElement(By.Id("submitFrmNewCar")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(d => d.FindElement(By.Id("phone-error")).Text == "Invalid phone number, allowed formats are 123-123-1234 or (123)123-1234");
        }

        [Test]
        public void Assignment4_EnterInvalidEmail_ErrorMessageAppears()
        {
            var path =
                "file:///F:/Users/Rawa/Desktop/Computer%20Programmer%20Analyst/Winter%202018/Programming%20Software%20Quality%20Assurance/Assignment4/index.html";
            driver.Navigate().GoToUrl(path);
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("notanemail.com");
            driver.FindElement(By.Id("submitFrmNewCar")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.Id("email-error")).Text == "Invalid email format");
        }


        [Test]
        public void Assignment4_EnterValidInformation_DisplayEnteredDataOnNewPage()
        {
            //arrange
            var path =
                "file:///F:/Users/Rawa/Desktop/Computer%20Programmer%20Analyst/Winter%202018/Programming%20Software%20Quality%20Assurance/Assignment4/index.html";
            string expectedSellerName = "Rawa Jalal";
            string expectedAddress = "123 Made up Street";
            string expectedCity = "city";
            string expectedEmail = "rjalal5788@conestogac.on.ca";
            string expectedPhone = "123-123-1234";
            string expectedVehicleMake = "Subaru";
            string expectedVehicleModel = "Impreza";
            string expectedVehicleYear= "2009";

            //act
            driver.Navigate().GoToUrl(path);
            driver.FindElement(By.Id("sellerName")).Clear();
            driver.FindElement(By.Id("sellerName")).SendKeys(expectedSellerName);
            driver.FindElement(By.Id("address")).Clear();
            driver.FindElement(By.Id("address")).SendKeys(expectedAddress);
            driver.FindElement(By.Id("city")).Clear();
            driver.FindElement(By.Id("city")).SendKeys(expectedCity);
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys(expectedEmail);
            driver.FindElement(By.Id("phone")).Clear();
            driver.FindElement(By.Id("phone")).SendKeys(expectedPhone);
            driver.FindElement(By.Id("vehicleMake")).Clear();
            driver.FindElement(By.Id("vehicleMake")).SendKeys(expectedVehicleMake);
            driver.FindElement(By.Id("vehicleModel")).Clear();
            driver.FindElement(By.Id("vehicleModel")).SendKeys(expectedVehicleModel);
            driver.FindElement(By.Id("vehicleYear")).Clear();
            driver.FindElement(By.Id("vehicleYear")).SendKeys(expectedVehicleYear);
            driver.FindElement(By.Id("submitFrmNewCar")).Click();

            string sellerName = driver.FindElement(By.Id("sellerName")).Text;
            string address = driver.FindElement(By.Id("address")).Text;
            string city = driver.FindElement(By.Id("city")).Text;
            string email = driver.FindElement(By.Id("email")).Text;
            string phone = driver.FindElement(By.Id("phone")).Text;
            string vehicleMake = driver.FindElement(By.Id("vehicleMake")).Text;
            string vehicleModel = driver.FindElement(By.Id("vehicleModel")).Text;
            string vehicleYear = driver.FindElement(By.Id("vehicleYear")).Text;

            //assert
            Assert.AreEqual(expectedSellerName,sellerName);
            Assert.AreEqual(expectedAddress,address);
            Assert.AreEqual(expectedCity,city);
            Assert.AreEqual(expectedPhone,phone);
            Assert.AreEqual(expectedEmail,email);
            Assert.AreEqual(expectedVehicleMake,vehicleMake);
            Assert.AreEqual(expectedVehicleModel,vehicleModel);
            Assert.AreEqual(expectedVehicleYear,vehicleYear);
        }
    }
}
