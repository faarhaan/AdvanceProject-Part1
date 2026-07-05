using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit_Project.AssertHelpers;
using NUnit_Project.Pages;
using NUnit_Project.Pages.Components.Profile;
using NUnit_Project.Steps;
using NUnit_Project.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NUnit_Project.TestCases
{
    [TestFixture]
    public class AboutmeTestCases : BaseClass
    {

        private AboutMeSteps aboutMeStepsObj;
        
        [SetUp]
        public void Setup()
        {
            aboutMeStepsObj = new AboutMeSteps();
        }
        [Test, Order(10)]
        public void AboutmeTest() 
        {
            aboutMeStepsObj.AboutmeUserDetails();
        }
        

        
    }
}
