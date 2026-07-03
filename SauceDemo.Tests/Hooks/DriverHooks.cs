using OpenQA.Selenium; // Gives us the Selenium browser interface.
using OpenQA.Selenium.Chrome; // Gives us the Chrome browser driver.
using Reqnroll; // Gives us Reqnroll attributes like BeforeScenario and AfterScenario.
using SauceDemo.Framework.Drivers; // Lets this file store the browser for step definitions.

namespace SauceDemo.Tests.Hooks; // Puts this file inside the Hooks group.

[Binding] // Tells Reqnroll this class contains test setup/cleanup code.
public class DriverHooks // This class controls browser setup and cleanup.
{
    private IWebDriver? driver; // This will hold the browser after we open it.

    [BeforeScenario] // Reqnroll runs this before each scenario.
    public void OpenBrowser() // Opens a fresh browser for the scenario.
    {
        ChromeOptions options = new(); // Creates a box of Chrome startup settings.
        options.AddArgument("--headless=new"); // Runs Chrome without showing a window, which works better in GitHub Actions.
        options.AddArgument("--no-sandbox"); // Helps Chrome run inside Linux CI machines.
        options.AddArgument("--disable-dev-shm-usage"); // Helps avoid Chrome memory issues inside CI containers.
        options.AddArgument("--window-size=1920,1080"); // Gives Chrome a large screen size even when it is headless.

        driver = new ChromeDriver(options); // Opens Chrome with the settings above.

        BrowserDriver.Current = driver; // Shares the browser with the step definition class.
    }

    [AfterScenario] // Reqnroll runs this after each scenario.
    public void CloseBrowser() // Closes the browser after the scenario.
    {
        driver?.Quit(); // Closes Chrome if it was opened.
        driver?.Dispose(); // Cleans up the browser object from memory.
        BrowserDriver.Clear(); // Empties the shared browser box after cleanup.
    }
}
