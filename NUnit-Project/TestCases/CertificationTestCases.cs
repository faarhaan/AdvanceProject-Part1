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
    public class CertificationTestCases : BaseClass
    {
        private CertificationSteps certificationStepsObj; // Fixed declaration of the field

        [SetUp]
        public void Setup()
        {
            certificationStepsObj = new CertificationSteps();
        }
        // above method is created in order to avoid repetion of certificationStepsobj for every test cases
        [Test, Order(1)]
        public void AddCertificationTest()
        {
            certificationStepsObj.AddCertification();
        }

        [Test, Order(2)]
        public void UpdateCertificationTest()
        {
           certificationStepsObj.UpdateCertification();
        }



        [Test, Order(3)]
        public void DeleteCertificationTest()
        {
            certificationStepsObj.DeleteCertification();
        }
    }
}
