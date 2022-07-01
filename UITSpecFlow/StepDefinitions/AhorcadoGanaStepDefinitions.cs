using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using UITSpecFlow.Drivers;

namespace UITSpecFlow.StepDefinitions
{
    [Binding]
    public class AhorcadoGanaStepDefinitions
    {
        IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;

        public AhorcadoGanaStepDefinitions(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [Given(@"I have entered hola as the word to guess")]
        public void GivenIHaveEnteredHolaAsTheWordToGuess()
        {
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();
            driver.Url = "https://ahorcadoagiles.azurewebsites.net/ahorcado";
            Thread.Sleep(4000);
            driver.FindElement(By.Name("palabra")).SendKeys("hola" + Keys.Tab + Keys.Enter);
        }

        [When(@"I entered the correct sequence of chars '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenIEnteredTheCorrectSequenceOfChars(string h, string o, string l, string a)
        {
            driver.FindElement(By.Name("letra")).SendKeys(h + Keys.Tab + Keys.Enter);
            driver.FindElement(By.Name("letra")).SendKeys(o + Keys.Tab + Keys.Enter);
            driver.FindElement(By.Name("letra")).SendKeys(l + Keys.Tab + Keys.Enter);
            driver.FindElement(By.Name("letra")).SendKeys(a + Keys.Tab + Keys.Enter);
        }

        [Then(@"I won the game")]
        public void ThenIWonTheGame()
        {
            string result = driver.FindElement(By.Name("result")).Text;
            Assert.IsTrue(result.Equals("Ganaste!"));
        }
    }
}
