using NUnit.Framework;
using OpenQA.Selenium;


namespace VacanciesCount
{
    [TestFixture]
    public class Tests 
    {
        [Test]
        public void AssertCount()
        {
            int expectcount = 5; 
            //int realcount = vacanciesPage.GetCountVacancies("Research & Development");
            //Assert.AreEqual(expectcount, realcount);
        }

    }
}