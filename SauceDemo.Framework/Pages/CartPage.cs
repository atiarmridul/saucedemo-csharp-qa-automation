using OpenQA.Selenium; // Gives this file Selenium tools like IWebDriver and By.

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
        driver.FindElement(checkoutButton).Click(); // Clicks the Checkout button.
    }

    public void ReturnToProductsPage() // Goes back from the cart to the products page.
    {
        driver.FindElement(continueShoppingButton).Click(); // Clicks Continue Shopping.
    }
}
