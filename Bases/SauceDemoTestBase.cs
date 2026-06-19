using Microsoft.Playwright;
using Microsoft.Playwright.Xunit.v3;
using System;
using System.Collections.Generic;
using System.Text;

namespace SauceDemo.UITests.Bases
{
    public abstract class SauceDemoTestBase : PageTest
    {
        public override BrowserNewContextOptions ContextOptions()
        {
            Playwright.Selectors.SetTestIdAttribute("data-test");

            var options = base.ContextOptions() ?? new BrowserNewContextOptions();
            options.BaseURL = "https://www.saucedemo.com";

            return options;
        }
    }
}
