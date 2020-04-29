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
    public class SearchFieldSteps
    {
        private IWebDriver driver;
        [Given(@"I have go to main page of journal https://greenforest\.com\.ua/journal")]
        public void GivenIHaveGoToMainPageOfJournalHttpsGreenforest_Com_UaJournal()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://greenforest.com.ua/journal");

        }

        [Given(@"I have pressed search button")]
        public void GivenIHavePressedSearchButton()
        {
            driver.FindElement(By.CssSelector(".search .btn")).Click();
            Thread.Sleep(1000);
        }
        
        [Given(@"I entered '(.*)'")]
        public void GivenIEntered(string p0)
        {
            var field = driver.FindElement(By.CssSelector(".form input"));   //XPath("/html/body/div[2]/div[3]/div/div[3]/div/div/form/table/tbody/tr/td[1]/input"));
            field.Click();
            field.Clear();
            field.SendKeys(p0);
            field.SendKeys(Keys.Enter);
        }
        
        [When(@"I press enter")]
        public void WhenIPressEnter()
        {
            //have to search twice(
        }
        
        [Then(@"I shoud be redirected on search page")]
        public void ThenIShoudBeRedirectedOnSearchPage()
        {
            Assert.IsTrue(driver.Url.Contains("search?q="));
            driver.Close();
        }
    }
}
