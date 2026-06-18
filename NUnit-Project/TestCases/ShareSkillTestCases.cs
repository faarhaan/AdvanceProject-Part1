using NUnit.Framework;
using NUnit_Project.AssertHelpers;
using NUnit_Project.Pages;
using NUnit_Project.Pages.Components;
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
    public  class ShareSkillTestCases :BaseClass
    {
        private ShareSkillSteps shareSkillStepsObj;
        [SetUp]
        public void setup()
        {
            shareSkillStepsObj = new ShareSkillSteps();
        }
        [Test, Order(11)]
        public void AddShareSkillTest()
        {

            shareSkillStepsObj.AddShareSkill();
        }

    }   
}
