using System;
using OpenQA.Selenium;

namespace GOTPlaner.Tests
{
    public class RegistrationPage
    {
        private readonly IWebDriver _driver;
        private const string url = "https://localhost:44354/Identity/Account/Register";

        private IWebElement _name => _driver.FindElement(By.Id("name"));
        private IWebElement _last_name => _driver.FindElement(By.Id("last_name"));
        private IWebElement _birthdate => _driver.FindElement(By.Id("birthdate"));
        private IWebElement _email => _driver.FindElement(By.Id("email"));
        private IWebElement _pass => _driver.FindElement(By.Id("password"));
        private IWebElement _create => _driver.FindElement(By.Id("create"));

        public string source => _driver.PageSource;
        public string errorMessage => _driver.FindElement(By.XPath("//div[@class='text-danger validation-summary-errors']//ul//li")).Text;

        public RegistrationPage(IWebDriver driver) => _driver = driver;
        
        public void Navigate() => _driver.Navigate().GoToUrl(url);

        public void setName(string name) => _name.SendKeys(name);
        public void setLastName(string lastname) => _last_name.SendKeys(lastname);
        public void setBirthDate(DateTime birth) => _birthdate.SendKeys(birth.Date.ToString());
        public void setEmail(string email) => _email.SendKeys(email);
        public void setPassword(string password) => _pass.SendKeys(password);
        public void ClickCreate() => _create.Click();
    }
}
