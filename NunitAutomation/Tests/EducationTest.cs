using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using Microsoft.AspNetCore.Routing.Matching;
using MongoDB.Driver.Core.Misc;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NunitAutomation.TestModel;
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



        private EducationPage educationPageObj = new EducationPage();
        private ExtentReports extent;
        [Test, Order(1)]
        public void AddEducation_Test()
        {
            CommonDriver driver = new CommonDriver();
            driver.InitializeExtentReports();
            string testName = "AddEducationPositiveData";
            driver.SetupTest(testName);

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
                string screenshotName = "AddEducationPositiveData";
                driver.CaptureScreenshot(screenshotName);
                educationPageObj.addEducation(university, country, title, degree, graduationyear);

                string newEducationData = educationPageObj.getVerifyNewEducationData();
                Assert.AreEqual(newEducationData, country, "Actual data and Expected data do match");

            }


        }

        [Test, Order(2)]
        public void updateEducation_Test()
        {
            CommonDriver driver = new CommonDriver();
            driver.InitializeExtentReports();
            string testName = "UpdatePositiveEducationData";
            driver.SetupTest(testName);
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
                string screenshotName = "UpdatePositiveEducationData";
                driver.CaptureScreenshot(screenshotName);
                educationPageObj.updateEducation(university, country, title, degree, graduationyear);
                string newUpdatedEducation = educationPageObj.getverifyUpdatedEducationData();
                Assert.AreEqual(newUpdatedEducation, country, "Actual updated data and Expected updated data do match");

            }
        }
        [Test, Order(3)]
        public void deleteEducation_Test()
        {
            CommonDriver driver = new CommonDriver();
            driver.InitializeExtentReports();
            string testName = "DeleteEducation";
            driver.SetupTest(testName);
            string screenshotName = "Delete Education";
            driver.CaptureScreenshot(screenshotName);
            educationPageObj.deleteEduData();
            string deletedData = educationPageObj.getVerifyDeletedData();
            Assert.AreNotEqual(deletedData, "actual data and expert data do not match");

        }
    }
}