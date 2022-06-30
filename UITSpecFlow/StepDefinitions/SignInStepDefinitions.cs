using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using UITSpecFlow.Drivers;

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
            driver.Url = "https://localhost:5025/registrar";
        }

        [Given(@"I select sign in")]
        public void GivenISelectSignIn()
        {
            throw new PendingStepException();
        }

        [Given(@"I entered my user name")]
        public void GivenIEnteredMyUserName()
        {
            throw new PendingStepException();
        }

        [Given(@"I entered my name")]
        public void GivenIEnteredMyName()
        {
            throw new PendingStepException();
        }

        [Given(@"I entered my password")]
        public void GivenIEnteredMyPassword()
        {
            throw new PendingStepException();
        }

        [Given(@"I confirmed my password")]
        public void GivenIConfirmedMyPassword()
        {
            throw new PendingStepException();
        }

        [When(@"I click on the sign in button")]
        public void WhenIClickOnTheSignInButton()
        {
            throw new PendingStepException();
        }

        [Then(@"A new User is created")]
        public void ThenANewUserIsCreated()
        {
            throw new PendingStepException();
        }
    }
}
