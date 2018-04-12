using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private string indexHtml;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            indexHtml = @"file:///" + Path.GetFullPath(Path.Combine(path, @"..\..\..\..\index.html"));
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
            driver.Navigate().GoToUrl(indexHtml);
            driver.FindElement(By.Id("phone")).Clear();
            driver.FindElement(By.Id("phone")).SendKeys("22-44-9966");
            driver.FindElement(By.Id("submitFrmNewCar")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(d => d.FindElement(By.Id("phone-error")).Text == "Invalid phone number, allowed formats are 123-123-1234 or (123)123-1234");
        }

        [Test]
        public void Assignment4_EnterInvalidEmail_ErrorMessageAppears()
        {
            driver.Navigate().GoToUrl(indexHtml);
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
            string expectedSellerName = "Rawa Jalal";
            string expectedAddress = "123 Made up Street";
            string expectedCity = "Waterloo";
            string expectedEmail = "rjalal5788@conestogac.on.ca";
            string expectedPhone = "123-123-1234";
            string expectedVehicleMake = "Subaru";
            string expectedVehicleModel = "Impreza";
            string expectedVehicleYear= "2009";
            string expectedLink = "http://www.jdpower.com/cars/Subaru/Impreza/2009";

            //act
            driver.Navigate().GoToUrl(indexHtml);
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
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Title == "Car Saved!");
            Assert.AreEqual(expectedSellerName,sellerName);
            Assert.AreEqual(expectedAddress,address);
            Assert.AreEqual(expectedCity,city);
            Assert.AreEqual(expectedPhone,phone);
            Assert.AreEqual(expectedEmail,email);
            Assert.AreEqual(expectedVehicleMake,vehicleMake);
            Assert.AreEqual(expectedVehicleModel,vehicleModel);
            Assert.AreEqual(expectedVehicleYear,vehicleYear);
        }

        [Test]
        public void Assignment4_EnterValidInformation_CorrectLinkDisplayedAndLinkWorks()
        {
            //arrange
            string expectedSellerName = "Rawa Jalal";
            string expectedAddress = "123 Made up Street";
            string expectedCity = "Waterloo";
            string expectedEmail = "rjalal5788@conestogac.on.ca";
            string expectedPhone = "123-123-1234";
            string expectedVehicleMake = "Subaru";
            string expectedVehicleModel = "Impreza";
            string expectedVehicleYear = "2009";
            string expectedLinkText = "http://www.jdpower.com/cars/Subaru/Impreza/2009";

            //act
            driver.Navigate().GoToUrl(indexHtml);
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
            string linkText = driver.FindElement(By.Id("JDLink")).Text;

            //assert
            Assert.AreEqual(expectedLinkText,linkText);
            driver.FindElement(By.Id("JDLink")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.ClassName("model-title")).Text.Contains($"{expectedVehicleYear} {expectedVehicleMake} {expectedVehicleModel}"));
        }



        [Test]
        public void Assignment4_EnterValidInformationAndSearch_CarlistPageContainsEnteredCar()
        {
            //arrange
            string expectedSellerName = "John Maloney";
            string expectedAddress = "123 Made up Street";
            string expectedCity = "Waterloo";
            string expectedEmail = "john@example.com";
            string expectedPhone = "123-123-1234";
            string expectedVehicleMake = "Honda";
            string expectedVehicleModel = "Civic";
            string expectedVehicleYear = "2016";
            string expectedLinkURL = "http://www.jdpower.com/cars/Honda/Civic/2016";

            //act
            driver.Navigate().GoToUrl(indexHtml);
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


            driver.FindElement(By.Id("carlist")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Title=="Car List");
            IEnumerable<string> linkURLs = driver.FindElements(By.ClassName("car-link")).Select(x=>x.GetAttribute("href"));

            //assert
            Assert.That(linkURLs,Has.Member(expectedLinkURL));
        }
    }
    }
