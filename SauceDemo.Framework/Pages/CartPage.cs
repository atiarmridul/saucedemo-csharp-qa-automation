using OpenQA.Selenium; // Gives this file Selenium tools like IWebDriver and By.
using OpenQA.Selenium.Support.UI; // Gives this file WebDriverWait so Selenium can wait for page changes.

namespace SauceDemo.Framework.Pages; // Puts this file inside the framework Pages group.

public class CartPage // This is a model of the shopping cart page.
{
    private readonly IWebDriver driver; // Stores the browser so this page class can use it.

    private readonly By checkoutButton = By.Id("checkout"); // Finds the Checkout button.
    private readonly By continueShoppingButton = By.Id("continue-shopping"); // Finds the Continue Shopping button.

    public CartPage(IWebDriver driver) // This runs when we create a new CartPage.
    {
        this.driver = driver; // Saves the browser that came from the step definition.
    }

    public void StartCheckout() // Starts the checkout process.
    {
        WaitForVisibleElement(checkoutButton).Click(); // Clicks the Checkout button after it is ready.
        WaitForUrlToContain("checkout-step-one"); // Waits until the checkout information page opens.
    }

    public void ReturnToProductsPage() // Goes back from the cart to the products page.
    {
        WaitForVisibleElement(continueShoppingButton).Click(); // Clicks Continue Shopping after it is ready.
        WaitForUrlToContain("inventory"); // Waits until the products page opens again.
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
