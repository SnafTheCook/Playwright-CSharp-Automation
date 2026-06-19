using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace SauceDemo.UITests.Components
{
    public class TopNavComponent
    {
        private readonly ILocator _shoppingCartLink;
        private readonly ILocator _burgerMenuButton;
        private readonly ILocator _logoutSidebarLink;

        public TopNavComponent(IPage page)
        {
            _shoppingCartLink = page.GetByTestId("shopping-cart-link");
            _burgerMenuButton = page.GetByRole(AriaRole.Button, new() { Name = "Open Menu" });
            _logoutSidebarLink = page.GetByTestId("logout-sidebar-link");
        }

        public async Task OperCartAsync()
        {
            await _shoppingCartLink.ClickAsync();
        }

        public async Task LogoutAsync()
        {
            await _burgerMenuButton.ClickAsync();
            await _logoutSidebarLink.ClickAsync();
        }
    }
}
