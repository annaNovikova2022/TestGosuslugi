using OpenQA.Selenium;

namespace TestGosuslugi
{
    public class Tests
    {
        private readonly By _signInButton = By.XPath("/html/body/portal-root/div[2]/header/lib-header/div/div/div[2]/div/lib-header-auth/button");
        private readonly By _inputButton = By.XPath("/html/body/esia-root/div/esia-login/div/div[1]/form/div[4]/button");
        private readonly By _cantSignInButton = By.XPath("/html/body/esia-root/div/esia-login/div/div[1]/form/div[5]/button");
        private readonly By _changePasswordButton = By.XPath("/html/body/esia-root/esia-modal/div/div[2]/div/esia-modal-login-faq/div/ul/li[2]/button");

#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
        public IWebDriver driver;
#pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Edge.EdgeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://gosuslugi.ru");
        }

        [Test]
        public void Test1()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var button = driver.FindElement(_signInButton);
            button.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            button = driver.FindElement(_inputButton);
            button.Click();
            button = driver.FindElement(_cantSignInButton);
            button.Click();

            button = driver.FindElement(_changePasswordButton);
            button.Click();

            var form = driver.FindElement(By.XPath("/html/body/esia-root/div/esia-recovery/div/div/div"));
            StreamWriter writer = new StreamWriter("log.txt", true);
            if (form != null)
            {                
                writer.WriteLine("Form opened successfull " + DateTime.Now.ToString());     
            }
            else
            {
                writer.WriteLine("Form opened unsuccessfull " + DateTime.Now.ToString());
            }
            writer.Close();
        }
    }
}