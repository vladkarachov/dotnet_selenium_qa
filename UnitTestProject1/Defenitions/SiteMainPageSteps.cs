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
    public class SiteMainPageSteps
    {
        private IWebDriver driver;
        private int number_of_el;
        [Given(@"I have go to the main page https://greenforest\.com\.ua/journal")]
        public void GivenIHaveGoToTheMainPageHttpsGreenforest_Com_UaJournal()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://greenforest.com.ua/journal/");

        }

        [When(@"I press grammar")]
        public void WhenIPressGrammar()
        {
            driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div/div[3]/ul/li[1]/a")).Click();
        }
        
        [When(@"I press Читать далее")]
        public void WhenIPressЧитатьДалее()
        {
            Thread.Sleep(3000);
            number_of_el = driver.FindElements(By.CssSelector(".journal-page > div")).Count;
            driver.FindElement(By.ClassName("read-more-button")).Click();
        }
        
        [Then(@"I should see grammar web page")]
        public void ThenIShouldSeeGrammarWebPage()
        {
            Assert.IsTrue(driver.Url.Contains("grammar"));
            driver.Close();
        }
        
        [Then(@"I should get new articles")]
        public void ThenIShouldGetNewArticles()
        {
            Thread.Sleep(1000);
            var current_num_of_el= driver.FindElements(By.CssSelector(".journal-page > div")).Count;
            Assert.IsTrue(current_num_of_el > number_of_el);
            driver.Close();
        }
    }
}
