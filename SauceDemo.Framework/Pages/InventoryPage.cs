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

        driver.FindElement(addToCartButton).Click(); // Clicks the Add to cart button for that product.
    }

    public void OpenShoppingCart() // Opens the cart page.
    {
        driver.FindElement(shoppingCartLink).Click(); // Clicks the cart icon/link.
        WaitForUrlToContain("cart"); // Waits until the cart page opens.
    }

    public string GetCartItemCount() // Reads the small number shown on the cart.
    {
        return driver.FindElement(cartBadge).Text; // Returns the cart number as text.
    }

    private void WaitForUrlToContain(string expectedUrlText) // Waits until the browser URL contains expected text.
    {
        WebDriverWait wait = new(driver, TimeSpan.FromSeconds(10)); // Gives Selenium up to 10 seconds.

        wait.Until(browser => browser.Url.Contains(expectedUrlText)); // Keeps checking the URL until it matches.
    }
}
