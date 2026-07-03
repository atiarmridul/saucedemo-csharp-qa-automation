using OpenQA.Selenium; // Gives this file Selenium tools like IWebDriver and By.
using OpenQA.Selenium.Support.UI; // Gives this file WebDriverWait so Selenium can wait for elements.

namespace SauceDemo.Framework.Pages; // Puts this file inside the framework Pages group.

public class CheckoutPage // This is a model of the checkout pages.
{
    private readonly IWebDriver driver; // Stores the browser so this page class can use it.

    private readonly By firstNameField = By.Id("first-name"); // Finds the First Name box.
    private readonly By lastNameField = By.Id("last-name"); // Finds the Last Name box.
    private readonly By postalCodeField = By.Id("postal-code"); // Finds the Postal Code box.
    private readonly By continueButton = By.Id("continue"); // Finds the Continue button.
    private readonly By finishButton = By.Id("finish"); // Finds the Finish button.
    private readonly By confirmationMessage = By.ClassName("complete-header"); // Finds the final success message.

    public CheckoutPage(IWebDriver driver) // This runs when we create a new CheckoutPage.
    {
        this.driver = driver; // Saves the browser that came from the step definition.
    }

    public void EnterCheckoutInformation(string firstName, string lastName, string postalCode) // Types customer details.
    {
        TypeIntoField(firstNameField, firstName); // Types the first name after the box is ready.
        TypeIntoField(lastNameField, lastName); // Types the last name after the box is ready.
        TypeIntoField(postalCodeField, postalCode); // Types the postal code after the box is ready.
        ClickElement(continueButton); // Clicks Continue after the button is ready.
        WaitForVisibleElement(finishButton); // Waits until the overview page is ready.
    }

    public void FinishOrder() // Finishes the order.
    {
        ClickElement(finishButton); // Clicks the Finish button after it is ready.
        WaitForUrlToContain("checkout-complete"); // Waits until SauceDemo opens the order complete page.
    }

    public string GetConfirmationMessage() // Reads the final success message.
    {
        return WaitForVisibleElement(confirmationMessage).Text; // Returns the final message text after it is ready.
    }

    private IWebElement WaitForVisibleElement(By locator) // Waits until an element is visible and usable.
    {
        WebDriverWait wait = new(driver, TimeSpan.FromSeconds(10)); // Gives Selenium up to 10 seconds.

        return wait.Until(browser => // Keeps checking until the element is ready.
        {
            IWebElement element = browser.FindElement(locator); // Finds the element.

            return element.Displayed && element.Enabled ? element : null; // Returns it only when we can see and use it.
        });
    }

    private void TypeIntoField(By locator, string text) // Focuses a text box and types into it.
    {
        IWebElement field = WaitForVisibleElement(locator); // Waits until the text box is ready.

        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", field); // Moves the text box into view.
        field.Click(); // Clicks inside the text box so it is focused.
        field.Clear(); // Removes any old text from the box.
        field.SendKeys(text); // Types the new text.
    }

    private void ClickElement(By locator) // Focuses a button or link and clicks it.
    {
        IWebElement element = WaitForVisibleElement(locator); // Waits until the element is ready.

        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", element); // Moves the element into view.
        element.Click(); // Clicks the element.
    }

    private void WaitForUrlToContain(string expectedUrlText) // Waits until the browser URL contains expected text.
    {
        WebDriverWait wait = new(driver, TimeSpan.FromSeconds(10)); // Gives Selenium up to 10 seconds.

        wait.Until(browser => browser.Url.Contains(expectedUrlText)); // Keeps checking the URL until it matches.
    }
}
