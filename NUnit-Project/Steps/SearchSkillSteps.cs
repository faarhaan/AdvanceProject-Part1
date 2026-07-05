using NUnit_Project.Pages.Components;
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
    public class SearchSkillSteps : BaseClass
    {
        private SearchSkill searchSkillObj;
        // create Object instance for serachSkillPage
        public SearchSkillSteps()
        {
            searchSkillObj = new SearchSkill();
        }
        public void SearchSkill()
        {

            // Load data
            var dataList = JsonDataLoader.LoadData<SearchSkillModel>("F:\\I-Advance-Github-Projects\\AdvanceProject-Part1\\NUnit-Project\\TestData\\SearchSkillData.json");
              // var searchPage = new SearchSkill();
            // Perform search actions
            searchSkillObj.SearchSkillByTextbox();
            searchSkillObj.SearchSkillByCategory();
            searchSkillObj.SearchSkillBySubcategory();
            searchSkillObj.SearchSkillByFilter(item: dataList[0]); // use for 1 set of data instead of multiple data set

            var searchResults = driver.FindElements(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/div[2]/div"));
            int actualCount = searchResults.Count;

            // Assert that the count of search results is greater than 0
            //Assert.That(actualCount, Is.GreaterThan(0), "No search results were found. The search functionality might not be working.");




        }
    }
}
