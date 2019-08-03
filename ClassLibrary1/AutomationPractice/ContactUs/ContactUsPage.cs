using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectLibrary.AutomationPractice.ContactUs
{
    public class ContactUsPage
    {
        IWebDriver webDriver;

        public ContactUsPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public enum Options
        {
            ByText,
            ByValue,
            ByIndex
        }

        public void SelectHeadingComboBox(Options option, string value)
        {
            IWebElement subjectHeading = webDriver.FindElement(By.Id("id_contact"));
            SelectElement subjectHeadingComboBox = new SelectElement(subjectHeading);
            switch (option)
            {
                case Options.ByText:
                    subjectHeadingComboBox.SelectByText(value);
                    break;
                case Options.ByValue:
                    subjectHeadingComboBox.SelectByValue(value);
                    break;
                case Options.ByIndex:
                    subjectHeadingComboBox.SelectByIndex(int.Parse(value));
                    break;
            }

        }

        public void SetEmailAddress(string email)
        {
            //capture email address input
            IWebElement emailAddress = webDriver.FindElement(By.Name("from"));
            emailAddress.SendKeys(email);
        }

        public void SetOrderReference(string orderReference)
        {
            //id_order
            IWebElement orderReferenceInput = webDriver.FindElement(By.Name("id_order"));
            orderReferenceInput.SendKeys(orderReference);
        }

        public void SetAttachFile(string filePath)
        {
            //C:\
            IWebElement attachFile = webDriver.FindElement(By.Id("fileUpload"));
            attachFile.SendKeys(filePath);
        }

        public void SetMessage(string message)
        {
            //message
            IWebElement messageInput = webDriver.FindElement(By.Id("message"));
            messageInput.SendKeys(message);
        }

        public void ClickSend()
        {
            //submitMessage
            IWebElement sendButton = webDriver.FindElement(By.Id("submitMessage"));
            sendButton.Click();
        }

        public void FillContactUsForm(Options option, string value, string email, string orderReference, string filePath, string message)
        {
            SelectHeadingComboBox(option, value);
            SetEmailAddress(email);
            SetOrderReference(orderReference);
            SetAttachFile(filePath);
            SetMessage(message);
            ClickSend();

        }

        public string GetConfirmationMessage()
        {
            IWebElement confirmationLabel = webDriver.FindElement(By.XPath("//p[@class='alert alert-success']"));
            string message = confirmationLabel.Text;
            return message;
        }

        //string expectedMessage = "Your message has been successfully sent to our team.";

        //Assert.AreEqual(expectedMessage, actualMesssage);




        //    ////p[@class='alert alert-success'] Your message has been successfully sent to our team.

        //    IWebElement confirmationLabel = webDriver.FindElement(By.XPath("//p[@class='alert alert-success']"));
        //string actualMesssage = confirmationLabel.Text;
        //string expectedMessage = "Your message has been successfully sent to our team.";

        //Assert.AreEqual(expectedMessage, actualMesssage);
    }
}
