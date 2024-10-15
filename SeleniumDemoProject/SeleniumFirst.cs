using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemoProject
{
    class SeleniumFirst
    {
        IWebDriver driver;
        WebDriverWait wait;
        [SetUp]
        public void startBrowser()
        {
            //Console.Clear();
            // driver = new ChromeDriver();
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(10);

        }

        [Test]
        public void Test1()
        {
            driver.Url= "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";
            string actualTitle= driver.Title;
            Console.WriteLine($"Title of the webpage: {actualTitle}");
            Assert.That(actualTitle, Is.EqualTo("OrangeHRM"), "Title of the webpage does not match");
   
            IWebElement userId = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@name='username']")));
            userId.SendKeys("Admin");
            IWebElement password = driver.FindElement(By.XPath("//*[@name='password']"));
            password.SendKeys("admin123");
            IWebElement loginBtn = driver.FindElement(By.XPath("//*[@type='submit']"));
            loginBtn.Click();
            String dashboardAfterLogin 
                = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//h6[@class='oxd-text oxd-text--h6 oxd-topbar-header-breadcrumb-module']"))).Text;
            Assert.That(dashboardAfterLogin, Is.EqualTo("Dashboard"), "DashBoard message is not equal");
            
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }

    }
}
