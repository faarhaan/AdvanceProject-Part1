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
    public class CertificationSteps
    {
        // File paths moved to the Steps class
        private readonly string addCertificationsPath = "F:\\I-Advance-Github-Projects\\AdvanceProject-Part1\\NUnit-Project\\TestData\\certifications.json";
        private readonly string updateCertificationsPath = "F:\\IndustryConnect\\MVP\\GitRepo\\Newfolder2\\Advance-Task-Part-1\\nUnitPtoject\\TestData\\certifications-update.json";
        private readonly string deleteCertificationsPath = "F:\\IndustryConnect\\MVP\\GitRepo\\Newfolder2\\Advance-Task-Part-1\\nUnitPtoject\\TestData\\certification_delete.json";


        private readonly CertificationPage certPage;

        public CertificationSteps()
        { 
          certPage = new CertificationPage();
        }
        // above method is created in order to avoid repetion of certpageobj for every test cases
        public void AddCertification()
        {

            // Load data
            var dataList = JsonDataLoader.LoadData<CertificationModel>(addCertificationsPath);
            //var certPage = new CertificationPage();

            foreach (var data in dataList)
            {

                // ***  Add certification  from the certification Page POM****
                certPage.InputCertifications(data);

                // Get last certificate text from the UI
                var lastCertificate = certPage.GetLastCertificate(data.Certificate, data.From, data.Year);
                Console.WriteLine(data.Certificate + "is data.Cetificate from Model");
                Console.WriteLine(lastCertificate + "is last certificate from table");
                CertificationAssertHelper.AssertCertificationAdded(data.Certificate, lastCertificate);
            }

        }
        public void UpdateCertification()
        {
            // Load data with original and new values
            var dataList = JsonDataLoader.LoadData<CertificationModel>(updateCertificationsPath);
           // var certPage = new CertificationPage();

            foreach (var data in dataList)
            {
                // Call the updated method, which finds the certificate by its original name
                certPage.UpdateCertificate(data);

                // Wait for UI to refresh
                Thread.Sleep(2000);

                // Retrieve the updated certificate name directly as a string
                var updatedCertificateName = certPage.GetLastCertificate(data.OriginalCertificate, data.From, data.Year);

                // Verify that the updated certificate name matches the expected value
                CertificationAssertHelper.AssertCertificationUpdated(data.OriginalCertificate, updatedCertificateName);

                // Optional: Log success
                Console.WriteLine($"Certificate '{data.OriginalCertificate}' updated to '{data.Certificate}' successfully.");
            }
        }
        public void DeleteCertification()
        {
            // Load the data that was used for the update, as these are the current certificate names
            var dataList = JsonDataLoader.LoadData<CertificationModel>(deleteCertificationsPath);
            //var certPage = new CertificationPage();

            foreach (var data in dataList)
            {
                // Delete the certificate using its current name
                certPage.DeleteCertificate(data);

                // Verify that the certificate is no longer present
                var deletedCertificate = certPage.GetCertificateDetails(data.Certificate);

                // Assert that the certificate is null (i.e., deleted)
                CertificationAssertHelper.AssertCertificationDeleted(deletedCertificate?.Certificate);

                Console.WriteLine($"Certificate '{data.Certificate}' is deleted.");
            }
        }





    }
}
