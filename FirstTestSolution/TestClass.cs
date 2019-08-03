using ClassLibrary1.Steps.AutomationPractice.Navegation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PageObjectLibrary.AutomationPractice.ContactUs;
using PageObjectLibrary.AutomationPractice.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FirstTestSolution
{
    //decorator para el unit test (en esta clase existen test)
    [TestClass]
    public class TestClass
    {

        IWebDriver webDriver;
        NavigationSteps navigationSteps;

        public TestClass()
        {
          /*  webDriver = new ChromeDriver(@"C:\SeleniumWebDrivers");
            navigationSteps = new NavigationSteps(webDriver);*/
        }

        [TestMethod, TestCategory("ContactUs")]
        // verifica que el formulario de customer service se envia correctamente
        public void ContactUsFormIsSendCorrectly()
        {
            //navigate to automation practice site
           // webDriver.Navigate().GoToUrl("http://automationpractice.com/index.php?");

            /* MenuPage menuPage = new MenuPage(webDriver);
             menuPage.ClickContactUs();*/
            ContactUsPage contactUsPage = navigationSteps.NavigateToContactUs();

            Thread.Sleep(TimeSpan.FromSeconds(10));
            //ContactUsPage contactUsPage = new ContactUsPage(webDriver);

            contactUsPage.FillContactUsForm(ContactUsPage.Options.ByText, "Customer service", "@gmail.com", "1234", @"C:\test.txt", "Hola, compraste esto");

            string actualMessage = contactUsPage.GetConfirmationMessage();
            string expectedMessage = "Your message has been successfully sent to our team.";

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        /*
         * Assembly --->a nivel de proyecto
         * Class Initialize
         * Inicialize
         * Test
         * tear down
         * class teardown
         * Assembly
         
         */
        [TestInitialize]
        public void setUp()
        {
            webDriver = new ChromeDriver(@"C:\SeleniumWebDrivers");

            //waiter implisito
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            //waiter page
            webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);

            navigationSteps = new NavigationSteps(webDriver);
            webDriver.Navigate().GoToUrl("http://automationpractice.com/index.php?");
        }

        [TestCleanup]
        public void tearDown()
        {
            webDriver.Close();
            webDriver.Quit();
        }
        /*
        public void MyFirstTest()
        {
            
            
            //navigate to automation practice site
            webDriver.Navigate().GoToUrl("http://automationpractice.com/index.php?");

            //capture button
            IWebElement contactUsButton = webDriver.FindElement(By.Id("contact-link"));
            contactUsButton.Click();
            //capture select and capture combobox
            IWebElement subjectHeading = webDriver.FindElement(By.Id("id_contact"));
            SelectElement subjectHeadingComboBox = new SelectElement(subjectHeading);

            //how to select a value from combobox
            subjectHeadingComboBox.SelectByText("Customer service");
            
            //capture email address input
            IWebElement emailAddress = webDriver.FindElement(By.Name("from"));
            emailAddress.SendKeys("julieta.escalera@gmail.com");

            //id_order
            IWebElement orderReferenceInput = webDriver.FindElement(By.Name("id_order"));
            orderReferenceInput.SendKeys("1234");

            //C:\
            IWebElement attachFile= webDriver.FindElement(By.Id("fileUpload"));
            attachFile.SendKeys(@"C:\test.txt");

            //message
            IWebElement messageInput = webDriver.FindElement(By.Id("message"));
            messageInput.SendKeys("Hola, compraste esto");

            //submitMessage
            IWebElement sendButton = webDriver.FindElement(By.Id("submitMessage"));
            sendButton.Click();

            ////p[@class='alert alert-success'] Your message has been successfully sent to our team.
            
            IWebElement confirmationLabel = webDriver.FindElement(By.XPath("//p[@class='alert alert-success']"));
            string actualMesssage = confirmationLabel.Text;
            string expectedMessage = "Your message has been successfully sent to our team.";

            Assert.AreEqual(expectedMessage, actualMesssage);

        }*/

        [TestMethod, TestCategory("Contact us invalid data")]
        public void ContactUsFormIsNotSentWithInvalidData()
        {
            webDriver.Navigate().GoToUrl("http://automationpractice.com/index.php?");

            //capture button
            IWebElement contactUsButton = webDriver.FindElement(By.Id("contact-link"));
            contactUsButton.Click();           

            //submitMessage
            IWebElement sendButton = webDriver.FindElement(By.Id("submitMessage"));
            sendButton.Click();

            IWebElement confirmationLabel = webDriver.FindElement(By.XPath("//div[@class='alert alert-danger']"));
            string actualMesssage = confirmationLabel.Text;
            string expectedMessage = "There is 1 error\r\nInvalid email address.";

            Assert.AreEqual(expectedMessage, actualMesssage);

        }


    }
}
