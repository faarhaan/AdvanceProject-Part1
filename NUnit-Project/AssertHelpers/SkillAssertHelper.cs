using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit_Project.AssertHelpers
{
    public class SkillAssertHelper
    {
        public static void AssertSkillAdded(string Skill, string lastSkill)
        {
            Assert.That(lastSkill, Is.EqualTo(Skill),
                $"Expected Skill '{Skill}', but found '{lastSkill}'.");
        }


        public static void AssertSkillUpdated(String OriginalSkill, String updatedSkill)
        {
            Assert.That(updatedSkill, Is.Not.EqualTo(OriginalSkill),
                $"UpdatedSkill '{updatedSkill}', but found '{OriginalSkill}'.");

        }
        public static void AssertSkillDeleted(string Skill, String deletedSkill)
        {
            Assert.That(deletedSkill, Is.Not.EqualTo(Skill),
            $"Skill '{Skill}' was not deleted. Still found '{deletedSkill}'.");
            //Assert.That(deletedSkill, Is.Null, "Skill was not deleted.");
        }
    }
}
