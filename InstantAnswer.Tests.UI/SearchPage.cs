using System;
using OpenQA.Selenium;

namespace InstantAnswer.Tests.UI
{
    public class SearchPage
    {
        private readonly IWebDriver _driver;

        public SearchPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateTo()
        {
            _driver.Navigate().GoToUrl("http://localhost:53735/");
        }

        public void Search(string searchTerm)
        {
            _driver.FindElement(By.Id("queryTextBox")).SendKeys(searchTerm);
            _driver.FindElement(By.Id("queryButton")).Click();
        }

        public class AnswerResults
        {
            public string A1 { get; set; }
            public string A2 { get; set; }
        }

        public bool IsAnswerDisplayed()
        {
            var answerElement = _driver.FindElement(By.Id("answerAbstractText"));
            return answerElement.Displayed && !String.IsNullOrEmpty(answerElement.Text);
        }
    }
}