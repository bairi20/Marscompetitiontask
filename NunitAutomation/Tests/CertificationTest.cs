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

namespace NunitAutomation.Tests
{
    [TestFixture]
    public class CertificationsTest : CommonDriver
    {
#pragma warning disable CS8618

        private CertificationsPage certificationsPageObj = new CertificationsPage();
        private ExtentReports extent;
        [Test, Order(1)]
        public void AddCertification_Test()
        {
            CommonDriver driver = new CommonDriver();
            driver.InitializeExtentReports();
            string testName = "AddCertification";
            driver.SetupTest(testName);

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
                string screenshotName = "AddPositiveCertificationData";
                driver.CaptureScreenshot(screenshotName);
                certificationsPageObj.addCertifications(certificate, certifiedFrom, year);
                string newCertification = certificationsPageObj.getVerifyCertificationList();
                Assert.AreEqual(newCertification, certificate, "actucal data and Expected data do match");
            }
        }
        [Test, Order(2)]
        public void UpdateCertification_Test()
        {
            CommonDriver driver = new CommonDriver();
            driver.InitializeExtentReports();
            string testName = "UpdateCertification";
            driver.SetupTest(testName);
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
                string screenshotName = "UpdateCertificationPositiveData";
                driver.CaptureScreenshot(screenshotName);
                certificationsPageObj.updateCertifications(certificate, certifiedFrom, year);
                string newUpdatedCertificate = certificationsPageObj.getVerifyUpdateCertificationsList();
                Assert.AreEqual(newUpdatedCertificate, certificate, "actucal data and Expected data do match");

            }
        }
        [Test, Order(3)]
        public void deleteCertification_Test()
        {
            CommonDriver driver = new CommonDriver();
            driver.InitializeExtentReports();
            string testName = "DeleteCertification";
            driver.SetupTest(testName);
            string screenshotName = "Delete Certificate";
            driver.CaptureScreenshot(screenshotName);
            certificationsPageObj.deleteCertification();
            string verifyDeletedData = certificationsPageObj.getVerifyDeleteCertificationList();
            Assert.AreNotEqual(verifyDeletedData, "actual data and expert data do not match");

        }



    }
}