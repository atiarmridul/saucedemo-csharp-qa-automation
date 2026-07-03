# SauceDemo Automation

This project is for the Senior QA Automation Engineer take-home exercise.

It automates the SauceDemo website:

```text
https://www.saucedemo.com/
```

The project uses:

- C#
- .NET
- Reqnroll for Gherkin/BDD tests
- NUnit as the test runner
- Selenium WebDriver for browser automation
- ChromeDriver for running tests in Chrome
- Page Object Model for clean test structure
- GitHub Actions for CI test execution

## Project Structure

```text
SauceDemoAutomation/
├── .github/
│   └── workflows/
│       └── tests.yml
│
├── SauceDemo.Framework/
│   ├── Drivers/
│   │   └── BrowserDriver.cs
│   │
│   ├── Pages/
│   │   ├── CartPage.cs
│   │   ├── CheckoutPage.cs
│   │   ├── InventoryPage.cs
│   │   └── LoginPage.cs
│   │
│   └── SauceDemo.Framework.csproj
│
├── SauceDemo.Tests/
│   ├── Features/
│   │   └── Purchase.feature
│   │
│   ├── Hooks/
│   │   └── DriverHooks.cs
│   │
│   ├── StepDefinitions/
│   │   └── PurchaseStepDefinitions.cs
│   │
│   └── SauceDemo.Tests.csproj
│
├── README.md
└── SauceDemoAutomation.slnx
```

## What Each Folder Means

### `SauceDemo.Framework`

This is the reusable automation framework project.

It contains:

- Page Object Model classes
- Browser driver storage
- Selenium helper logic used by the tests

### `SauceDemo.Tests`

This is the Reqnroll/NUnit test project.

It contains:

- Gherkin feature files
- Step definitions
- Scenario setup and cleanup hooks

### `Features`

This folder has the Gherkin scenarios.

Gherkin is the plain-English test format:

```gherkin
Given I am on the SauceDemo login page
When I log in as a standard user
Then I should see something
```

### `StepDefinitions`

This folder connects Gherkin steps to C# code.

The step definitions should stay readable. They should not contain Selenium locator details.

### `Pages`

This folder is inside `SauceDemo.Framework`.

It contains Page Object Model classes.

Page classes know:

- How to find elements
- How to click buttons
- How to type into fields
- How to read page messages

### `Hooks`

This folder has setup and cleanup code.

Reqnroll runs the hook flow like this:

```text
BeforeScenario -> opens Chrome
Scenario       -> runs the test steps
AfterScenario  -> closes Chrome
```

### `Drivers`

This folder is inside `SauceDemo.Framework`.

It stores the browser driver during a scenario.

The hook opens Chrome and saves it in `BrowserDriver.Current`.

The step definitions use that browser to create page objects.

## Implemented Scenarios

The exercise asked for three scenarios. They are implemented in:

```text
SauceDemo.Tests/Features/Purchase.feature
```

Implemented scenarios:

1. Happy path - user completes an end-to-end purchase
2. Negative scenario - user submits invalid login input and sees an error message
3. Navigation - user can return to products without losing their cart selection

## Prerequisites

Install these before running the tests:

- .NET 10 SDK
- Google Chrome

ChromeDriver is managed through the `Selenium.WebDriver.ChromeDriver` NuGet package.

## Clone The Project

Clone the repository:

```bash
git clone <repository-url>
```

Go into the project folder:

```bash
cd SauceDemoAutomation
```

## How To Run Tests

From the project root, run:

```bash
dotnet test SauceDemoAutomation.slnx
```

Expected result:

```text
Passed: 3
Failed: 0
```

## GitHub Actions

The CI pipeline is here:

```text
.github/workflows/tests.yml
```

It runs the test suite on:

- push
- pull request

## Test User

The valid SauceDemo user is:

```text
Username: standard_user
Password: secret_sauce
```
