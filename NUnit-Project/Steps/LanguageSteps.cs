using NUnit.Framework;
using NUnit_Project.AssertHelpers;
using NUnit_Project.Pages.Components.Profile;
using NUnit_Project.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit_Project.Steps
{
    public class LanguageSteps
    {

        private LSPage languagePageObj;

        public LanguageSteps()
        {
            languagePageObj = new LSPage();
        }
        // above method is created in order to avoid repetion of languagepageobj for every test cases
        public void AddLanguage()
        {

            // Load data
            var dataList = JsonDataLoader.LoadData<LanguageModel>("F:\\I-Advance-Github-Projects\\AdvanceProject-Part1\\NUnit-Project\\TestData\\Language-Add.json");
            //var LangPage = new LSPage();

            foreach (var data in dataList)
            {

                // ***  Add Language from the certification Page POM****
                languagePageObj.languagePage(data);

                // Get last Language text from the UI
                var lastLanguage = languagePageObj.GetLastLanguage(data.Language, data.Level);
                Console.WriteLine(data.Language + "is data.Language from Model");
                Console.WriteLine(lastLanguage + "is last language from table");
                LanguageAssertHelper.AssertLanguageAdded(data.Language, lastLanguage);
            }

        }
        
        public void UpdateLanguage()
        {
            // Load data with original and new values
            var dataList = JsonDataLoader.LoadData<LanguageModel>("F:\\IndustryConnect\\MVP\\GitRepo\\Newfolder2\\Advance-Task-Part-1\\nUnitPtoject\\TestData\\Language-Update.json");
            //var LangPage = new LSPage();

            foreach (var data in dataList)
            {
                // Call the updated method, which finds the Language by its original name
                languagePageObj.UpdateLanguage(data);

                // Wait for UI to refresh
                Thread.Sleep(2000);

                // Retrieve the updated Language name directly as a string
                var updatedLanguageName = languagePageObj.GetLastLanguage(data.OriginalLanguage, data.Level);

                // Verify that the updated Language name matches the expected value
                LanguageAssertHelper.AssertLanguageUpdated(data.OriginalLanguage, updatedLanguageName);

                // Optional: Log success
                Console.WriteLine($"Language '{data.OriginalLanguage}' updated to '{data.Language}' successfully.");
            }
        }
        
        public void DeleteLanguage()
        {
            // Load the data that was used for the update, as these are the current Languages names
            var dataList = JsonDataLoader.LoadData<LanguageModel>("F:\\IndustryConnect\\MVP\\GitRepo\\Newfolder2\\Advance-Task-Part-1\\nUnitPtoject\\TestData\\Language-delete.json");
            //var LangPage = new LSPage();

            foreach (var data in dataList)
            {
                // Delete the Language using its current name
                languagePageObj.DeleteAllLanguages(data);

                // Verify that the Language is no longer present
                var deletedLanguage = languagePageObj.GetLastLanguage(data.Language, data.Level);
                Console.WriteLine(deletedLanguage);
                // Assert that the Language is null (i.e., deleted)
                LanguageAssertHelper.AssertLanguaeDeleted(data.Language, deletedLanguage);

                Console.WriteLine($"Language'{data.Language}' is deleted.");


            }
        }
    }
}
