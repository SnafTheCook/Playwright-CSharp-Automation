using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace SauceDemo.UITests.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;
        private readonly ILocator _usernameInput;
        private readonly ILocator _passwordInput;
        private readonly ILocator _loginButton;

        public ILocator ErrorMessage { get; }

        public LoginPage(IPage page)
        {
            _page = page;

            _usernameInput = page.GetByTestId("username");
            _passwordInput = page.GetByTestId("password");
            _loginButton = page.GetByTestId("login-button");

            ErrorMessage = page.GetByTestId("error");
        }

        public async Task GoToAsync()
        {
            await _page.GotoAsync("https://www.saucedemo.com/");
        }

        public async Task LoginAsync(string username, string password)
        {
            await _usernameInput.FillAsync(username);
            await _passwordInput.FillAsync(password);
            await _loginButton.ClickAsync();
        }
    }
}
