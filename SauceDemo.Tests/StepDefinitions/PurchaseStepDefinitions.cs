using OpenQA.Selenium; // Gives this file the Selenium browser interface.
using Reqnroll; // Gives this file Gherkin step attributes like Given, When, and Then.
using SauceDemo.Framework.Drivers; // Lets this file use the browser opened by DriverHooks.
using SauceDemo.Framework.Pages; // Lets this file use the page object classes.

namespace SauceDemo.Tests.StepDefinitions; // Puts this file inside the StepDefinitions group.

[Binding] // Tells Reqnroll this class contains Gherkin step code.
public class PurchaseStepDefinitions // This class connects plain English Gherkin steps to C# code.
{
    private const string StandardUsername = "standard_user"; // A valid SauceDemo username.
    private const string StandardPassword = "secret_sauce"; // The valid SauceDemo password.
    private const string FirstName = "John"; // Test first name for checkout.
    private const string LastName = "Doe"; // Test last name for checkout.
    private const string PostalCode = "12345"; // Test postal code for checkout.
    private const string ExpectedConfirmationMessage = "Thank you for your order!"; // Success message after order.
    private const string ExpectedLoginErrorText = "Username and password do not match"; // Important part of the login error.

    private LoginPage LoginPage => new(BrowserDriver.Current); // Builds the login page helper when a step needs it.
    private InventoryPage InventoryPage => new(BrowserDriver.Current); // Builds the products page helper when a step needs it.
    private CartPage CartPage => new(BrowserDriver.Current); // Builds the cart page helper when a step needs it.
    private CheckoutPage CheckoutPage => new(BrowserDriver.Current); // Builds the checkout page helper when a step needs it.

    [Given("I am on the SauceDemo login page")] // Matches the Gherkin line with the same text.
    public void GivenIAmOnTheSauceDemoLoginPage() // Opens the login page.
    {
        LoginPage.Open(); // Uses the page class to open SauceDemo.
    }

    [When("I log in as a standard user")] // Matches the standard user login step.
    public void WhenILogInAsAStandardUser() // Logs in with valid credentials.
    {
        LoginPage.Login(StandardUsername, StandardPassword); // Uses the page class to log in.
    }

    [When("I log in with username {string} and password {string}")] // Matches a login step with custom values.
    public void WhenILogInWithUsernameAndPassword(string username, string password) // Logs in with the values from Gherkin.
    {
        LoginPage.Login(username, password); // Uses the page class to try login.
    }

    [When("I add the {string} product to the cart")] // Matches a product add step.
    public void WhenIAddTheProductToTheCart(string productName) // Adds the named product.
    {
        InventoryPage.AddProductToCart(productName); // Uses the products page to add the product.
    }

    [When("I open the shopping cart")] // Matches the open cart step.
    public void WhenIOpenTheShoppingCart() // Opens the cart.
    {
        InventoryPage.OpenShoppingCart(); // Uses the products page cart link.
    }

    [When("I start checkout")] // Matches the checkout start step.
    public void WhenIStartCheckout() // Starts checkout.
    {
        CartPage.StartCheckout(); // Uses the cart page checkout button.
    }

    [When("I enter checkout information")] // Matches the checkout information step.
    public void WhenIEnterCheckoutInformation() // Enters checkout details.
    {
        CheckoutPage.EnterCheckoutInformation(FirstName, LastName, PostalCode); // Types fake customer information.
    }

    [When("I finish the order")] // Matches the finish order step.
    public void WhenIFinishTheOrder() // Completes the order.
    {
        CheckoutPage.FinishOrder(); // Uses the checkout page finish button.
    }

    [When("I return to the products page")] // Matches the return to products step.
    public void WhenIReturnToTheProductsPage() // Goes from cart back to products.
    {
        CartPage.ReturnToProductsPage(); // Uses the cart page continue shopping button.
    }

    [Then("I should see the order confirmation message")] // Matches the confirmation check step.
    public void ThenIShouldSeeTheOrderConfirmationMessage() // Checks the final order message.
    {
        Assert.That(CheckoutPage.GetConfirmationMessage(), Is.EqualTo(ExpectedConfirmationMessage)); // Checks success text.
    }

    [Then("I should see a login error message")] // Matches the login error check step.
    public void ThenIShouldSeeALoginErrorMessage() // Checks that login failed with an error.
    {
        Assert.That(LoginPage.GetErrorMessage(), Does.Contain(ExpectedLoginErrorText)); // Checks important error text.
    }

    [Then("the cart should still contain {int} item")] // Matches the cart count check step.
    public void ThenTheCartShouldStillContainItem(int expectedItemCount) // Checks that the cart did not lose the product.
    {
        Assert.That(InventoryPage.GetCartItemCount(), Is.EqualTo(expectedItemCount.ToString())); // Checks the cart badge number.
    }
}
