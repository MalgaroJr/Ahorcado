using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;

namespace UITests
{
    [TestClass]
    public class UnitTest1
    {
        public IWebDriver driver;
        public string site= "https://google.com";
        private string appURL="";

        public void InitializeChrome()
        {
            var options = new ChromeOptions();
            options.AddArgument("headless");
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
        }

        public void CloseChrome()
        {
            driver.Quit();
            //driver.Close();
        }

        [TestMethod]
        public void GoogleSearchTest()
        {
            InitializeChrome();
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
            var result = driver.FindElement(googleResult1).Text;
            CloseChrome();
            Assert.IsTrue(result.Equals("Selenium"));
        }
        //*
        #region UserABMCTests
        [TestMethod]
        public void NewUser()
        {
            driver.Navigate().GoToUrl(appURL + "/");
            By regBtn = By.Name("registr");
            driver.FindElement(regBtn).Click();

            By ustInpt = By.Name("user");
            By nameInpt = By.Name("name");
            By pwdInpt = By.Name("password");
            By confpwd = By.Name("confirm");
            regBtn = By.Name("registrar");

            driver.FindElement(ustInpt).SendKeys("");
            driver.FindElement(nameInpt).SendKeys("");
            driver.FindElement(pwdInpt).SendKeys("");
            driver.FindElement(confpwd).SendKeys("");
            driver.FindElement(regBtn).Click();
            string result = driver.FindElement(By.Name("notificacion")).Text;
            driver.Quit();
            driver.Close();
            Assert.IsTrue(result.Equals("Perfil creado con exito!"));
        }
        /*
        [TestMethod]
        public void Login()
        {
            driver.Navigate().GoToUrl(appURL + "/");
            By ustInpt = By.Name("user");
            By pwdInpt = By.Name("password");
            By btnLog = By.Name("login");
            driver.FindElement(ustInpt).SendKeys("");
            driver.FindElement(pwdInpt).SendKeys("");
            driver.FindElement(btnLog).Click();
            By msg = By.Name("homemsg");
            string txt = driver.FindElement(msg).Text;
            driver.Quit();
            driver.Close();
            Assert.IsTrue(txt.Equals("Bienvenido"));
        }

        [TestMethod]
        public void Logout()
        {
            driver.Navigate().GoToUrl(appURL + "/");
            By optionsbtn = By.Name("options");
            By logoutbtn = By.Name("logout");
            driver.FindElement(optionsbtn).Click();
            driver.FindElement(logoutbtn).Click();
            By signintxt = By.Name("maintext");
            string s = driver.FindElement(signintxt).Text;
            driver.Quit();
            driver.Close();
            Assert.IsTrue(s.Equals("Sign In"));
        }

        [TestMethod]
        public void DeleteUser()
        {
            driver.Navigate().GoToUrl(appURL + "/");
            By btndelete = By.Name("delete");
            By ustInpt = By.Name("user");
            By pwdInpt = By.Name("password");
            By pwdInpt2 = By.Name("password2");
            driver.FindElement(btndelete).Click();
            driver.FindElement(ustInpt).SendKeys("");
            driver.FindElement(pwdInpt).SendKeys("");
            driver.FindElement(pwdInpt2).SendKeys(""); //se pide confirmar contra para eliminar perfil
            driver.FindElement(btndelete).Click();
            By resultmsg = By.Name("notficacion");
            string result = driver.FindElement(resultmsg).Text;
            driver.Quit();
            driver.Close();
            Assert.IsTrue(result.Equals("Perfil eliminado con exito!"));
        }
        #endregion
        */
    }
}