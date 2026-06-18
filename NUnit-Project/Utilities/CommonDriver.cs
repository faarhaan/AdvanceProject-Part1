using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit_Project.Utilities
{
    public class CommonDriver
    {
        public static IWebDriver driver;
        // Protected driver instance accessible in derived classes
       // protected IWebDriver driver;

        [TearDown]
        public void CloseTestrun()
        {
            // Check if the test failed
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                // Navigate to the project directory
                var projectDir = Path.Combine(AppContext.BaseDirectory, "..", "..", "..");
                var screenshotDir = Path.Combine(projectDir, "Screenshots");
                /*
                                // Use the project directory instead of the runtime directory
                                // Get the project directory explicitly
                                //string projectDirectory = AppContext.BaseDirectory; // This points to the runtime directory.
                                //projectDirectory = Path.GetFullPath(Path.Combine(projectDirectory, @"..\..\..\")); // Navigate to the project root.*/

                // Create the Screenshots directory if it doesn't exist
                if (!Directory.Exists(screenshotDir))
                    Directory.CreateDirectory(screenshotDir);

                // Capture screenshot
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                var screenshotPath = Path.Combine(screenshotDir, $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
                screenshot.SaveAsFile(screenshotPath);

                // Attach screenshot to ExtentReports
                ExtentReportManager.test.AddScreenCaptureFromPath(screenshotPath);
                ExtentReportManager.test.Fail($"Test failed. Screenshot saved at: {screenshotPath}");
            }

            // Quit the driver
            driver?.Quit();
        }
    }
}
