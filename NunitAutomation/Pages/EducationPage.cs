
using NunitAutomation.Utilities;
using OpenQA.Selenium;


namespace NunitAutomation.Pages
{
    public class EducationPage : CommonDriver
    {
        private static IWebElement educationTab => driver.FindElement(By.XPath("//a[text()='Education']"));
        private static IWebElement addNewButton => driver.FindElement(By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active']//div[contains(@class,'ui teal button')][normalize-space()='Add New']"));
        private static IWebElement universityTextBox => driver.FindElement(By.Name("instituteName"));
        private static IWebElement countryDropDown => driver.FindElement(By.Name("country"));
        private static IWebElement titleDropDown => driver.FindElement(By.Name("title"));
        private static IWebElement degreeTextBox => driver.FindElement(By.Name("degree"));
        private static IWebElement graduationyearDropDown => driver.FindElement(By.Name("yearOfGraduation"));
        private static IWebElement addButton => driver.FindElement(By.XPath("//input[@value='Add']"));
        private static IWebElement newEducationData => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
        private static IWebElement editIcon => driver.FindElement(By.XPath("*//table/tbody[1]/tr[1]/td[6]/span[1]/i"));
        private static IWebElement updateButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        private static IWebElement newUpdatedEducation => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[1]"));
        private static IWebElement deleteIcon => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr[1]/td[6]/span[2]/i"));
        private static IWebElement verifyDeletedData => driver.FindElement(By.XPath(".//div[@data-tab='third']//table[@class='ui fixed table']//td"));

        private static IWebElement messageBox => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));private static IWebElement verifyUpdatedEducationData => driver.FindElement(By.XPath(".//div[@data-tab='third']//table[@class='ui fixed table']//td"));
        private static IWebElement deletedData => driver.FindElement(By.XPath(".//div[@data-tab='third']//table[@class='ui fixed table']//td"));
        private static IWebElement cancelIcon => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[2]"));
        private static IWebElement updateCancelIcon => driver.FindElement(By.XPath("//input[@value='Cancel']"));
        public void addEducation(string university, string country, string title, string degree, string graduationyear)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Education']", 13);
            educationTab.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ui bottom attached tab segment tooltip-target active']//div[contains(@class,'ui teal button')][normalize-space()='Add New']", 12);
            addNewButton.Click();
            universityTextBox.SendKeys(university);
            countryDropDown.SendKeys(country);
            titleDropDown.SendKeys(title);
            degreeTextBox.SendKeys(degree);
            graduationyearDropDown.SendKeys(graduationyear);
            addButton.Click();

        }

        public string getVerifyNewEducationData()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]//table/tbody[last()]/tr/td[1]", 12);
            return newEducationData.Text;


        }
        public void updateEducation(string university, string country, string title, string degree, string graduationyear)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Education']", 10);
            educationTab.Click();
            Wait.WaitToBeClickable(driver, "XPath", "*//table/tbody[1]/tr[1]/td[6]/span[1]/i", 5);
            editIcon.Click();
            universityTextBox.Clear();
            universityTextBox.SendKeys(university);
            countryDropDown.SendKeys(country);
            titleDropDown.SendKeys(title);
            degreeTextBox.Clear();
            degreeTextBox.SendKeys(degree);
            graduationyearDropDown.SendKeys(graduationyear);
            Wait.WaitToBeClickable(driver, "XPath", "//input[@value='Update']", 8);
            updateButton.Click();
           
                
        }
        public string getverifyUpdatedEducationData()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[1]", 12);
            return newUpdatedEducation.Text;
        }
        public void deleteEduData()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//a[text() = 'Education']", 3);
            educationTab.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr[1]/td[6]/span[2]/i", 12);
            deleteIcon.Click();
        }
        public string getVerifyDeletedData()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[1]", 12);
            return deletedData.Text;
        }
        public void AddNegativeEdu(string university, string country, string title, string degree, string graduationyear)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Education']", 13);
            educationTab.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ui bottom attached tab segment tooltip-target active']//div[contains(@class,'ui teal button')][normalize-space()='Add New']", 12);
            addNewButton.Click();
            universityTextBox.SendKeys(university);
            countryDropDown.SendKeys(country);
            titleDropDown.SendKeys(title);
            degreeTextBox.SendKeys(degree);
            graduationyearDropDown.SendKeys(graduationyear);
            addButton.Click();
            Wait.WaitToBeVisible(driver, "Xpath", "//div[@class='ns-box-inner']", 10);
            string popupMessage = messageBox.Text;
            Console.WriteLine("messageBox.Text is: " + popupMessage);
            //string expectedMessage1 = "Education has been added";
            string expectedMessage2 = "Please enter all the fields";
            string expectedMessage3 = "This information is already exist.";
            //string expectedMessage4 = "Education information was invalid";
            string expectedMessage4 = "Duplicated data";
            if (popupMessage.Contains("has been added"))
            {
                Console.WriteLine("Education has been added successfully");
            }
            else if ((popupMessage == expectedMessage2 || popupMessage == expectedMessage3 || popupMessage == expectedMessage4))
            {
                cancelIcon.Click();
            }
            else
            {
                Console.WriteLine("Check Error");
            }


        }


        public void updateNegativeEdu(string university, string country, string title, string degree, string graduationyear)
        {
           Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Education']", 5);
            educationTab.Click();
            editIcon.Click();
            universityTextBox.Clear();
            universityTextBox.SendKeys(university);
            countryDropDown.SendKeys(country);
            titleDropDown.SendKeys(title);
            degreeTextBox.Clear();
            degreeTextBox.SendKeys(degree);
            graduationyearDropDown.SendKeys(graduationyear);
            updateButton.Click();
            Wait.WaitToBeVisible(driver, "Xpath", "//div[@class='ns-box-inner']", 10);
            string popupMessage = messageBox.Text;
            Console.WriteLine("messageBox.Text is: " + popupMessage);
            string expectedMessage2 = "Please enter all the fields";
            string expectedMessage3 = "This information is already exist.";
            if (popupMessage.Contains("as been updated"))
            {
                Console.WriteLine("Education as been updated successfully");
            }
            else if ((popupMessage == expectedMessage2) || (popupMessage == expectedMessage3))
            {
                updateCancelIcon.Click();
            }
            else
            {
                Console.WriteLine("Check Error");
            }
        }


    }


}


