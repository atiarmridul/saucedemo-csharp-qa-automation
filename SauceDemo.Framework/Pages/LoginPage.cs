using OpenQA.Selenium; // Gives this file Selenium tools like IWebDriver and By.

namespace SauceDemo.Framework.Pages; // Puts this file inside the framework Pages group.

public class LoginPage // This is a model of the login page, like a helper for that screen.
{
    private const string LoginPageUrl = "https://www.saucedemo.com"; // The web address for the login page.

    private readonly IWebDriver driver; // Stores the browser so this page class can use it.

    private readonly By usernameField = By.Id("user-name"); // Tells Selenium how to find the username box.
    private readonly By passwordField = By.Id("password"); // Tells Selenium how to find the password box.
    private readonly By loginButton = By.Id("login-button"); // Tells Selenium how to find the login button.
    private readonly By errorMessage = By.CssSelector("[data-test='error']"); // Tells Selenium how to find the red error text.

    public LoginPage(IWebDriver driver) // This runs when we create a new LoginPage.
    {
        this.driver = driver; // Saves the browser that came from the test class.
    }

    public void Open() // This method opens the SauceDemo login page.
    {
        driver.Navigate().GoToUrl(LoginPageUrl); // Sends the browser to the login page.
    }

    public void EnterUsername(string username) // This method types only the username.
    {
        driver.FindElement(usernameField).SendKeys(username); // Finds the username box and types the username.
    }

    public void EnterPassword(string password) // This method types only the password.
    {
        driver.FindElement(passwordField).SendKeys(password); // Finds the password box and types the password.
    }

    public void ClickLoginButton() // This method clicks only the login button.
    {
        driver.FindElement(loginButton).Click(); // Finds the login button and clicks it.
    }

    public void Login(string username, string password) // This method performs the whole login action.
    {
        EnterUsername(username); // Step 1: type the username.
        EnterPassword(password); // Step 2: type the password.
        ClickLoginButton(); // Step 3: click login.
    }

    public string GetErrorMessage() // This method reads the login error message.
    {
        return driver.FindElement(errorMessage).Text; // Finds the error message and returns its text.
    }
}
