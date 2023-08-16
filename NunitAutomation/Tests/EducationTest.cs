using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using Microsoft.AspNetCore.Routing.Matching;
using MongoDB.Driver.Core.Misc;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NunitAutomation.TestModel;
using NunitAutomation.Utilities.ExtentReport;
using NunitAutomation.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO.Enumeration;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using NunitAutomation.Pages;

namespace NunitAutomation.Tests
{
    [TestFixture]
    public class EducationTest : CommonDriver
    {
#pragma warning disable CS8618

        private ExtentReports extent;
        private ExtentTest test;
        private LoginPage loginPageObj = new LoginPage();
        private EducationPage educationPageObj = new EducationPage();
        [SetUp]
        public void SetupAuction()
        {
            extent = BaseTestManager.getInstance();
            driver = new ChromeDriver();
            //Login page object identified and defined
            loginPageObj = new LoginPage();
            loginPageObj.LoginSteps();
        }

        [Test, Order(1)]
        public void AddEducation_Test()
        {
            test = extent.CreateTest("AddEducation_Test", "AddEducationPositiveData");

            List<EducationTestModel> AddEducationPositiveData = Jsonhelper.ReadTestDataFromJson<EducationTestModel>("C:\\MVP Project\\NunitAutomation\\NunitAutomation\\JsonDataFiles\\AddEducationPositiveData.json");
            Console.WriteLine(AddEducationPositiveData.ToString());
            foreach (var data in AddEducationPositiveData)
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
                string screenshotPath = ScreenshotReport.CaptureScreenshot(driver, "AddEducation");
                if (!string.IsNullOrEmpty(screenshotPath))
                {
                    test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                }

                educationPageObj.addEducation(university, country, title, degree, graduationyear);

                string newEducationData = educationPageObj.getVerifyNewEducationData();
                if (country == newEducationData)
                {
                    //Assert.AreEqual(country, newEducationData, "Added Education and Expected Education do not match");
                    test.Pass("Added Education data and Expected education data match");
                }
                else
                {
                    //Console.WriteLine("Check error");
                    test.Fail("Added Education data and Expected education data do not match");

                }
                Console.WriteLine("Education has been Added");

            }


        }

        [Test, Order(2)]
        public void updateEducation_Test()
        {
            test = extent.CreateTest("UpdateEducation_Test", "UpdatePositiveEducationData");

            // Read test data from the JSON file using JsonHelper
            List<EducationTestModel> UpdatePositiveEducationData = Jsonhelper.ReadTestDataFromJson<EducationTestModel>("C:\\MVP Project\\NunitAutomation\\NunitAutomation\\JsonDataFiles\\UpdatePositiveEducationData.json");
            Console.WriteLine(UpdatePositiveEducationData.ToString());
            foreach (var data in UpdatePositiveEducationData)
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
                string screenshotPath = ScreenshotReport.CaptureScreenshot(driver, "UpdateEducation");
                if (!string.IsNullOrEmpty(screenshotPath))
                {
                    test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                }

                try
                {
                    //perform the education test using the Education data
                    educationPageObj = new EducationPage();
                    educationPageObj.updateEducation(university, country, title, degree, graduationyear);
                    string newUpdatednewUpdatedCertificate = educationPageObj.getverifyUpdatedEducationData(university, country, title, degree, graduationyear);
                    if (university== newUpdatednewUpdatedCertificate)

                    {
                        test.Pass("Updated Education and Expected Education match");
                    }
                    else
                    {
                        test.Fail("Updated Education and Expected Education do not match");
                    }
                    Console.WriteLine("Education Updated successfully ");
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine($"Upadated element not found", university.ToString());
                }

            }
        }
        [Test, Order(3)]
        public void deleteEducation_Test()
        {
            test = extent.CreateTest("deleteEducation_Test", "DeleteEducation");

            // Read test data from the JSON file using JsonHelper
            List<EducationTestModel> DeleteEducationData = Jsonhelper.ReadTestDataFromJson<EducationTestModel>("C:\\MVP Project\\NunitAutomation\\NunitAutomation\\JsonDataFiles\\DeleteEducationData.json");
            Console.WriteLine(DeleteEducationData.ToString());
            foreach (var data in DeleteEducationData)
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
                string screenshotPath = ScreenshotReport.CaptureScreenshot(driver, "DeleteEducation");
                if (!string.IsNullOrEmpty(screenshotPath))
                {
                    test.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                }

                //perform the education test using the Education data
                educationPageObj = new EducationPage();
                educationPageObj.deleteEduData(university, degree);
                string DeletedData = educationPageObj.getVerifyDeletedData();
                if (country != DeletedData)
                {
                    test.Pass("Deleted Education data and Expected Education data do not  match");

                }
                else
                {
                    test.Fail("Deleted Education data and Expected Education data do not  match");
                }
                Console.WriteLine("Education Entry successfully removed");
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