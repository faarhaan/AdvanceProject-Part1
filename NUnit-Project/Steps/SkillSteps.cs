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
    public class SkillSteps
    {
        private SkilPage skillPageObj;

        public SkillSteps()
        {
            // create an object instance of SkillPage
            skillPageObj = new SkilPage();
        }

        // above method is created in order to avoid repetion of skillpageobj for every test cases

        public void AddSkillSteps() 
        {

            // Load data
            var dataList = JsonDataLoader.LoadData<SkillModel>("F:\\I-Advance-Github-Projects\\AdvanceProject-Part1\\NUnit-Project\\TestData\\Skills-Add.json");
            //var skillPageObj = new SkilPage();

            foreach (var data in dataList)
            {

                // ***  Add Skill from the Skill Page POM****
                skillPageObj.SkillPage(data);

                // Get last Skill text from the Model
                var lastSkill = skillPageObj.GetLastSkill(data.Skill, data.Level);
                Console.WriteLine(data.Skill + "is data.Language from Model");
                Console.WriteLine(lastSkill + "is last language from table");
                SkillAssertHelper.AssertSkillAdded(data.Skill, lastSkill);
            }

        }


        public void UpdateSkillTest()
        {
            // Load data with original and new values
            var dataList = JsonDataLoader.LoadData<SkillModel>("F:\\IndustryConnect\\MVP\\GitRepo\\Newfolder2\\Advance-Task-Part-1\\nUnitPtoject\\TestData\\Skills-Update.json");
            //var skillPageObj = new SkilPage();

            foreach (var data in dataList)
            {
                // Call the updated method, which finds the Skill by its original name
                skillPageObj.UpdateSkill(data);

                // Wait for UI to refresh
                Thread.Sleep(2000);

                // Retrieve the updated Skill name directly as a string
                var updatedSkillName = skillPageObj.GetLastSkill(data.OriginalSkill, data.Level);

                // Verify that the updated Skill name matches the expected value
                SkillAssertHelper.AssertSkillUpdated(data.Skill, updatedSkillName);

                // Optional: Log success
                Console.WriteLine($"Skill '{data.OriginalSkill}' updated to '{data.Skill}' successfully.");
            }
        }


        public void DeleteSkillTest()
        {
            var dataList = JsonDataLoader.LoadData<SkillModel>("F:\\IndustryConnect\\MVP\\GitRepo\\Newfolder2\\Advance-Task-Part-1\\nUnitPtoject\\TestData\\Skills-Delete.json");
            //var skillPageObj = new SkilPage();

            foreach (var data in dataList)
            {
                // Delete the skill using its current name
                skillPageObj.DeleteAllSkills(data);

                // Verify that the skill is no longer present
                var deletedSkill = skillPageObj.GetLastSkill(data.Skill, data.Level);

                // Assert that the skill is deleted
                SkillAssertHelper.AssertSkillDeleted(data.Skill, deletedSkill);

                Console.WriteLine($"Skill '{data.Skill}' is deleted.");
            }
        }






    }
}
