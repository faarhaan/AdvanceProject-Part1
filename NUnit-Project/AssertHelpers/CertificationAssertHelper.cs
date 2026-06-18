using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit_Project.AssertHelpers
{
    public static class CertificationAssertHelper
    {

        public static void AssertCertificationAdded(string Certificate, string lastCertificate)
        {
            Assert.That(lastCertificate, Is.EqualTo(Certificate),
                $"Expected certification '{Certificate}', but found '{lastCertificate}'.");
        }
       

        public static void AssertCertificationUpdated(String OriginalCertificate, String updatedCertificate)
        {
            Assert.That(updatedCertificate, Is.Not.EqualTo(OriginalCertificate),
                $"UpdatedCertificate '{updatedCertificate}', but found '{OriginalCertificate}'.");

        }

        public static void AssertCertificationDeleted(string certificate)
        {
            Assert.That(certificate, Is.Null, "Certification was not deleted.");
        }


    }
}
