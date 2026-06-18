using NUnit.Framework;
using NUnit_Project.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit_Project.AssertHelpers
{  
public class SearchSkillAssertHelper : CommonDriver
    {
        public void AssertSearchResultsCount(int actualCount)
        {
            // Assert that the count of search results is greater than 0
            Assert.That(actualCount, Is.GreaterThan(0), "No search results were found. The search functionality might not be working.");

        }
    }
}
