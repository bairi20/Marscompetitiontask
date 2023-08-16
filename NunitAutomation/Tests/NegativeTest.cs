using AventStack.ExtentReports;
using NUnit.Framework;
using NunitAutomation.Pages;
using NunitAutomation.TestModel;
using NunitAutomation.Utilities;
using NunitAutomation.Utilities.ExtentReport;
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

        private ExtentReports extent;
        private ExtentTest test;

        private LoginPage loginPageObj = new LoginPage();
        private EducationPage educationPageObj = new EducationPage();
        private CertificationsPage CertificationPageObj = new CertificationsPage();

        [SetUp]
        public void SetupAuction()
        {
            extent = BaseTestManager.getInstance();
            driver = new ChromeDriver();
            //Login page object identified and defined
            loginPageObj = new LoginPage();
            loginPageObj = new LoginPage();
            loginPageObj.LoginSteps();




        }

        [Test, Order(1)]
        public void AddNegativeEducation_Test()
        {
            test = extent.CreateTest("AddNegativeEducation_Test", "AddNegativeEducationData");

            
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
                test.Log(Status.Pass, "Test Passed");
                string screenshotPath = ScreenshotReport.CaptureScreenshot(driver, "AddNegativeEducation");
                if (!string.IsNullOrEmpty(screenshotPath))
                {
                    test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                }

                educationPageObj.AddNegativeEdu(university, country, title, degree, graduationyear);


            }
        }
       [Test, Order(2)]
        public void updateNegativeEducation_Test()
        {
            test = extent.CreateTest("UpdateNegativeEducation_Test", "UpdateEducationNegativeData");

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
                test.Log(Status.Pass, "Test Passed"); 
                string screenshotPath = ScreenshotReport.CaptureScreenshot(driver, "UpdateNegativeEducation");
                if (!string.IsNullOrEmpty(screenshotPath))
                {
                    test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                }
               educationPageObj = new EducationPage();
               educationPageObj.updateNegativeEdu(university, country, title, degree, graduationyear);



            }
        }
        [Test, Order(3)]
        public void AddNegativeCertification_Test()
        {
            test = extent.CreateTest("AddNegativeCertification_Test", "AddCertificationNegativeData");

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
                test.Log(Status.Pass, "Test Passed");
                string screenshotPath = ScreenshotReport.CaptureScreenshot(driver, "AddNegativeCertification");
                if (!string.IsNullOrEmpty(screenshotPath))
                {
                    test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                }

                // Perform the education test using the Education data
                CertificationPageObj.addNegativeCertifications(certificate, certifiedFrom, year);
            }
        }
        [Test, Order(4)]
        public void UpdateNegativeCertification_Test()
        {
            test = extent.CreateTest("UpdateNegativeCertification_Test", "UpdateCertificationNegativeData");

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
                test.Log(Status.Pass, "Test Passed");
                string screenshotPath = ScreenshotReport.CaptureScreenshot(driver, "UpdateNegativeCertification");
                if (!string.IsNullOrEmpty(screenshotPath))
                {
                    test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                }
                CertificationPageObj.updateNegativeCertifications(certificate, certifiedFrom, year);

            }
        }

        [TearDown]

        public void TearDownAction()
        {
            driver.Quit();
            extent.Flush();
        }
    }
}
