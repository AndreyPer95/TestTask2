﻿using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;


namespace VacanciesCount
{
    class Program
    {
        public static void Main(string[] args)
        {
            string department = "Research & Development";
            string language = "English";
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://cz.careers.veeam.com/vacancies");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(10));
            IJavaScriptExecutor Js1 = driver as IJavaScriptExecutor;
            Js1.ExecuteScript("window.scrollBy(0,300);");
            SetDeparment(driver, department);
            SetLanguage(driver, language);
            Console.WriteLine(GetCountVacancies(driver)); 

        }

        public static int GetCountVacancies(IWebDriver driver)
        {
            int count = driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[1]/div/div/div[2]/div"))
                .FindElements(By.TagName("h3")).Count();
            return count;
        }

        public static void SetDeparment(IWebDriver driver, string department)
        {
            var elements = driver.FindElements(By.Id("sl"));
            elements[0].Click();
            driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(15));
            var selectDepartment = driver.FindElement(By.XPath(
                "//*[@id=\"root\"]/div/div[1]/div/div/div[1]/div/div[2]/div/div/div/a[4]"));
            selectDepartment.Click();
        }

        public static void SetLanguage(IWebDriver driver, string language)
        {
            var elements = driver.FindElements(By.Id("sl"));
            elements[1].Click();
            driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(15));
            IWebElement selectLanguage = driver.FindElement(By.Id("lang-option-0"));
            selectLanguage.Click();
            elements[1].Click();
        }
    }
}
