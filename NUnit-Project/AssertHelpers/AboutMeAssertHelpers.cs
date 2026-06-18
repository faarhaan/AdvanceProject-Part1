using AventStack.ExtentReports;
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
    public class AboutMeAssertHelpers : CommonDriver
    {

       
        public  void EditAssertHelpers(IWebElement popupMsgElement, string expSuccessMessage)  //use static word in this method if you don't want to create instance                                                                                                  in AboutmeTestCases.cs
        {
            

            // Assign srting type to the variable as output from IWebElement is text
            string popupMsgBox = popupMsgElement.Text; 
            Thread.Sleep(2000);
            Console.WriteLine(popupMsgBox);
            Assert.That(popupMsgBox, Is.EqualTo(expSuccessMessage),
          
                $"Expected Message '{expSuccessMessage}', but found '{popupMsgBox}'.");
        }
    }

}

