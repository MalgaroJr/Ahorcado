
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


        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl(site);
            By searchBar = By.Name("q");
            By btnSearch = By.Name("btnK");
            
            driver.FindElement(searchBar).SendKeys("skere");
           
            driver.FindElement(btnSearch).Click();
            Assert.IsTrue(true);
        }
    }
}