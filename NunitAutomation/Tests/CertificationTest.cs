using AventStack.ExtentReports;
using NUnit.Framework;
using NunitAutomation.Pages;
using NunitAutomation.TestModel;
using NunitAutomation.Utilities;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NunitAutomation.Utilities.ExtentReport;

namespace NunitAutomation.Tests
{
    [TestFixture]
    public class CertificationsTest : CommonDriver
    {
#pragma warning disable CS8618

        private ExtentReports extent;
        private ExtentTest test;

       // private LoginPage loginPageObj = new LoginPage();
        private CertificationsPage CertificationsPageObj = new CertificationsPage();

        [SetUp]
        public void SetUpAction()
        {

            extent = BaseTestManager.getInstance();
            driver = new ChromeDriver();

            //Login page object identified and defined
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginSteps();
        }
        [Test, Order(1)]
        public void AddCertification_Test()
        {
            test = extent.CreateTest("AddCertification_Test", "AddPositiveCertificationData");

            // Read test data from the JSON file using JsonHelper
            List<CertificationTestModel> AddPositiveCertificationData = Jsonhelper.ReadTestDataFromJson<CertificationTestModel>("C:\\MVP Project\\NunitAutomation\\NunitAutomation\\JsonDataFiles\\AddPositiveCertificationData.json");
            Console.WriteLine(AddPositiveCertificationData.ToString());
            foreach (var data in AddPositiveCertificationData)
            {
                // Access individual test data properties
                string certificate = data.certificate;
                Console.WriteLine(certificate);
                string certifiedFrom = data.certifiedFrom;
                Console.WriteLine(certifiedFrom);
                string year = data.year;
                Console.WriteLine(year);
                test.Log(Status.Pass, "Test Passed");
                string screenshotPath = ScreenshotReport.CaptureScreenshot(driver, "AddCertification");
                if (!string.IsNullOrEmpty(screenshotPath))
                {
                    test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                }

                // Perform the education test using the Education data
                CertificationsPageObj.addCertifications(certificate, certifiedFrom, year);
                string newCertificate = CertificationsPageObj.getVerifyCertificationList();
                if (certificate == newCertificate)
                {
                    test.Pass("Added Certificate data and Expected Certificate data match");
                }
                else
                {
                    test.Fail("Added Certificate data and Expected Certificate data do not match");
                }
            }
        }
        [Test, Order(2)]
        public void UpdateCertification_Test()
        {
            test = extent.CreateTest("UpdateCertification_Test", "UpdateCertificationPositiveData");


            // Read test data from the JSON file using JsonHelper
            List<CertificationTestModel> UpdateCertificationPositiveData = Jsonhelper.ReadTestDataFromJson<CertificationTestModel>("C:\\MVP Project\\NunitAutomation\\NunitAutomation\\JsonDataFiles\\UpdateCertificationPositivedata.Json");
            Console.WriteLine(UpdateCertificationPositiveData.ToString());
            foreach (var data in UpdateCertificationPositiveData)
            {
                // Access individual test data properties
                string certificate = data.certificate;
                Console.WriteLine(certificate);
                string certifiedFrom = data.certifiedFrom;
                Console.WriteLine(certifiedFrom);
                string year = data.year;
                Console.WriteLine(year);
                test.Log(Status.Pass, "Test Passed");
                string screenshotPath = ScreenshotReport.CaptureScreenshot(driver, "UpdateCertification");
                if (!string.IsNullOrEmpty(screenshotPath))
                {
                    test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                }

                // Perform the education test using the Education data
                try
                {
                    CertificationsPageObj.updateCertifications(certificate, certifiedFrom, year);

                    string newUpdatedCertificate = CertificationsPageObj.getVerifyUpdateCertificationsList(certificate, certifiedFrom, year);

                    if (certificate== newUpdatedCertificate)

                    {
                        test.Pass("Updated Certificate data and Expected Certificate data match");
                    }
                    else
                    {
                        test.Fail("Updated Certificate data and Expected Certificate data do not match");
                    }
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine($"Upadated element not found", certificate.ToString());
                }

            }
        }
        [Test, Order(3)]
        public void DeleteCertification_Test()
        {
            test = extent.CreateTest("DeleteCertification_Test", "DeleteCertificationData");

            // Read test data from the JSON file using JsonHelper
            List<CertificationTestModel> DeleteCertificationData = Jsonhelper.ReadTestDataFromJson<CertificationTestModel>("C:\\MVP Project\\NunitAutomation\\NunitAutomation\\JsonDataFiles\\DeleteCertificationData.Json");
            Console.WriteLine(DeleteCertificationData.ToString());
            foreach (var data in DeleteCertificationData)
            {
                // Access individual test data properties
                string certificate = data.certificate;
                Console.WriteLine(certificate);
                string certifiedFrom = data.certifiedFrom;
                Console.WriteLine(certifiedFrom);
                string year = data.year;
                Console.WriteLine(year);
                test.Log(Status.Pass, "Test Passed");
                string screenshotPath = ScreenshotReport.CaptureScreenshot(driver, "DeleteCertification");
                if (!string.IsNullOrEmpty(screenshotPath))
                {
                    test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                }

                // Perform the education test using the Education data
                CertificationsPageObj.deleteCertification(certificate, year);

                string deletedCertificate = CertificationsPageObj.getVerifyDeleteCertificationList();
                if (certificate != deletedCertificate)
                {
                    test.Pass("Deleted Certificate data and Expected Certificate data do not  match");
                }
                else
                {
                    test.Fail("Deleted Certificate data and Expected Certificate data match");
                }
            }
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            extent.Flush();
        }

    }
}
