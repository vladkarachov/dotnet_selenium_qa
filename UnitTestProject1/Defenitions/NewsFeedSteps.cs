using System;
using TechTalk.SpecFlow;
using NUnit;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace UnitTestProject1
{
    [Binding]
    public class NewsFeedSteps
    {
        private IWebDriver driver;
        [Given(@"I opened main page of journal https://greenforest\.com\.ua/ua/journal")]
        public void GivenIOpenedMainPageOfJournalHttpsGreenforest_Com_UaUaJournal()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://greenforest.com.ua/ua/journal/");

        }

        [Given(@"I have selected a '(.*)'")]
        public void GivenIHaveSelectedA(string p0)
        {
            var categories = driver.FindElements(By.CssSelector(@".categories li"));
            foreach (var category in categories)
            {
                if (category.Text.Trim().ToLower().Equals(p0.ToLower()))
                {
                    category.Click();
                    break;
                }
            }
        }
        
        [When(@"I press next page")]
        public void WhenIPressNextPage()
        {
            Thread.Sleep(500);
            driver.FindElement(By.CssSelector(@".green-pagination li a")).Click();
        }
        
        [Then(@"next page is opened")]
        public void ThenNextPageIsOpened()
        {
            //новостная лента полный кошмар
            Assert.IsTrue(driver.Url.Contains("page/"));
            driver.Close();
        }
    }
}
