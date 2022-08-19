using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace VacanciesCount
{
    [TestFixture]
    public class Tests:Program
    {
        [Test]

        [TestCase(13)]
        
        public void AssertCount(int expectedCount)
        {
            string department = "Research & Development";
            string language = "English";
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(10));
            IJavaScriptExecutor Js1 = driver;
            Js1.ExecuteScript("window.scrollBy(0,300);");
            SetDeparment(driver);
            SetLanguage(driver, language);
            var actualResult = GetCountVacancies(driver);
            Assert.AreEqual(expectedCount,actualResult);
        }
        
    }
}