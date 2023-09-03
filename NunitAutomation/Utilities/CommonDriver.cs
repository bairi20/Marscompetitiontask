using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework;
using NunitAutomation.Pages;

namespace NunitAutomation.Utilities
{
    public class CommonDriver
    {
#pragma warning disable CS8618

        public static IWebDriver driver;
        private static ExtentReports extent;
        private static ExtentTest test;
        private static ExtentHtmlReporter htmlReporter;

        [SetUp]
        public void SetupAuction()
        {
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginSteps();

        }
        public void InitializeExtentReports()
        {

            if (extent == null)
            {
                extent = new ExtentReports();
                htmlReporter = new ExtentHtmlReporter("C:\\MVP Project\\NunitAutomation\\NunitAutomation\\Utilities\\CommonDriver.cs"); // Path to the report file
                extent.AttachReporter(htmlReporter);
            }

        }
        public void SetupTest(string testName)
        {
            test = extent.CreateTest(testName);
            test.Log(Status.Pass, "Test Passed");

        }

        public void CaptureScreenshot(string screenshotName)
        {
            try
            {
                ITakesScreenshot screenshotDriver = (ITakesScreenshot)driver;
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                string screenshotPath = Path.Combine("ScreenshotReport", $"{screenshotName}_{DateTime.Now:yyyyMMddHHmmss}.png");
                string fullPath = Path.Combine("C:\\MVP Project\\NunitAutomation\\NunitAutomation", screenshotPath);
                screenshot.SaveAsFile(fullPath, ScreenshotImageFormat.Png);
                //return fullPath;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error capturing screenshot: " + ex.Message);
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


