using NUnit.Framework;
using NUnit_Project.AssertHelpers;
using NUnit_Project.Pages;
using NUnit_Project.Pages.Components.Profile;
using NUnit_Project.Steps;
using NUnit_Project.Utilities;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit_Project.TestCases
{
    [TestFixture]
    public class LanguageTestTestCases : BaseClass
    {
        private LanguageSteps languageStepsObj;
        [SetUp]
        public void Setup()
        {
            languageStepsObj = new LanguageSteps();
        }
        // above method is created in order to avoid repetion of lanuageStepobj for every test cases
        [Test, Order(4)]
        public void AddLanguageTest()
        {

            languageStepsObj.AddLanguage();

        }

        [Test, Order(5)]
        public void UpdateLanguageTest()
        {
           languageStepsObj.UpdateLanguage();
        }
        [Test, Order(6)]
        public void DeleteLanguageTest()
        {
            languageStepsObj.DeleteLanguage();
        }
    }
}
