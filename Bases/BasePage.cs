using Microsoft.Playwright;
using SauceDemo.UITests.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace SauceDemo.UITests.Bases
{
    public abstract class BasePage
    {
        protected readonly IPage Page;
        public TopNavComponent TopNav { get; }

        protected BasePage(IPage page)
        {
            Page = page;
            TopNav = new TopNavComponent(page);
        }
    }
}
