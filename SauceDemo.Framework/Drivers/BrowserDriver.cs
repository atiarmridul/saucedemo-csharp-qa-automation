using System.Threading; // Gives this file AsyncLocal for scenario-safe browser storage.
using OpenQA.Selenium; // Gives this file the Selenium browser interface.

namespace SauceDemo.Framework.Drivers; // Puts this file inside the framework Drivers group.

public static class BrowserDriver // This is a shared box for the browser during a scenario.
{
    private static readonly AsyncLocal<IWebDriver?> CurrentDriver = new(); // Keeps each scenario's browser separate.

    public static IWebDriver Current // Gives other classes the browser for the current scenario.
    {
        get => CurrentDriver.Value ?? throw new InvalidOperationException("The browser has not been opened yet."); // Gives a clear error if setup did not run.
        set => CurrentDriver.Value = value; // Stores the browser that hooks open.
    }

    public static void Clear() // Removes the browser after the scenario is done.
    {
        CurrentDriver.Value = null; // Empties the browser box for this scenario.
    }
}
