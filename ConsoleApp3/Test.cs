using NUnit.Framework;

namespace VacanciesCount
{
    [TestFixture]
    public class Tests
    {
        [TestCase("Research & Development", "English", 12)]       //можно взять название любого отдела
        [TestCase("Corporate Information Systems", "German", 0)]  //и любой язык из соответствующего списка
        public void AssertCount(string department, string language, int expectedCount)
        {
            var searcher = new VacancySearcher();
            searcher.SetDeparment(department);
            searcher.SetLanguage(language);
            var actualResult = searcher.GetVacanciesCount();
            Assert.AreEqual(expectedCount,actualResult);
            searcher.driver.Close();
        }
    }
}