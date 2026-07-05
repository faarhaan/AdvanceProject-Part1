using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit_Project.AssertHelpers
{
    public static class LanguageAssertHelper
    {
        public static void AssertLanguageAdded(string Language, string lastLanguage)
        {
            Assert.That(lastLanguage, Is.EqualTo(Language),
                $"Expected Language '{Language}', but found '{lastLanguage}'.");
        }


        public static void AssertLanguageUpdated(String OriginalLanguage, String updatedLanguage)
        {
            Assert.That(updatedLanguage, Is.Not.EqualTo(OriginalLanguage),
                $"UpdatedLanguage '{updatedLanguage}', but found '{OriginalLanguage}'.");

        }
        public static void AssertLanguaeDeleted(String Language, String deletedLanguage)
        {
            Assert.That(deletedLanguage, Is.Not.EqualTo(Language), $"Language '{Language}' was not deleted.");

        }


    }
}
