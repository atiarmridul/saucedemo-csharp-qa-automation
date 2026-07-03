# Scenario Implementation Map

This file maps the assignment scenarios to this project's files.

Bangla:

```text
এই file দেখায় কোন scenario কোন file/class দিয়ে implement করা হয়েছে।
Assignment বুঝতে এটা খুব useful।
```

## Main Feature File

All three assignment scenarios are in:

```text
SauceDemo.Tests/Features/Purchase.feature
```

## Scenario 1: Happy Path Purchase

Gherkin scenario:

```text
Happy path - user completes an end-to-end purchase
```

Main steps:

```text
Open login page
Login as standard user
Add Sauce Labs Backpack
Open cart
Start checkout
Enter checkout information
Finish order
Check confirmation message
```

Implemented through:

```text
SauceDemo.Tests/StepDefinitions/PurchaseStepDefinitions.cs
SauceDemo.Framework/Pages/LoginPage.cs
SauceDemo.Framework/Pages/InventoryPage.cs
SauceDemo.Framework/Pages/CartPage.cs
SauceDemo.Framework/Pages/CheckoutPage.cs
```

Bangla:

```text
এই scenario full user journey test করে:
login -> product add -> cart -> checkout -> order complete।
```

## Scenario 2: Negative Login Validation

Gherkin scenario:

```text
Negative scenario - user submits invalid login input and sees an error message
```

Main steps:

```text
Open login page
Login with wrong username/password
Check login error message
```

Implemented through:

```text
SauceDemo.Tests/StepDefinitions/PurchaseStepDefinitions.cs
SauceDemo.Framework/Pages/LoginPage.cs
```

Bangla:

```text
এই scenario ভুল login দিলে error message আসে কিনা check করে।
```

## Scenario 3: Navigation Without Losing Cart Selection

Gherkin scenario:

```text
Navigation - user can return to products without losing their cart selection
```

Main steps:

```text
Open login page
Login as standard user
Add Sauce Labs Backpack
Open cart
Return to products page
Check cart still has 1 item
```

Implemented through:

```text
SauceDemo.Tests/StepDefinitions/PurchaseStepDefinitions.cs
SauceDemo.Framework/Pages/LoginPage.cs
SauceDemo.Framework/Pages/InventoryPage.cs
SauceDemo.Framework/Pages/CartPage.cs
```

Bangla:

```text
এই scenario check করে cart page থেকে product page-এ ফিরে গেলেও selected product হারায় না।
```

## Common Setup For All Scenarios

All scenarios use:

```text
SauceDemo.Tests/Hooks/DriverHooks.cs
SauceDemo.Framework/Drivers/BrowserDriver.cs
```

Meaning:

```text
BeforeScenario opens Chrome.
AfterScenario closes Chrome.
BrowserDriver shares the browser with step definitions.
```

Bangla:

```text
প্রতিটি scenario-এর আগে browser open হয়।
প্রতিটি scenario-এর পরে browser close হয়।
```

## Quick Flow

```text
Purchase.feature
  -> PurchaseStepDefinitions.cs
    -> Page classes
      -> Selenium controls browser
        -> NUnit assertions check result
```

Playwright comparison:

```text
.feature scenario + step definition ~= Playwright .spec.ts test body
Page classes                     ~= Playwright page objects
NUnit Assert.That                ~= Playwright expect
```
