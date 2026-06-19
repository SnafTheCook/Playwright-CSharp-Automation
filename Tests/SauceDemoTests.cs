using Microsoft.Playwright.Xunit.v3;
using SauceDemo.UITests.Bases;
using SauceDemo.UITests.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SauceDemo.UITests.Tests
{
    public class SauceDemoTests : SauceDemoTestBase
    {
        [Fact]
        public async Task User_ShouldBeAbleTo_Login_And_AddItemsToCart()
        {
            var loginPage = new LoginPage(Page);
            await loginPage.GoToAsync();

            await loginPage.LoginAsync("standard_user", "secret_sauce");

            var inventoryPage = new InventoryPage(Page);
            await inventoryPage.AddBackpackToCartAsync();

            await Expect(inventoryPage.PageTitle).ToBeVisibleAsync();
            await Expect(inventoryPage.ShoppingCartBadge).ToHaveTextAsync("1");
        }

        [Theory]
        [InlineData("locked_out_user", "secret_sauce", "Epic sadface: Sorry, this user has been locked out.")]
        [InlineData("standard_user", "wrong_password", "Epic sadface: Username and password do not match any user in this service")]
        [InlineData("", "secret_sauce", "Epic sadface: Username is required")]
        public async Task Login_WithInvalidCredentials_ShouldShowCorrectErrorMessage(
            string username, string password, string expectedErrorMessage)
        {
            var loginPage = new LoginPage(Page);
            await loginPage.GoToAsync();

            await loginPage.LoginAsync(username, password);

            await Expect(loginPage.ErrorMessage).ToBeVisibleAsync();
            await Expect(loginPage.ErrorMessage).ToHaveTextAsync(expectedErrorMessage);
        }

        [Fact]
        public async Task Inventory_WhenSortedByPriceLowToHigh_ShouldDisplayCorrectOrder()
        {
            var loginPage = new LoginPage(Page);
            await loginPage.GoToAsync();

            await loginPage.LoginAsync("standard_user", "secret_sauce");

            var inventoryPage = new InventoryPage(Page);
            await inventoryPage.SortByPriceLowToHighAsync();

            var actualPrices = await inventoryPage.GetItemPricesAsync();

            var expectedPrices = actualPrices.OrderBy(p => p).ToList();

            Assert.Equal(expectedPrices, actualPrices);
        }

        [Fact]
        public async Task LoginPage_ShouldMaintainAccessibilityStructure()
        {
            var loginPage = new LoginPage(Page);
            await loginPage.GoToAsync();

            await Expect(Page).ToMatchAriaSnapshotAsync(@"
              - text: Swag Labs
              - textbox ""Username""
              - textbox ""Password""
              - button ""Login""
            ");
        }
    }
}
