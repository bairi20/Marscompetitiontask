using AventStack.ExtentReports;
using NUnit.Framework;
using NunitAutomation.Pages;
using NunitAutomation.TestModel;
using NunitAutomation.Utilities;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitAutomation.Tests
{
    [TestFixture]
    public class NegativeTest : CommonDriver
    {
#pragma warning disable CS8618


        private EducationPage educationPageObj = new EducationPage();
        private CertificationsPage certificationsPageObj = new CertificationsPage();
        private ExtentReports extent;
        [Test, Order(1)]
        public void AddNegativeEducation_Test()
        {
            CommonDriver driver = new CommonDriver();
            driver.InitializeExtentReports();
            string testName = "AddNegativeEducation";
            driver.SetupTest(testName);
            // Read test data from the JSON file using JsonHelper
            List<EducationTestModel> AddNegativeEducationData = Jsonhelper.ReadTestDataFromJson<EducationTestModel>("C:\\MVP Project\\NunitAutomation\\NunitAutomation\\JsonDataFiles\\AddNegativeEducationData.json");
            Console.WriteLine(AddNegativeEducationData.ToString());
            foreach (var data in AddNegativeEducationData)
            {
                string university = data.University;
                Console.WriteLine(university);
                string country = data.Country;
                Console.WriteLine(country);
                string title = data.Title;
                Console.WriteLine(title);
                string degree = data.Degree;
                Console.WriteLine(degree);
                string graduationyear = data.Graduationyear;
                Console.WriteLine(graduationyear);
                string screenshotName = "AddNegativeEducationData";
                driver.CaptureScreenshot(screenshotName);
                educationPageObj.AddNegativeEdu(university, country, title, degree, graduationyear);


            }
        }
       [Test, Order(2)]
        public void updateNegativeEducation_Test()
        {
            CommonDriver driver = new CommonDriver();
            driver.InitializeExtentReports();
            string testName = "UpdateNegativeEducation";
            driver.SetupTest(testName);
            // Read test data from the JSON file using JsonHelper
            List<EducationTestModel> UpdateEducationNegativeData = Jsonhelper.ReadTestDataFromJson<EducationTestModel>("C:\\MVP Project\\NunitAutomation\\NunitAutomation\\JsonDataFiles\\UpdateNegativeEducationData.json");
            Console.WriteLine(UpdateEducationNegativeData.ToString());
            foreach (var data in UpdateEducationNegativeData)
            {
                // Access the LoginData values
                string university = data.University;
                Console.WriteLine(university);
                string country = data.Country;
                Console.WriteLine(country);
                string title = data.Title;
                Console.WriteLine(title);
                string degree = data.Degree;
                Console.WriteLine(degree);
                string graduationyear = data.Graduationyear;
                Console.WriteLine(graduationyear);
                string screenshotName = "UpdateEducationNegativeData";
                driver.CaptureScreenshot(screenshotName);
                educationPageObj.updateNegativeEdu(university, country, title, degree, graduationyear);



            }
        }
        [Test, Order(3)]
        public void AddNegativeCertification_Test()
        {
            CommonDriver driver = new CommonDriver();
            driver.InitializeExtentReports();
            string testName = "AddNegativeCertification";
            driver.SetupTest(testName);

            // Read test data from the JSON file using JsonHelper
            List<CertificationTestModel> AddCertificationNegativeData = Jsonhelper.ReadTestDataFromJson<CertificationTestModel>("C:\\MVP Project\\NunitAutomation\\NunitAutomation\\JsonDataFiles\\AddCertificationNegativeData.Json");
            Console.WriteLine(AddCertificationNegativeData.ToString());
            foreach (var data in AddCertificationNegativeData)
            {
                // Access individual test data properties
                string certificate = data.certificate;
                Console.WriteLine(certificate);
                string certifiedFrom = data.certifiedFrom;
                Console.WriteLine(certifiedFrom);
                string year = data.year;
                Console.WriteLine(year);
                string screenshotName = "AddCertificationNegativeData";
                driver.CaptureScreenshot(screenshotName);
                certificationsPageObj.addNegativeCertifications(certificate, certifiedFrom, year);
            }
        }
        [Test, Order(4)]
        public void UpdateNegativeCertification_Test()
        {
            CommonDriver driver = new CommonDriver();
            driver.InitializeExtentReports();
            string testName = "UpdateNegativeCertification";
            driver.SetupTest(testName);
            // Read test data from the JSON file using JsonHelper
            List<CertificationTestModel> UpdateCertificationNegativeData = Jsonhelper.ReadTestDataFromJson<CertificationTestModel>("C:\\MVP Project\\NunitAutomation\\NunitAutomation\\JsonDataFiles\\UpdateCertificationNegativeData.Json");
            Console.WriteLine(UpdateCertificationNegativeData.ToString());
            foreach (var data in UpdateCertificationNegativeData)
            {
                // Access individual test data properties
                string certificate = data.certificate;
                Console.WriteLine(certificate);
                string certifiedFrom = data.certifiedFrom;
                Console.WriteLine(certifiedFrom);
                string year = data.year;
                Console.WriteLine(year);
                string screenshotName = "UpdateCertificationNegativeData";
                driver.CaptureScreenshot(screenshotName);
                certificationsPageObj.updateNegativeCertifications(certificate, certifiedFrom, year);

            }
        }

      
    }
}
