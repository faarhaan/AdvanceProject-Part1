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
    public class SkillsTestCases : BaseClass
    {
        private SkillSteps skillStepsObj;
        [SetUp]
        public void setup()
        {
            // make object instance of SkillStepsPage
            skillStepsObj = new SkillSteps();
        }



        [Test, Order(7)]
        public void AddSkillTest()
        {

            skillStepsObj.AddSkillSteps();
        }

        [Test, Order(8)]
        public void UpdateSkillTest()
        {
            skillStepsObj.UpdateSkillTest();
        }

        [Test, Order(9)]
        public void DeleteSkillTest()
        {
            skillStepsObj.DeleteSkillTest();
        }

    }
}
