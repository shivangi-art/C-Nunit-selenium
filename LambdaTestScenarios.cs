using OpenQA.Selenium;
using NUnit.Framework;

using OpenQA.Selenium.Support.UI;


namespace LambdaTestDemo
{
    [TestFixture]
    public class LambdaTestScenarios
    {
        private IWebDriver driver;


        [SetUp]
        public void SetUp() => driver = LambdaTestConfig.InitDriver();

        [Test]
        public void SimpleFormDemoTest()
        {
            driver.Navigate().GoToUrl("https://www.lambdatest.com/selenium-playground");
            driver.FindElement(By.LinkText("Simple Form Demo")).Click();
            Assert.IsTrue(driver.Url.Contains("simple-form-demo"));

            string message = "Welcome to LambdaTest";
            var inputBox = driver.FindElement(By.Id("user-message"));
            inputBox.SendKeys(message);

            driver.FindElement(By.Id("showInput")).Click();

            var displayedMsg = driver.FindElement(By.Id("message")).Text;
            Assert.AreEqual(message, displayedMsg);
        }

        [Test]
        public void DragAndDropSliderTest()
        {
            driver.Navigate().GoToUrl("https://www.lambdatest.com/selenium-playground");
            driver.FindElement(By.LinkText("Drag & Drop Sliders")).Click();

            var slider = driver.FindElement(By.XPath("//input[@value='15']"));
            var target = driver.FindElement(By.XPath("//output[@id='rangeSuccess']"));

            // move slider with JS
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].setAttribute('value', '95')", slider);
            js.ExecuteScript("arguments[0].dispatchEvent(new Event('change'))", slider);

            Assert.AreEqual("95", target.Text);
        }

        [Test]
        public void InputFormSubmitTest()
        {
            driver.Navigate().GoToUrl("https://www.lambdatest.com/selenium-playground");
            driver.FindElement(By.LinkText("Input Form Submit")).Click();

            var submit = driver.FindElement(By.CssSelector("button[type='submit']"));
            submit.Click();

            // Assert a required field is shown
            var nameField = driver.FindElement(By.Name("name"));
            Assert.AreEqual("true", nameField.GetAttribute("required"));

            // Fill all fields
            driver.FindElement(By.Name("name")).SendKeys("John Doe");
            driver.FindElement(By.Name("email")).SendKeys("john@example.com");
            driver.FindElement(By.Name("company")).SendKeys("LambdaTest");
            driver.FindElement(By.Name("website")).SendKeys("https://example.com");
            driver.FindElement(By.Name("city")).SendKeys("San Francisco");
            driver.FindElement(By.Name("address1")).SendKeys("123 Test St");
            driver.FindElement(By.Name("address2")).SendKeys("Suite 456");
            driver.FindElement(By.Name("state")).SendKeys("California");
            driver.FindElement(By.Name("zip")).SendKeys("94105");

            var countrydropdown = driver.FindElement(By.Name("country"));
            var selectcountry = new SelectElement(countrydropdown);
            selectcountry.SelectByText("united states");

            submit.Click();

            var success = driver.FindElement(By.CssSelector(".success-msg"));
            Assert.IsTrue(success.Text.Contains("Thanks for contacting us, we will get back to you shortly."));
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
                driver = null;
            }
        }
    }
}
