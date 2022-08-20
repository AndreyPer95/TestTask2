using NUnit.Framework;

namespace VacanciesCount
{
    [TestFixture]
    public class Tests
    {
        [TestCase("Research & Development", "English", 13)]
        [TestCase("Corporate Information Systems", "English", 14)]
        public void AssertCount(string department, string language, int expectedCount)
        {
            var searcher = new VacancySearcher();
            searcher.SetDeparment(department);
            searcher.SetLanguage(language);
            var actualResult = searcher.GetVacanciesCount();
            Assert.AreEqual(expectedCount,actualResult);
        }
        
    }
}