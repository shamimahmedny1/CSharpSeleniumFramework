using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.Configuration;
using System.Xml.Linq;

namespace CSharpSeleniumFramework.utilities
{
    class BaseClass
    {
        public IWebDriver driver;
        public WebDriverWait wait;
        public string Username;
        public string Password;
        public string BaseUrl;
        private object ScreenshotImageFormat;

        [SetUp]
        public void startBrowser()
        {
            String browserName= ConfigurationManager.AppSettings["browser"];
            InitBrowser(browserName);
            // Initialize credentials
            InitConfigValues();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = BaseUrl;
        }
        public IWebDriver getDriver()
        {
            return driver;
        }

        private void InitBrowser(string browserName)
        {
            if (browserName == "Chrome") driver = new ChromeDriver();
            else if (browserName == "Firefox") driver = new FirefoxDriver();
            else if (browserName == "Edge") driver = new EdgeDriver();
            else throw new ArgumentException("Invalid browser name in App.config");
        }
        // Credentials initialization
        private void InitConfigValues()
        {
            Username = ConfigurationManager.AppSettings["Username"];
            Password = ConfigurationManager.AppSettings["Password"];
            BaseUrl = ConfigurationManager.AppSettings["baseUrl"];
        }

        public IWebElement WaitForElement(IWebElement element, Func<IWebElement, bool> condition, int timeoutInSeconds = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(driver => condition(element)); // Apply the condition on the element
            return element; // Return the element after the condition is met
        }
        //Wait for element to be clickable
        public IWebElement WaitForElementToBeClickable(IWebElement element, int timeoutInSeconds = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        public void CaptureScreenshot(string testName)
        {
            try
            {
                // Create the 'Screenshots' folder if it doesn't exist
                string screenshotsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots");
                if (!Directory.Exists(screenshotsDir))
                    Directory.CreateDirectory(screenshotsDir);

                // Create a unique filename with timestamp
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                string screenshotFile = Path.Combine(screenshotsDir, $"{testName}_{timestamp}.png");

                // Capture and save the screenshot as PNG
                ITakesScreenshot ts = (ITakesScreenshot)driver;
                Screenshot screenshot = ts.GetScreenshot();
                screenshot.SaveAsFile(screenshotFile);

                Console.WriteLine($"Screenshot saved: {screenshotFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to capture screenshot: {ex.Message}");
            }
        }

        public string GenerateRandomEmail(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();

            // Generate a random username part of the email
            string randomUsername = new string(Enumerable.Repeat(chars, length)
                                  .Select(s => s[random.Next(s.Length)]).ToArray());

            // Create the full email address
            string randomEmail = $"{randomUsername}@example.com";
            Console.WriteLine($"Generated Email: {randomEmail}");
            return randomEmail;
        }

        [TearDown]
        public void TearDown()
        {
            // Get the current test name and status
            string testName = TestContext.CurrentContext.Test.Name;
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;

            // If the test failed, take a screenshot
            if (testStatus == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                Console.WriteLine($"Test '{testName}' failed. Capturing screenshot...");
                CaptureScreenshot(testName);
            }

            // Close the browser
            driver.Quit();
        }
    }
}
