using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    class no_exception_el_checker
    {
        [Test]
        public void find_element()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://greenforest.com.ua/courses/");
            var excitance = driver.FindElements(By.Id("not_excisting_element")).Count() != 0;
            Assert.IsFalse(excitance);
        }
    }
}

