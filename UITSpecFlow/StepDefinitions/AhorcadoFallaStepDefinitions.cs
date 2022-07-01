using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using UITSpecFlow.Drivers;

namespace UITSpecFlow.StepDefinitions
{
    [Binding]
    public class AhorcadoFallaStepDefinitions
    {
        IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;

        public AhorcadoFallaStepDefinitions(ScenarioContext scenarioContext)=> _scenarioContext = scenarioContext;


        [Given(@"I have entered skere as the word to guess")]
        public void GivenIHaveEnteredSkereAsTheWordToGuess()
        {
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();
            driver.Url = "https://ahorcadoagiles.azurewebsites.net/ahorcado";
            Thread.Sleep(4500);
            driver.FindElement(By.Name("palabra")).SendKeys("skere" + Keys.Tab + Keys.Enter);
        }

        [When(@"I entered seven wrong letters one at a time")]
        public void WhenIEnteredWrongLettersOneAtATime()
        {
            string[] letras = { "a", "b", "c", "d", "f", "g", "h"};
            for (int i = 0; i < letras.Length; i++) 
                driver.FindElement(By.Name("letra")).SendKeys(letras[i]+Keys.Tab+Keys.Enter);       
        }

        [Then(@"I losed the game")]
        public void ThenILoseTheGame()
        {
            string result = driver.FindElement(By.Name("result")).Text;
            Assert.IsTrue(result.Equals("Perdiste! :("));
        }
    }
}
