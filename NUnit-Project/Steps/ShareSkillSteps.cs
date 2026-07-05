using NUnit_Project.AssertHelpers;
using NUnit_Project.Pages.Components;
using NUnit_Project.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit_Project.Steps
{
    public class ShareSkillSteps
    {
        private shareSkill shareSkillPageObj;
        public ShareSkillSteps()
        {
            // Create object instance for ShareSkill Page
            shareSkillPageObj = new shareSkill();
        }
        public void AddShareSkill()
        {

            // Load data
            var dataList = JsonDataLoader.LoadData<ShareSkillModel>("F:\\I-Advance-Github-Projects\\AdvanceProject-Part1\\NUnit-Project\\TestData\\shareSkillData.json");
            //var shareSkilPage = new shareSkill();
            shareSkillPageObj.AddNewShareSkill(item: dataList[0]);   // use for 1 set of data instead of multiple data set
                                                                    // Get last Skill text from the Model

            var topskillTitle = shareSkillPageObj.GetTopShareSkill();
            Console.WriteLine(topskillTitle + " is sharedSkill from UI");

            ShareSkillAssertHelper.AssertShareSkillAdded(dataList[0].Title, topskillTitle);

        }
    }
}
