
using NUnit_Project.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V135.Overlay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace NUnit_Project.Pages.Components
{
    public class SearchSkill : CommonDriver
    {
        // Locators as private Fields
        private readonly By searchSkillTextBox = By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[1]/input");
        private readonly By searchButton = By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[1]/i");
        private readonly By category = By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[1]/div/a[2]");
        private readonly By subCategory = By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[1]/div/a[4]");
        private readonly By filterOption = By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[4]");
        private readonly By filterOption1 = By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[5]/button[1]");
        private readonly By filterOption2 = By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[5]/button[2]");
        // Actions as Method

        public void SearchSkillByTextbox()
        {
            Thread.Sleep(2000);
            driver.FindElement(searchSkillTextBox).SendKeys("Python");
            driver.FindElement(searchButton).Click();
            Thread.Sleep(5000);
        }
        public void SearchSkillByCategory() 
        { 
            Thread.Sleep(2000);
            driver.FindElement(category).Click();
        }
        public void SearchSkillBySubcategory()
        {
            Thread.Sleep(1000);
            driver.FindElement(subCategory).Click();
        }
        public void SearchSkillByFilter(SearchSkillModel item)
        {
            try
            {
                // Log the filter value for debugging
                Console.WriteLine($"Filter value from model: {item.Filter}");
                Console.WriteLine($"Filter option 1 displayed: {driver.FindElement(filterOption1).Displayed}");
                Console.WriteLine($"Filter option 2 displayed: {driver.FindElement(filterOption2).Displayed}");
                // Wait for the filter options to be present in the DOM
                Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[5]/button[1]", 15);
                Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[5]/button[2]", 15);

                // Use JavaScriptExecutor to click the appropriate filter option
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

                if (item.Filter.Equals("Online", StringComparison.OrdinalIgnoreCase))
                {
                    IWebElement onlineButton = driver.FindElement(filterOption2);
                    js.ExecuteScript("arguments[0].click();", onlineButton);
                    Console.WriteLine("Online filter clicked.");
                    Thread.Sleep(9000);
                }


                else if (item.Filter.Equals("Onsite", StringComparison.OrdinalIgnoreCase))
                {
                    IWebElement onsiteButton = driver.FindElement(filterOption1);
                    js.ExecuteScript("arguments[0].click();", onsiteButton);
                    Console.WriteLine("Onsite filter clicked.");
                    Thread.Sleep(000);
                }
                else
                {
                    throw new Exception($"Invalid filter option: {item.Filter}. Expected values are 'Onsite' or 'Online'.");
                }
            }
            catch (Exception ex)
            {
                // Capture a screenshot for debugging
                string screenshotPath = ScreenshotHelper.CaptureScreenshot(driver, "FilterOptionsError");
                Console.WriteLine($"Screenshot saved at: {screenshotPath}");

                throw new Exception($"Failed to select filter option. Details: {ex.Message}", ex);
            }
            
        }
    }
}
