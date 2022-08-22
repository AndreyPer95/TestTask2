using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;


namespace VacanciesCount
{
    public class VacancySearcher
    {
        public const string URL = "https://cz.careers.veeam.com/vacancies";

        public IWebDriver driver = new ChromeDriver();

        public static string[] departments = new string[]
        {
            "All Departments",
            "Corporate Information Systems",
            "Quality Assurance",
            "Research & Development",
            "TechnicalCustomerSupport",
            "IT",
            "Other",
            "HR",
            "TechnicalDocumentationDevelopment",
            "ProductManagement",
            "Finance",
            "Facilities",
            "Purchasing",
            "Legal"
        };
        public static string[] languages = new string[]
        {
            "English",
            "Russian",
            "French",
            "German"
        };

        public VacancySearcher()
        {
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(10));
            IJavaScriptExecutor Js1 = driver as IJavaScriptExecutor;
            Js1.ExecuteScript("window.scrollBy(0,300);");
        }

        public int GetVacanciesCount()
        {
            var elements = driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[1]/div/div/div[2]/div"))
                .FindElements(By.TagName("h3"));
            if (String.Equals(elements[0].Text, "No matches were found for your query :(")) return 0;
            return elements.Count();
        }

        public void SetDeparment(string department)
        {
            var elements = driver.FindElements(By.Id("sl"));
            elements[0].Click();
            driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(15));
            var departmentIndex = GetDepartmentIndex(department);
            var selectDepartment = driver.FindElement(By.XPath(
                $"//*[@id=\"root\"]/div/div[1]/div/div/div[1]/div/div[2]/div/div/div/a[{(departmentIndex)}]"));
            selectDepartment.Click();
        }

        public void SetLanguage(string language)
        {
            var elements = driver.FindElements(By.Id("sl"));
            elements[1].Click();
            driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(15));
            var languageIndex = GetLanguageIndex(language);
            var selectLanguage = driver.FindElement(By.Id($"lang-option-{languageIndex}"));
            selectLanguage.Click();
            elements[1].Click();
        }

        private int GetDepartmentIndex(string department)
        {
            //нумерация отделов на сайте начинается с 1
            return Array.IndexOf(departments, department) + 1;
        }

        private int GetLanguageIndex(string language)
        {
            return Array.IndexOf(languages, language);
        }
    }
}
