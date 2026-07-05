using NUnit_Project.AssertHelpers;
using NUnit_Project.Pages.Components.Profile;
using NUnit_Project.TestCases;
using NUnit_Project.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit_Project.Steps
{
    public class AboutMeSteps : BaseClass
    {
        private AboutMePage aboutmePageObj;

        public AboutMeSteps()
        {
            aboutmePageObj = new AboutMePage();
        }
        public void AboutmeUserDetails()
        {
            // Load data
            var dataList = JsonDataLoader.LoadData<AboutMeModel>("F:\\I-Advance-Github-Projects\\AdvanceProject-Part1\\NUnit-Project\\TestData\\aboutMeData.json");
            //var aboutmePage = new AboutMePage();
            var aboutMeAssertHelpers = new AboutMeAssertHelpers(); // Create an instance of AboutMeAssertHelpers b/c method is not static other wise there is no need to create instance

            foreach (var item in dataList)
            {
                // *** Add availability details from the AboutMe Page POM ****
                aboutmePageObj.EditAvailability(item);
                aboutmePageObj.EditHours(item);
                aboutmePageObj.EditTarget(item);
                //  if you want to see values of model then create strings for each item.
                string avlbTime = item.Availability;
                string avalbHours = item.Hours;
                string ernTarget = item.EarnTarget;
                Console.WriteLine($"values from the model - Availability: {avlbTime}, Hours: {avalbHours}, Earn Target: {ernTarget}");

                //  Use the instance of AboutMeAssertHelpers
                IWebElement popupMsgBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                string expSuccessMessage = "Availability updated"; // Replace with actual expected message

                aboutMeAssertHelpers.EditAssertHelpers(popupMsgBox, expSuccessMessage);
            }
        }
    }
}
