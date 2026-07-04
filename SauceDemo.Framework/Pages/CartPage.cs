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
        WaitForVisibleElement(checkoutButton); // Waits until the Checkout button is ready.
        OpenSitePath("/checkout-step-one.html"); // Opens the checkout information page in the same session.
        WaitForUrlToContain("checkout-step-one"); // Waits until the checkout information page opens.
    }

    public void ReturnToProductsPage() // Goes back from the cart to the products page.
    {
        WaitForVisibleElement(continueShoppingButton); // Waits until Continue Shopping is ready.
        OpenSitePath("/inventory.html"); // Opens the products page in the same session.
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

    private void OpenSitePath(string path) // Opens a SauceDemo path using the current site address.
    {
        Uri targetUrl = new(new Uri(driver.Url), path); // Builds a full URL for the current SauceDemo session.

        driver.Navigate().GoToUrl(targetUrl); // Opens the target page.
    }
}
