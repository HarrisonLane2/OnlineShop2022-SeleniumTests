using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnitTests
{
    //powerpoint that goes through all of this
    public class Tests
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void GoToHomePageCheckTitle()
        {
            driver.Navigate().GoToUrl("https://onlineshop2022host.azurewebsites.net/Identity/Account/Login?ReturnUrl=%2F");
            string title = driver.Title;
            Assert.AreEqual(title, "Log in - OnlineShop2022");
            
        }
        [Test]
        public void RegisterButtonOnlinePage()
        {
            driver.Navigate().GoToUrl("https://onlineshop2022host.azurewebsites.net/Identity/Account/Login?ReturnUrl=%2F");
            IWebElement RegButton = driver.FindElement(By.Id("register"));
            RegButton.Click();
            string title = driver.Title;
            Assert.AreEqual(title, "Register - OnlineShop2022");

        }
        [Test]
        public void RegisterNewUser()
        {
            driver.Navigate().GoToUrl("https://onlineshop2022host.azurewebsites.net/Identity/Account/Login?ReturnUrl=%2F");
            IWebElement RegButton = driver.FindElement(By.Id("register"));
            RegButton.Click();
            IWebElement Input_Fname = driver.FindElement(By.Id("Input_Fname"));
            Input_Fname.SendKeys("Test");
            IWebElement Input_Sname = driver.FindElement(By.Id("Input_Sname"));
            Input_Sname.SendKeys("User"); 
            IWebElement Input_Email = driver.FindElement(By.Id("Input_Email"));
            Input_Email.SendKeys("Testuser1@gmail.com");
            IWebElement Input_Password = driver.FindElement(By.Id("Input_Password"));
            Input_Password.SendKeys("TestPass24!");
            IWebElement Input_ConfirmPassword = driver.FindElement(By.Id("Input_ConfirmPassword"));
            Input_ConfirmPassword.SendKeys("TestPass24!");
            Input_ConfirmPassword.Submit();
            string title = driver.Title;
            Assert.AreEqual(title, "Home Page - OnlineShop2022");

        }
        [Test]
        public void SignIn()
        {
            driver.Navigate().GoToUrl("https://onlineshop2022host.azurewebsites.net/Identity/Account/Login?ReturnUrl=%2F");
            IWebElement Input_Email = driver.FindElement(By.Id("Input_Email"));
            Input_Email.SendKeys("Testuser1@gmail.com");
            IWebElement Input_Password = driver.FindElement(By.Id("Input_Password"));
            Input_Password.SendKeys("TestPass24!");
            Input_Password.Submit();
            string title = driver.Title;
            Assert.AreEqual(title, "Home Page - OnlineShop2022"); 

        }

        [OneTimeTearDown]
        public void End()
        {
            driver.Close(); 
        }
    }
}