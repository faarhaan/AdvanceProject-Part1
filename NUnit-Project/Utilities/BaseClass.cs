using NUnit.Framework;
using NUnit_Project.Pages;
using NUnit_Project.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace NUnit_Project.TestCases
{
    public class BaseClass : CommonDriver
    {
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            // Initialize Extent Report once before all tests
            ExtentReportManager.InitReport();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Console.WriteLine("Flushing Extent Report...");
            // Flush Extent Report once after all tests are completed
            ExtentReportManager.FlushReport();
        }
        [SetUp]
        public void setUp()
        {
            Console.WriteLine("SetUp method started...");
            // To Handle leak password Detection
            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("profile.password_manager_leak_detection", false);

            //  Open Chrome Browser
            driver = new ChromeDriver(options);

            // Create a new test entry in ExtentReports
            var testName = TestContext.CurrentContext.Test.Name;
            ExtentReportManager.test = ExtentReportManager.extent.CreateTest(testName);
            Console.WriteLine($"Test initialized: {TestContext.CurrentContext.Test.Name}");

            // LoginPage Object initiallization and definition
            LoginPage loginpageObj = new LoginPage();
            loginpageObj.LoginActions(driver);

            // HomePage Object initilization and definition
            HomePage homePageObj = new HomePage();
            String userIsInHomePage = homePageObj.UserIsInHomePage();
            Assert.That(userIsInHomePage == "Mars Logo", "User is not in Home Page! Test is Failed!");
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("TearDown method started...");
            // Get the test result
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var testMessage = TestContext.CurrentContext.Result.Message;

            Console.WriteLine($"Test status: {testStatus}");
            Console.WriteLine($"Test message: {testMessage}");

            // Log the result to Extent Reports
            if (testStatus == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                ExtentReportManager.test.Pass("Test Passed");
            }
            else if (testStatus == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                ExtentReportManager.test.Fail($"Test Failed: {testMessage}");
                // Capture a screenshot on failure
                string screenshotPath = ScreenshotHelper.CaptureScreenshot(driver, TestContext.CurrentContext.Test.Name);
                ExtentReportManager.test.AddScreenCaptureFromPath(screenshotPath);
            }
            else
            {
                ExtentReportManager.test.Skip("Test Skipped");
            }

            Console.WriteLine($"Test logged in Extent Report: {TestContext.CurrentContext.Test.Name}");
            // Close the driver after each test
            driver.Quit();
        }
    }
    
}