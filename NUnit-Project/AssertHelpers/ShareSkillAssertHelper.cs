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
    public class ShareSkillAssertHelper : CommonDriver
    {
     public static void AssertShareSkillAdded(string actual, string expected)
        {
            Assert.That(expected, Is.EqualTo(actual),
                $"Expected Title '{expected}', but found '{actual}'.");
        }
    }
}
