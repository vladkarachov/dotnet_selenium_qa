using System;
using TechTalk.SpecFlow;
using NUnit;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [Binding]
    public class LanguageChangeSteps
    { 
        private IWebDriver driver;
        [Given(@"I go to main page")]
       
        public void GivenIGoToMainPage()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-minimized");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://greenforest.com.ua/journal");
        }
        
        [When(@"I press ukr")]
        public void WhenIPressUkr()
        {
            var languageSwitcher = driver.FindElement(By.CssSelector(" .language-switcher a"));
            if (languageSwitcher.Text.ToLower().Equals("ukr"))
            {
                languageSwitcher.Click();
            }
        }
        
        [Then(@"I shoud be redirected to ukranian version")]
        public void ThenIShoudBeRedirectedToUkranianVersion()
        {
            Assert.IsTrue(driver.Url.Contains("/ua"));
            driver.Quit();
        }
    }
}
