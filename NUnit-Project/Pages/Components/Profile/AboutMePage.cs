
using NUnit_Project.TestCases;
using NUnit_Project.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit_Project.Pages.Components.Profile
{ 
    public class AboutMePage : CommonDriver
    {
        // Locators  as a Private field

        private readonly By editIconAT = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i");
        private readonly By dropDownAT = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select");
        private readonly By removeIconAT = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i");
        private readonly By editIconHrs = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i");
        private readonly By dropDownHrs = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select");
        private readonly By removeIconHrs = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i");
        private readonly By editIconET = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i");
        private readonly By dropDownET = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select");
        private readonly By removeIconET = By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i");
        private readonly By renderSucessMessage = By.XPath("/html/body/div[1]/div");
        private readonly By removeMsgIcon = By.XPath("/html/body/div[1]/a");
        private readonly By profileTab = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]");
        // Actions as a Methods
        public void EditAvailability(AboutMeModel item)
        {
            //driver.FindElement(profileTab).Click();
            Thread.Sleep(2000);
            driver.FindElement(editIconAT).Click();
            Thread.Sleep(1000);
            driver.FindElement(dropDownAT).SendKeys(item.Availability);
        }
        public void EditHours(AboutMeModel item)
        {
            Thread.Sleep(1000);
            driver.FindElement(editIconHrs).Click();
            Thread.Sleep(1000);
            driver.FindElement(dropDownHrs).SendKeys(item.Hours);
        }
        public void EditTarget(AboutMeModel item)
        {
            Thread.Sleep(1000);
            driver.FindElement(editIconET).Click();
            Thread.Sleep(1000);
            driver.FindElement(dropDownET).SendKeys(item.EarnTarget);
        }
        public String GetSuccessMsg()
        {
            Thread.Sleep(1000);
            IWebElement successMessage = driver.FindElement(renderSucessMessage);
            string message = successMessage.Text;
            Thread.Sleep(1000);
           // driver.FindElement(removeMsgIcon).Click();
            Console.WriteLine(message);
            return message;
        }
    }
}
