using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace CMP_1005_Integration_Test_Demo
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver _webDriver;

        [TestInitialize]
        public void SetUp()
        {
            new DriverManager().SetUpDriver(new EdgeConfig());
            _webDriver = new EdgeDriver();
        }

        [TestMethod]
        public void TestMethod1()
        {
            _webDriver.Navigate().GoToUrl("https://www.google.ca/");
            Assert.IsTrue(_webDriver.Title.Contains("Google"));
        }

        [TestMethod]
        public void TestMethod2()
        {
            _webDriver.Navigate().GoToUrl("https://www.google.ca/");
            var input = _webDriver.FindElement(By.CssSelector("input[name='q']"));
            input.SendKeys("Hello");
            input.Submit();
        }

        [TestCleanup]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
