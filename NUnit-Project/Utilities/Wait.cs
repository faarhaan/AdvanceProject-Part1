using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit_Project.Utilities
{
    public class Wait
    {
        // Wait for Element to be Clickable
        public static void WaitToBeClickable(IWebDriver driver, string locatorType, string locatorValue, int seconds)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
                if (locatorType == "XPath")
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(locatorValue)));
                else if (locatorType == "Id")
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(locatorValue)));
                else
                    throw new ArgumentException($"Unsupported locator type: {locatorType}");
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new Exception($"Element not clickable after {seconds} seconds. Locator: {locatorType} = {locatorValue}", ex);
            }
        }

        // Wait for Element to be Visible
        public static void WaitToBeVisible(IWebDriver driver, string locatorType, string locatorValue, int seconds)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
                if (locatorType == "XPath")
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locatorValue)));
                else if (locatorType == "Id")
                    wait.Until(ExpectedConditions.ElementIsVisible(By.Id(locatorValue)));
                else
                    throw new ArgumentException($"Unsupported locator type: {locatorType}");
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new Exception($"Element not visible after {seconds} seconds. Locator: {locatorType} = {locatorValue}", ex);
            }
        }
    }
}
