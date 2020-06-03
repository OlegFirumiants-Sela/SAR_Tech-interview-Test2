using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTest
{
    [TestClass]
    public class TestScenarios
    {
        IWebDriver _wd;
        readonly string _url = Helper.URL;
        readonly string driverPath = Helper.CHROMEDRIVERPATH;

        [TestMethod]
        public void RegistrationTest()
        {
            using (_wd = new ChromeDriver(driverPath))
            {
                _wd.Manage().Window.Maximize();
                _wd.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                _wd.Navigate().GoToUrl(_url);

                var firstName = Helper.GetFirstNameRandomly();
                var lastName = Helper.GetLastNameRandomly();
                var email = $"{firstName}.{lastName}@fakeserver.com";
                var expectedXpath = "//div[contains(@class, 'breadcrumb')]/span[text()='My account']";

                FirstPage();

                SecondPage(email);

                ThirdPage(firstName, lastName, email);

                try
                {
                    IWebElement finalValidation = _wd.FindElement(By.XPath(expectedXpath));
                    Assert.IsNotNull(finalValidation);
                }
                catch (NoSuchElementException e)
                {
                    Assert.Fail(ExceptionAssertFailMessage(e.GetType().Name, e.Message));
                }
            }
        }

        [TestMethod]
        public void InvalidRegistrationTest()
        {
            using (_wd = new ChromeDriver(driverPath))
            {
                var email = "invalidmail.com";
                var expectedXpath = "//div[contains(@class, 'alert alert-danger')]/ol/li[text()='Invalid email address.']";

                _wd.Manage().Window.Maximize();
                _wd.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                _wd.Navigate().GoToUrl(_url);

                FirstPage();

                SecondPage(email);

                try
                {
                    IWebElement finalValidation = _wd.FindElement(By.XPath(expectedXpath));
                    Assert.IsNotNull(finalValidation);
                }
                catch (NoSuchElementException e)
                {
                    Assert.Fail(ExceptionAssertFailMessage(e.GetType().Name, e.Message));
                }
            }
        }

        /// <summary>
        /// finds the login button and presses it to redirect to login or register page
        /// </summary>
        private void FirstPage()
        {
            // click the login button
            FindElementByClassAndClick("login");
        }

        /// <summary>
        /// fills the email field and submits to redirect to create new account form.
        /// </summary>
        /// <param name="email">email</param>
        private void SecondPage(string email)
        {
            // fill valid email address
            FindElementByIdAndFillInput("email_create", email);
            // click on button
            FindElementByIdAndClick("SubmitCreate");

        }

        /// <summary>
        /// fills the form and submits it to create new account.
        /// </summary>
        /// <param name="firstName">first name</param>
        /// <param name="lastName">last name</param>
        /// <param name="email">email</param>
        private void ThirdPage(string firstName, string lastName, string email)
        {

            // select gender radio button
            FindElementByIdAndClick("id_gender1");
            // insert first name
            FindElementByIdAndFillInput("customer_firstname", firstName);
            // insert last name
            FindElementByIdAndFillInput("customer_lastname", lastName);
            // check email same as entered before
            FindElementByIdAndCheckIfValueEqualsToInput("email", email);
            // insert valid password(at least 5 chars)
            FindElementByIdAndFillInput("passwd", "123456");
            // insert date
            SelectFullDate("6", "April", "1985");
            // select optional checkboxes
            FindElementByIdAndClick("newsletter");
            FindElementByIdAndClick("optin");

            // insert first name
            FindElementByIdAndFillInput("firstname", firstName);
            // insert last name
            FindElementByIdAndFillInput("lastname", lastName);
            // insert company name
            FindElementByIdAndFillInput("company", $"{lastName} Corp.");
            // insert address
            FindElementByIdAndFillInput("address1", "My street 1");
            // insert city
            FindElementByIdAndFillInput("city", "My City");
            // select state
            FindElementByIdAndSelectComboboxValue("id_state", "Ohio");
            // insert postcode
            FindElementByIdAndFillInput("postcode", "12345");
            // select country
            FindElementByIdAndSelectComboboxValue("id_country", "United States");
            // insert phone number
            FindElementByIdAndFillInput("phone_mobile", "+1005551234");
            // click and submit form
            FindElementByIdAndClick("submitAccount");
        }

        /// <summary>
        /// finds the element by class and clicks it.
        /// </summary>
        /// <param name="elementId">elementId</param>
        /// <returns></returns>
        private IWebElement FindElementByClassAndClick(string elementId)
        {
            IWebElement element = _wd.FindElement(By.ClassName(elementId));
            element.Click();
            return element;
        }

        /// <summary>
        /// finds the element by id and clicks it.
        /// </summary>
        /// <param name="elementId">elementId</param>
        /// <returns></returns>
        private IWebElement FindElementByIdAndClick(string elementId)
        {
            IWebElement element = _wd.FindElement(By.Id(elementId));
            element.Click();
            return element;
        }

        /// <summary>
        /// selects the dates from comboboxes (select options) with the details passed.
        /// </summary>
        /// <param name="day">day, number as string</param>
        /// <param name="month">month, full name</param>
        /// <param name="year">year, number as string</param>
        private void SelectFullDate(string day, string month, string year)
        {
            FindElementByIdAndSelectComboboxValue("days", day);
            FindElementByIdAndSelectComboboxValue("months", month);
            FindElementByIdAndSelectComboboxValue("years", year);
        }

        /// <summary>
        /// finds the element by id and fills the input value to it.
        /// </summary>
        /// <param name="elementId">elementId</param>
        /// <param name="input">input value</param>
        /// <returns></returns>
        private IWebElement FindElementByIdAndFillInput(string elementId, string input)
        {
            IWebElement element = _wd.FindElement(By.Id(elementId));
            element.SendKeys(input);
            return element;
        }

        /// <summary>
        /// finds the element by id and selects the option with the input value.
        /// </summary>
        /// <param name="elementId">elementId</param>
        /// <param name="input">input value</param>
        /// <returns></returns>
        private IWebElement FindElementByIdAndSelectComboboxValue(string elementId, string input)
        {
            IWebElement element = _wd.FindElement(By.Id(elementId));
            element.SendKeys(input);
            element.Click();
            return element;
        }

        /// <summary>
        /// finds the element by id and checks if its value equals to the value passed as input.
        /// </summary>
        /// <param name="elementId">elementId</param>
        /// <param name="input">input value</param>
        /// <returns></returns>
        private bool FindElementByIdAndCheckIfValueEqualsToInput(string elementId, string input)
        {
            IWebElement element = _wd.FindElement(By.Id(elementId));
            return input == element.GetAttribute("value");
        }

        /// <summary>
        /// creates custom error message when called after exception caught.
        /// </summary>
        /// <param name="exceptionName">exception name</param>
        /// <param name="exceptionMessage">exception message</param>
        /// <returns></returns>
        private string ExceptionAssertFailMessage(string exceptionName, string exceptionMessage)
        {
            return $"Test Failed Because Of {exceptionName}\nWith Message: {exceptionMessage}";
        }

    }
}
