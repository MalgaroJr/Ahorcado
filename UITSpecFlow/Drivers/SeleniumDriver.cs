﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UITSpecFlow.Drivers
{
    public class SeleniumDriver
    {
        private IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;

        public SeleniumDriver(ScenarioContext scenarioContex) => _scenarioContext = scenarioContex;

        public IWebDriver Setup()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("headless");
            driver = new RemoteWebDriver(new Uri("https://localhost:5025"), chromeOptions.ToCapabilities());
            //set the driver
            _scenarioContext.Set(driver, "WebDriver");

            driver.Manage().Window.Maximize();

            return driver;
        }
    }
}
