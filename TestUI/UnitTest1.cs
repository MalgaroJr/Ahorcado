
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestUI
{
    public class Tests
    {
        public IWebDriver driver;
        public string site;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            site = "https://google.com";
        }

        /*
        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl(site);
            By searchBar = By.Name("q");
            By btnSearch = By.Name("btnK");
            //By agreeBTN = By.Id("L2AGLb");

            //Thread.Sleep(1500);
            //driver.FindElement(agreeBTN).Click();
            
            Thread.Sleep(1500);
            driver.FindElement(searchBar).SendKeys("selenium");

            Thread.Sleep(1500);
            driver.FindElement(btnSearch).Click();
            By googleResult1 = By.XPath(".//h2//span[text()='Selenium']");
            var result=driver.FindElement(googleResult1);
            Assert.IsTrue(result.Text.Equals("Selenium"));
        }*/

        #region UserABMCTests
        [Test]
        public void NewUser()
        {
            driver.Navigate().GoToUrl(site);
            By regBtn = By.Name("registr");
            driver.FindElement(regBtn).Click();

            By ustInpt = By.Name("user");
            By nameInpt = By.Name("name");
            By pwdInpt = By.Name("password");
            By confpwd = By.Name("confirm");
            regBtn = By.Name("login");

            driver.FindElement(ustInpt).SendKeys("");
            driver.FindElement(nameInpt).SendKeys("");
            driver.FindElement(pwdInpt).SendKeys("");
            driver.FindElement(confpwd).SendKeys("");
            driver.FindElement(regBtn).Click();
            driver.Quit();
            driver.Close();
        }

        [Test]
        public void Login()
        {
            driver.Navigate().GoToUrl(site);
            By ustInpt = By.Name("user");
            By pwdInpt = By.Name("password");
            By btnLog = By.Name("login");
            driver.FindElement(ustInpt).SendKeys("");
            driver.FindElement(pwdInpt).SendKeys("");
            driver.FindElement(btnLog).Click();
            driver.Quit();
            driver.Close();
        } 

        [Test]
        public void Logout()
        {

        }

        [Test]
        public void DeleteUser()
        {

        }
        #endregion

    }
}