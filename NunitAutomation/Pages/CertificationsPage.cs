using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using NunitAutomation.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitAutomation.Pages
{
    public class CertificationsPage : CommonDriver

    {
        private static IWebElement certificationsTab => driver.FindElement(By.XPath("//a[text()='Certifications']"));
        private static IWebElement addNewButton => driver.FindElement(By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active']//div[contains(@class,'ui teal button')][normalize-space()='Add New']"));
        private static IWebElement certificateTextbox => driver.FindElement(By.CssSelector("input[placeholder='Certificate or Award']"));
        private static IWebElement certifiedFromTextbox => driver.FindElement(By.CssSelector("input[placeholder='Certified From (e.g. Adobe)']")); 
        private static IWebElement yearDropdown => driver.FindElement(By.Name("certificationYear"));
        private static IWebElement addButton => driver.FindElement(By.XPath("//input[@value='Add']"));
        private static IWebElement newCertification => driver.FindElement(By.XPath("//*[@id =\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]"));
        private static IWebElement editIcon => driver.FindElement(By.XPath("*//table/tbody[1]/tr[1]/td[4]/span[1]"));
        private static IWebElement updateButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        private static IWebElement newUpdatedCertificate => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr[1]/td[1]")); 
        private static IWebElement deleteIcon => driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/section[2]//form[1]//table[1]/tbody[1]/tr[1]/td[4]/span[2]/i[1]"));
        private static IWebElement verifyDeletedData => driver.FindElement(By.XPath("//div[@data-tab='third']//table[@class='ui fixed table']//td")); 
        private static IWebElement messageBox => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        private static IWebElement cancelIcon => driver.FindElement(By.XPath("//div[@class='five wide field']//input[@value='Cancel']"));
        private static IWebElement updateCancelIcon => driver.FindElement(By.XPath("//input[@value='Cancel']"));

        public void addCertifications(string certificate, string certifiedFrom, string year)
        {
            //Click on certification tab
            Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Certifications']", 10);
            certificationsTab.Click();
            //Click on AddNew button
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ui bottom attached tab segment tooltip-target active']//div[contains(@class,'ui teal button')][normalize-space()='Add New']", 10);
            addNewButton.Click();
            //Send the input
            certificateTextbox.SendKeys(certificate);
            certifiedFromTextbox.SendKeys(certifiedFrom);
            yearDropdown.SendKeys(year);
            //Click on Add button
            Wait.WaitToBeClickable(driver, "XPath", "//input[@value='Add']", 8);
            addButton.Click();
           
        }
        public string getVerifyCertificationList()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id =\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]", 8);
            return newCertification.Text;
        }
        public void updateCertifications(string certificate, string certifiedFrom, string year)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Certifications']", 10);
            certificationsTab.Click();
            editIcon.Click();
            certificateTextbox.Clear();
            certificateTextbox.SendKeys(certificate);
            certifiedFromTextbox.Clear();
            certifiedFromTextbox.SendKeys(certifiedFrom);
            yearDropdown.SendKeys(year);
            updateButton.Click();
            Console.WriteLine("Certification has been updated");


        }
        public string getVerifyUpdateCertificationsList()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr[1]/td[1]", 8);
            return newUpdatedCertificate.Text;
        }
        public void deleteCertification()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Certifications']", 8);
            certificationsTab.Click();
            deleteIcon.Click();
            
        }
        public string getVerifyDeleteCertificationList()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//div[@data-tab='third']//table[@class='ui fixed table']//td", 8);
            return verifyDeletedData.Text;
        }
        public void addNegativeCertifications(string certificate, string certifiedFrom, string year)
        {
            //Click on certification tab
            Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Certifications']", 10);
            certificationsTab.Click();
            //Click on AddNew button
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ui bottom attached tab segment tooltip-target active']//div[contains(@class,'ui teal button')][normalize-space()='Add New']", 10);
            addNewButton.Click();
            //Send the input
            certificateTextbox.SendKeys(certificate);
            Console.WriteLine("Certifications has been added");
            certifiedFromTextbox.SendKeys(certifiedFrom);
            yearDropdown.SendKeys(year);
            //Click on Add button
            Wait.WaitToBeClickable(driver, "XPath", "//input[@value='Add']", 8);
            addButton.Click();
            Wait.WaitToBeVisible(driver, "Xpath", "//div[@class='ns-box-inner']", 5);
            string popupMessage = messageBox.Text;
            Console.WriteLine("messageBox.Text is: " + popupMessage);
            //string expectedMessage1 = "AWS Beginner has been added to your certification";
            string expectedMessage1 = "This information is already exist.";
            string expectedMessage2 = "Duplicated data";
            string expectedMessage3 = "Please enter Certification Name, Certification From and Certification Year";
            if (popupMessage.Contains("has been added to your certification"))
            {
                Console.WriteLine("Certifications has been added successfully");
            }
            else if ((popupMessage == expectedMessage1) || (popupMessage == expectedMessage2) || (popupMessage == expectedMessage3))
            {
                cancelIcon.Click();
            }
            else
            {
                Console.WriteLine("Inside else condition, Check Error");
            }
        }

        public void updateNegativeCertifications(string certificate, string certifiedFrom, string year)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Certifications']", 10);
            certificationsTab.Click();
            editIcon.Click();
            certificateTextbox.Clear();
            certificateTextbox.SendKeys(certificate);
            certifiedFromTextbox.Clear();
            certifiedFromTextbox.SendKeys(certifiedFrom);
            yearDropdown.SendKeys(year);
            updateButton.Click();
            Console.WriteLine("Certification has been updated");
            //get the popup message text
            Wait.WaitToBeVisible(driver, "Xpath", "//div[@class='ns-box-inner']", 5);
            string popupMessage = messageBox.Text;
            Console.WriteLine("messageBox.Text is: " + popupMessage);
            // string expectedMessage1 = "Certifications as been updated.";
            string expectedMessage1 = "Please enter Certification Name, Certification From and Certification Year";
            string expectedMessage2 = "This information is already exist.";

            if (popupMessage.Contains("has been updated to your certification"))
            {
                Console.WriteLine("Certifications has been updated sucessfully");
            }
            else if ((popupMessage == expectedMessage1) || (popupMessage == expectedMessage2))

            {
                updateCancelIcon.Click();
            }
            else
            {
                Console.WriteLine("check error");
            }

        }


    }
}