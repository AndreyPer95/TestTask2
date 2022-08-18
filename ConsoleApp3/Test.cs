using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace VacanciesCount
{
    [TestFixture]
    public class Tests:Program
    {
        [Test]

        [TestCase(12)]
        
        public void AssertCount(int expectedCount)
        {
            driver = new ChromeDriver();
            var actualResult = GetCountVacancies(driver);
            Assert.AreEqual(expectedCount,actualResult);
        }
        
    }
}