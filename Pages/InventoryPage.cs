using Microsoft.Playwright;
using SauceDemo.UITests.Bases;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SauceDemo.UITests.Pages
{
    public class InventoryPage : BasePage
    {
        private readonly ILocator _backpackAddToCartButton;
        private readonly ILocator _sortDropdown;
        private readonly ILocator _itemPrices;
        public ILocator PageTitle { get; }
        public ILocator ShoppingCartBadge { get; }

        public InventoryPage(IPage page) : base(page)
        {
            _backpackAddToCartButton = page.GetByTestId("add-to-cart-sauce-labs-backpack");
            _sortDropdown = page.GetByTestId("product-sort-container");
            _itemPrices = page.GetByTestId("inventory-item-price");

            PageTitle = page.GetByTestId("title");
            ShoppingCartBadge = page.GetByTestId("shopping-cart-badge");
        }

        public async Task AddBackpackToCartAsync()
        {
            await _backpackAddToCartButton.ClickAsync();
        }

        public async Task SortByPriceLowToHighAsync()
        {
            await _sortDropdown.SelectOptionAsync(["lohi"]);
        }

        public async Task<List<decimal>> GetItemPricesAsync()
        {
            var priceTexts = await _itemPrices.AllInnerTextsAsync();
            var prices = new List<decimal>();

            foreach (var text in priceTexts)
            {
                var cleanText = text.Replace("$", "", StringComparison.Ordinal);
                prices.Add(decimal.Parse(cleanText, CultureInfo.InvariantCulture));
            }

            return prices;
        }
    }
}
