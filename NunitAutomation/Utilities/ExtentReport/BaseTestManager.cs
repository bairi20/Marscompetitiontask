using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using AventStack.ExtentReports.Core;
using AventStack.ExtentReports.Model;
using System.Diagnostics;
using NunitAutomation.Utilities;

namespace NunitAutomation.Utilities.ExtentReport
{
    public class BaseTestManager : CommonDriver
    {
#pragma warning disable CS8618

        private static ExtentReports extent;
        private static ExtentHtmlReporter htmlReporter;

        public static ExtentReports getInstance()
        {
            if (extent == null)
            {
                extent = new ExtentReports();
                htmlReporter = new ExtentHtmlReporter("C:\\MVP Project\\NunitAutomation\\NunitAutomation\\Utilities\\ExtentReport\\BaseTestManager.cs"); // Path to the report file
                extent.AttachReporter(htmlReporter);
            }
            return extent;
        }
    }
}