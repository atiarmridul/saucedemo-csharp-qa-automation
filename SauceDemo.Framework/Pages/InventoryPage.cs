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
        By addToCartButton = By.XPath($"//div[text()='{productName}']/ancestor::div[@class='inventory_item']//button"); // Finds the button inside the matching product card.

        WaitForVisibleElement(addToCartButton).Click(); // Clicks the Add to cart button for that product.
        WaitForVisibleElement(cartBadge); // Waits until the cart count appears.
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
