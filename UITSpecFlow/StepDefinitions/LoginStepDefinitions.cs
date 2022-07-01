using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using UITSpecFlow.Drivers;

namespace UITSpecFlow.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;
        public LoginStepDefinitions(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [Given(@"I navigated to the Ahorcado web app")]
        public void GivenINavigatedToTheAhorcadoWebApp()
        {
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();
            driver.Url = "https://ahorcadoagiles.azurewebsites.net/";
            Thread.Sleep(4500);
        }

        [Given(@"I have entered hangman as my user name")]
        public void GivenIHaveEnteredHangmanAsMyUserName()
        {
            driver.FindElement(By.Name("user")).SendKeys("hangman");
        }

        [Given(@"I have entered (.*) as my password")]
        public void GivenIHaveEnteredAsMyPassword(int p0)
        {
            driver.FindElement(By.Name("password")).SendKeys(p0.ToString());
        }

        [When(@"I click on login")]
        public void WhenIClickOnLogin()
        {
            driver.FindElement(By.Name("password")).SendKeys(Keys.Tab + Keys.Enter);
        }

        [Then(@"I should be logged in")]
        public void ThenIShouldBeLoggedIn()
        {
            string result = driver.FindElement(By.Name("notificacion")).Text;
            Assert.IsTrue(result.Equals("Correcto"));

        }
    }
}
