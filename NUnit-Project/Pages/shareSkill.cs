using NUnit_Project.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V135.Page;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit_Project.Pages.Components
{
    public class shareSkill : CommonDriver
    {
        // Locators as IWebElement    

        private readonly By shareSkillBtn = By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/div[2]/a");
        private readonly By titleTextbox = By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input");
        private readonly By descriptionTextbox = By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[2]/div/div[2]/div[1]/textarea");
        private readonly By categoryDropdown = By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[3]/div[2]/div/div[1]/select");
        private readonly By subCategory = By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select");
        private readonly By tags = By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div[1]/div/div/div/input");
        private readonly By serviceTypeRadioBtn = By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input");
        private readonly By locationTypeRadioBtn = By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input");
        private readonly By availableDays = By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div/div[1]/ul[1]/li[4]/a/span[2]");
        private readonly By skillTradeRadioBtn = By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input");
        private readonly By skillExchangeTag = By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div[1]/div/div/div/div/input");
        private readonly By active = By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input");
        private readonly By hidden = By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[10]/div[2]/div/div[2]/div/input");
        private readonly By saveBtn = By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]");
        private readonly By cancelBtn = By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[2]");
        private readonly By newlyAddedShareSkill = By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[2]");
        private readonly By againProfileBtn = By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]");
        // if you want to select radio button from model e.g for Service Type, you have to assign string s variable and then use in if condition mention in below code
        private IReadOnlyList<IWebElement> serviceType; // you hv to define service Type

        string serviceType1 = "Hourly basis service";
        string serviceType2 = "One-off service";

        // Actions as a Methods

        public void AddNewShareSkill(ShareSkillModel item)
        {


            // Wait for the ShareSkill button to be clickable and click it
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/div[2]/a", 20);
            // click on ShareSkill button
            driver.FindElement(shareSkillBtn).Click();
            Thread.Sleep(3000);
            // Input text from model
            driver.FindElement(titleTextbox).Click();
            driver.FindElement(titleTextbox).SendKeys(item.Title);
            // input description from Modlel
            driver.FindElement(descriptionTextbox).SendKeys(item.Description);
            // Select Category
            driver.FindElement(categoryDropdown).SendKeys(item.Category);
            // Select Sub-category
            Thread.Sleep(3000);
            driver.FindElement(subCategory).SendKeys(item.SubCategory);
            // Input tags from Model
            driver.FindElement(tags).SendKeys(item.Tags);
            driver.FindElement(tags).SendKeys(Keys.Enter);
            // Select the appropriate service type radio button
            if (item.ServiceType == serviceType1)
            {
                driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input")).Click();
            }
            else if (item.ServiceType == serviceType2)
            {
                driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input")).Click();
            }
            else
            {
               throw new Exception("Invalid ServiceType: " + item.ServiceType);
            }


            
            // driver.FindElement(locationTypeRadioBtn).Click();
            //as below elements are not interactaable so use javaScriptExecuter
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", driver.FindElement(locationTypeRadioBtn));
          
            // Select the specific date
            IWebElement calendarElement = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div/div[1]/ul[1]/li[4]/a/span[3]"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", calendarElement);
            // skill trade radio button
            driver.FindElement(skillTradeRadioBtn).Click();
            // input skill exchange Tag
            driver.FindElement(skillExchangeTag).SendKeys(item.SkillExchange);
            driver.FindElement(skillExchangeTag).SendKeys(Keys.Enter);
            // select active radio button
            driver.FindElement(active).Click();
            // click on Save button
            driver.FindElement(saveBtn).Click();

        }
        // newly shared skill appears on top of table in Mannage Listing Page so fetch this element
        private readonly By newlyCreatedSkill = By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]");
        // now get the text of that share skill for Assertion purpose
        public String GetTopShareSkill()
        {
            try
            {
                Thread.Sleep(2000);
                return driver.FindElement(newlyCreatedSkill).Text;
            }


            catch (NoSuchElementException)
            {
                // Return null if no shareskill is found
                return null;
            }

        }
    }
}

