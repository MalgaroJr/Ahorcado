using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using UITSpecFlow.Drivers;
using ClasesAhorcado;
using NUnit.Framework;

namespace UITSpecFlow.StepDefinitions
{
    [Binding]
    public class SignInStepDefinitions
    {
        IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;

        public SignInStepDefinitions(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [Given(@"I navigate to Ahorcado web app")]
        public void GivenINavigateToAhorcadoWebApp()
        {
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();
            driver.Url = "https://ahorcadoagiles.azurewebsites.net/";
            Thread.Sleep(4500);
        }

        [Given(@"I select sign in")]
        public void GivenISelectSignIn()
        {
            driver.FindElement(By.Name("registrar")).Click();
        }

        [Given(@"I entered Malga as my user name")]
        public void GivenIEnteredMyUserName()
        {
            driver.FindElement(By.Name("user")).SendKeys("Malga");
        }

        [Given(@"I entered Tomas as my name")]
        public void GivenIEnteredMyName()
        {
            driver.FindElement(By.Name("name")).SendKeys("Tomas");
        }

        [Given(@"I entered tomas1234 as my password")]
        public void GivenIEnteredMyPassword()
        {
            driver.FindElement(By.Name("password")).SendKeys("tomas1234");
        }

        [Given(@"I confirmed my password correctly")]
        public void GivenIConfirmedMyPassword()
        {
            driver.FindElement(By.Name("confirm")).SendKeys("tomas1234");
        }

        [When(@"I click on the sign in button")]
        public void WhenIClickOnTheSignInButton()
        {
            driver.FindElement(By.Name("confirm")).SendKeys(Keys.Tab + Keys.Enter);
        }

        [Then(@"A new User is created")]
        public void ThenANewUserIsCreated()
        {
            string result = driver.FindElement(By.Name("notificacion")).Text;
            Assert.IsTrue(result.Equals("Creando usuario..."));
        }
    }
}
