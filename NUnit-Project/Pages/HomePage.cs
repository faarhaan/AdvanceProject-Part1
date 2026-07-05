using NUnit_Project.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit_Project.Pages
{
    public class HomePage : CommonDriver
    {
        // Locator as Private Field 
        private readonly By marsLogo = By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/a");

        // Verify user is logged in successfully
        public string UserIsInHomePage()
        {
            // Use the Wait class to wait for the element to be visible
             Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/div[1]/a", 15);
            //Thread.Sleep(5000);
            IWebElement MarsLogo = driver.FindElement(marsLogo);
            return MarsLogo.Text;
        }
    }
}
