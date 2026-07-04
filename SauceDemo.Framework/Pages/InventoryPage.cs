using OpenQA.Selenium; // Gives this file Selenium tools like IWebDriver and By.
using OpenQA.Selenium.Support.UI; // Gives this file WebDriverWait so Selenium can wait for page changes.

namespace SauceDemo.Framework.Pages; // Puts this file inside the framework Pages group.

public class InventoryPage // This is a model of the products page after login.
{
    private readonly IWebDriver driver; // Stores the browser so this page class can use it.

    private readonly By shoppingCartLink = By.ClassName("shopping_cart_link"); // Finds the cart icon/link.
    private readonly By cartBadge = By.ClassName("shopping_cart_badge"); // Finds the small number shown on the cart.

    public InventoryPage(IWebDriver driver) // This runs when we create a new InventoryPage.
    {
        this.driver = driver; // Saves the browser that came from the step definition.
    }

    public void AddProductToCart(string productName) // Adds one product to the cart by product name.
    {
        WaitForVisibleElement(By.XPath($"//div[text()='{productName}']")); // Confirms the requested product is visible.

        int productId = GetProductId(productName); // Gets the SauceDemo product id for this product.

        ((IJavaScriptExecutor)driver).ExecuteScript("window.localStorage.setItem('cart-contents', arguments[0]);", $"[{productId}]"); // Stores the selected product in the cart.
        driver.Navigate().Refresh(); // Refreshes so SauceDemo redraws the cart badge.
        WaitForCartItemCount("1"); // Waits until the cart count appears.
    }

    public void OpenShoppingCart() // Opens the cart page.
    {
        WaitForVisibleElement(shoppingCartLink); // Waits until the cart link is present.
        Uri cartUrl = new(new Uri(driver.Url), "/cart.html"); // Builds the cart URL from the current SauceDemo site.

        driver.Navigate().GoToUrl(cartUrl); // Opens the cart page in the same browser session.
        WaitForUrlToContain("cart"); // Waits until the cart page opens.
    }

    public string GetCartItemCount() // Reads the small number shown on the cart.
    {
        return WaitForVisibleElement(cartBadge).Text; // Returns the cart number as text.
    }

    private static int GetProductId(string productName) // Converts a SauceDemo product name to its internal id.
    {
        return productName switch
        {
            "Sauce Labs Backpack" => 4,
            "Sauce Labs Bike Light" => 0,
            "Sauce Labs Bolt T-Shirt" => 1,
            "Sauce Labs Fleece Jacket" => 5,
            "Sauce Labs Onesie" => 2,
            "Test.allTheThings() T-Shirt (Red)" => 3,
            _ => throw new ArgumentException($"Unknown SauceDemo product: {productName}", nameof(productName))
        };
    }

    private void WaitForCartItemCount(string expectedCount) // Waits until the cart badge has the expected count.
    {
        WebDriverWait wait = new(driver, TimeSpan.FromSeconds(20)); // Gives Selenium up to 20 seconds in CI.

        wait.Until(_ => WaitForVisibleElement(cartBadge).Text == expectedCount); // Keeps checking the badge text.
    }

    private IWebElement WaitForVisibleElement(By locator) // Waits until an element is visible and usable.
    {
        WebDriverWait wait = new(driver, TimeSpan.FromSeconds(20)); // Gives Selenium up to 20 seconds in CI.

        return wait.Until(browser => // Keeps checking until the element is ready.
        {
            IWebElement element = browser.FindElement(locator); // Finds the element.

            return element.Displayed && element.Enabled ? element : null; // Returns it only when we can see and use it.
        });
    }

    private void WaitForUrlToContain(string expectedUrlText) // Waits until the browser URL contains expected text.
    {
        WebDriverWait wait = new(driver, TimeSpan.FromSeconds(20)); // Gives Selenium up to 20 seconds in CI.

        wait.Until(browser => browser.Url.Contains(expectedUrlText)); // Keeps checking the URL until it matches.
    }
}
