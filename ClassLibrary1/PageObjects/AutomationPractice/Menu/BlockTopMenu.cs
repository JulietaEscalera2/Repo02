using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.PageObjects.AutomationPractice.Menu
{
    public class BlockTopMenu
    {
        IWebDriver webDriver;
        public BlockTopMenu(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void ClickOnDresses()
        {
        }
    }
}
