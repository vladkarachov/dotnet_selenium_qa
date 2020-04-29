using System;
using TechTalk.SpecFlow;
using NUnit;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [Binding]
    public class WriteusSteps
    {
        private IWebDriver driver;
        [Given(@"I opened https://greenforest\.com\.ua/ua/journal")]
        public void GivenIOpenedHttpsGreenforest_Com_UaUaJournal()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://greenforest.com.ua/journal/");

        }

        [When(@"I press написать нам")]
        public void WhenIPressНаписатьНам()
        {
            driver.FindElement(By.CssSelector(".letter")).Click();
        }
        
        [Then(@"letter form becomes visible")]
        public void ThenLetterFormBecomesVisible()
        {
            var letterForm = driver.FindElement(By.Id("letter_form"));
            Assert.IsTrue(letterForm.Displayed);
            driver.Close();
        }
    }
}
