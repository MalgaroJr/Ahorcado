using OpenQA.Selenium;
using TechTalk.SpecFlow;
using UITSpecFlow.Drivers;

namespace UITSpecFlow.Hooks
{
    [Binding]
    public sealed class HookInitialization
    {
        private readonly ScenarioContext _scenarioContext;

        public HookInitialization(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [BeforeScenario]
        public void BeforeScenario()
        {
            SeleniumDriver seleniumDriver = new SeleniumDriver(_scenarioContext);
            _scenarioContext.Set(seleniumDriver, "SeleniumDriver");
        }

        [BeforeScenario(Order = 1)]
        public static void FirstBeforeScenario()
        {
            
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("Selenium webdriver quit");
            _scenarioContext.Get<IWebDriver>("WebDriver").Quit();
            _scenarioContext.Get<IWebDriver>("WebDriver").Dispose();
        }
    }
}