using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit_Project.Utilities
{
    public static class ExtentReportManager
    {
        public static ExtentReports extent;
        public static ExtentTest test;

        public static void InitReport()
        {
            if (extent == null) // Ensure the report is initialized only once
            {
                string reportDir = @"F:\I-Advance-Github-Projects\AdvanceProject-Part1\NUnit-Project\TestResults";
                string reportPath = Path.Combine(reportDir, "ExtentReport.html");

                // Create the directory if it doesn't exist
                if (!Directory.Exists(reportDir))
                    Directory.CreateDirectory(reportDir);

                // Initialize ExtentReports
                var htmlReporter = new ExtentSparkReporter(reportPath);
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);

                Console.WriteLine($"Extent Report initialized at: {reportPath}");
            }
        }

        public static void FlushReport()
        {
            extent.Flush();
            Console.WriteLine("Extent Report flushed.");
        }
    }
}
