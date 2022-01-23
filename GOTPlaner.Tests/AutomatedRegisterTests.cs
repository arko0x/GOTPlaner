using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using GOTPlaner.Data;
using Microsoft.EntityFrameworkCore;

namespace GOTPlaner.Tests
{
    public class AutomatedRegisterTests : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly RegistrationPage _page;

        public AutomatedRegisterTests()
        {
            _driver = new ChromeDriver();
            _page = new RegistrationPage(_driver);
            _page.Navigate();
        }

        [Fact]
        public void Create_WrongDateInput_ReturnsError()
        {
            _page.setName("Janusz");
            _page.setLastName("Piechociñski");
            _page.setBirthDate(DateTime.Now.Date);
            _page.setEmail("testTourist@localhost");
            _page.setPassword("Password12");

            _page.ClickCreate();

            Assert.Contains("You have to be at least 7 years old to register", _page.source);
        }

        [Fact]
        public void Create_WrongEmailPattern_ReturnError()
        {
            _page.setName("Janusz");
            _page.setLastName("Piechociñski");
            _page.setBirthDate(DateTime.Now.AddYears(-12).Date);
            _page.setEmail("testTourist");
            _page.setPassword("Password12");

            _page.ClickCreate();

            Assert.Contains("Please enter a valid email address.", _page.source);
        }

        [Fact]
        public void Create_WrongPasswordPatternLength_ReturnError()
        {
            _page.setName("Janusz");
            _page.setLastName("Piechociñski");
            _page.setBirthDate(DateTime.Now.AddYears(-12).Date);
            _page.setEmail("testTourist@localhost");
            _page.setPassword("Pass2");

            _page.ClickCreate();

            Assert.Contains("Passwords must be at least 8 characters.", _page.source);
        }

        [Fact]
        public void Create_WrongPasswordPatternDigit_ReturnError()
        {
            _page.setName("Janusz");
            _page.setLastName("Piechociñski");
            _page.setBirthDate(DateTime.Now.AddYears(-12).Date);
            _page.setEmail("testTourist@localhost");
            _page.setPassword("Password");

            _page.ClickCreate();

            Assert.Contains("Passwords must have at least one digit ('0'-'9').", _page.source);
        }

        [Fact]
        public void Create_WrongPasswordPatternUpperCase_ReturnError()
        {
            _page.setName("Janusz");
            _page.setLastName("Piechociñski");
            _page.setBirthDate(DateTime.Now.AddYears(-12).Date);
            _page.setEmail("testTourist@localhost");
            _page.setPassword("password22");

            _page.ClickCreate();

            Assert.Contains("Passwords must have at least one uppercase ('A'-'Z').", _page.source);
        }

        [Fact]
        public void Create_WrongPasswordPatternLowerCase_ReturnError()
        {
            _page.setName("Janusz");
            _page.setLastName("Piechociñski");
            _page.setBirthDate(DateTime.Now.AddYears(-12).Date);
            _page.setEmail("testTourist@localhost");
            _page.setPassword("PASSWORD22");

            _page.ClickCreate();

            Assert.Contains("Passwords must have at least one lowercase ('a'-'z').", _page.source);
        }

        [Fact]
        public void Create_CorrectData_Success()
        {
            string email = Guid.NewGuid().ToString() + "@localhost";

            _page.setName("Janusz");
            _page.setLastName("Piechociñski");
            _page.setBirthDate(DateTime.Now.AddYears(-12).Date);
            _page.setEmail(email);
            _page.setPassword("Password123");

            _page.ClickCreate();
            Assert.Contains($"{email}!", _page.source);
        }

        [Fact]
        public void Create_EmailTaken_ReturnError()
        {
            string email = "admin@localhost";

            _page.setName("Janusz");
            _page.setLastName("Piechociñski");
            _page.setBirthDate(DateTime.Now.AddYears(-12).Date);
            _page.setEmail(email);
            _page.setPassword("Password123");

            _page.ClickCreate();

            Assert.Contains($"Username '{email}' is already taken.", _page.source);
        }

        [Fact]
        public void Create_WrongPasswordAll_ErrorMessages()
        {
            _page.setName("Janusz");
            _page.setLastName("Piechociñski");
            _page.setBirthDate(DateTime.Now.AddYears(-12).Date);
            _page.setEmail("test@localhost");
            _page.setPassword("@@@@");

            _page.ClickCreate();

            Assert.Contains("Passwords must have at least one lowercase ('a'-'z').", _page.source);
            Assert.Contains("Passwords must have at least one uppercase ('A'-'Z').", _page.source);
            Assert.Contains("Passwords must have at least one digit ('0'-'9').", _page.source);
            Assert.Contains("Passwords must be at least 8 characters.", _page.source);
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
