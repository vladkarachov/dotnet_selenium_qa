using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Reflection;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Threading;

namespace UnitTestProject1
{
    [Binding]
 //   [TestClass]
    public class CoursesSelectionSteps
    {
        // IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        private IWebDriver driver;
        [Given(@"I have go to courses selection page https://greenforest\.com\.ua/courses/")]
 //       [Test]
        public void GivenIHaveGoToCoursesSelectionPageHttpsGreenforest_Com_UaCourses()
        {
           
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://greenforest.com.ua/courses/");
            
        }
        
        [When(@"change my city to '(.*)'")]
        public void WhenChangeMyCityTo(string p0)
        {
            //on first start you automatically have to select city
            // driver.FindElement(By.Id("cities-switch")).Click();
            Thread.Sleep(1000);
        
            var cities = driver.FindElements(By.CssSelector(@".cities-popup .inner ul li"));
            foreach (var city in cities)
            {
                if (city.Text.Trim().ToLower().Equals(p0.ToLower()))
                {
                    city.Click();
                    break;
                }
            }
            //driver.FindElement(By.XPath(@"/html/body/div[1]/div/ul/li[1]/a")).Click();

        }
        
        [When(@"i press ""(.*)""")]
        public void WhenIPress(string p0)
        {
            //actualy page is piece of trash - you can just scroll through city selection dialog)))
            Thread.Sleep(1000);
            driver.FindElement(By.ClassName(@"reg-button")).Click();
        }
        
        [When(@"im not authorized")]
        public void WhenImNotAuthorized()
        {
            //by default you are not authorized
        }
        
        [Then(@"i am redirected to my '(.*)' page")]
        public void ThenIAmRedirectedToMyPage(string p0)
        {
            var currcity = driver.FindElement(By.CssSelector(@".cities-switch a")).Text;
            NUnit.Framework.Assert.IsTrue(currcity.ToLower().Contains(p0.ToLower()));
            driver.Quit();
        }
        
        [Then(@"I redirected to login page")]
        public void ThenIRedirectedToLoginPage()
        {

            var windows = driver.WindowHandles[1];
            driver.SwitchTo().Window(windows);
            Assert.IsTrue(driver.Url.Contains(@"my.greenforest"));
            driver.Quit();
        }
    }
}
