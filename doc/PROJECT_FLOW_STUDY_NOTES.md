# Project Flow Study Notes

This note explains what happens when you run the tests.

Bangla:

```text
আপনি dotnet test চালালে ভিতরে ভিতরে কী হয়, এই note সেটা explain করে।
```

## Project Context

This flow is for this exact command:

```bash
dotnet test SauceDemoAutomation.slnx
```

And these exact projects:

```text
SauceDemo.Framework
SauceDemo.Tests
```

Bangla:

```text
এই flow শুধু এই SauceDemoAutomation project-এর test run explain করে।
```

## Command

You run:

```bash
dotnet test SauceDemoAutomation.slnx
```

Beginner note:

```text
dotnet is the command-line tool for .NET.
test means build the project and run the tests.
SauceDemoAutomation.slnx tells dotnet to use the whole solution.
```

Bangla:

```text
dotnet হলো .NET-এর command tool।
dotnet test মানে project build করে test চালানো।
.slnx দিলে পুরো solution-এর projectগুলো নিয়ে কাজ করে।
```

## What Happens

```text
1. .NET reads the solution file.
2. .NET builds SauceDemo.Framework.
3. .NET builds SauceDemo.Tests.
4. Reqnroll reads Purchase.feature.
5. NUnit starts running scenarios.
6. BeforeScenario opens Chrome.
7. Step definitions call page classes.
8. Page classes use Selenium.
9. NUnit assertions check results.
10. AfterScenario closes Chrome.
```

Playwright comparison:

```text
dotnet reads .slnx/.csproj files.
Node.js reads package.json/playwright.config.ts files.
```

Bangla:

```text
সহজভাবে:
feature file পড়ে -> browser open হয় -> step চলে -> page object website control করে -> assertion check করে -> browser close হয়।
```

## Important Files In Order

Start here:

```text
SauceDemo.Tests/Features/Purchase.feature
```

This is the test story.

Then read:

```text
SauceDemo.Tests/StepDefinitions/PurchaseStepDefinitions.cs
```

This connects the story to C# code.

Then read:

```text
SauceDemo.Framework/Pages/LoginPage.cs
SauceDemo.Framework/Pages/InventoryPage.cs
SauceDemo.Framework/Pages/CartPage.cs
SauceDemo.Framework/Pages/CheckoutPage.cs
```

These control the website.

Then read:

```text
SauceDemo.Tests/Hooks/DriverHooks.cs
SauceDemo.Framework/Drivers/BrowserDriver.cs
```

These manage the browser.

## One Scenario Example

Gherkin:

```gherkin
When I log in as a standard user
```

Step definition:

```csharp
LoginPage.Login(StandardUsername, StandardPassword);
```

Page object:

```csharp
EnterUsername(username);
EnterPassword(password);
ClickLoginButton();
```

Selenium:

```csharp
driver.FindElement(...).SendKeys(...);
driver.FindElement(...).Click();
```

## Simple Mental Model

```text
Feature file      = what we test
Step definitions = connect English to C#
Page objects     = control website pages
Selenium         = controls browser
NUnit            = says pass or fail
```

## Compared With A Playwright Project

Typical Playwright TypeScript flow:

```text
1. Playwright test runner reads *.spec.ts files.
2. beforeEach opens a fresh page/context.
3. Test code calls page objects.
4. Page objects use Playwright locators.
5. expect checks results.
6. afterEach/test runner cleans up.
```

This C# project flow:

```text
1. Reqnroll reads *.feature files.
2. NUnit runs the generated tests.
3. BeforeScenario opens Chrome.
4. Step definitions call page objects.
5. Page objects use Selenium locators.
6. Assert.That checks results.
7. AfterScenario closes Chrome.
```

Quick map:

```text
Playwright *.spec.ts        ~= Reqnroll *.feature + step definitions
Playwright beforeEach       ~= Reqnroll BeforeScenario
Playwright afterEach        ~= Reqnroll AfterScenario
Playwright page object      ~= Selenium page object
Playwright expect           ~= NUnit Assert.That
Playwright test runner      ~= NUnit test runner
```

Bangla:

```text
Playwright project-এ .spec.ts file থেকে test শুরু হয়।
এই project-এ .feature file থেকে test story শুরু হয়।
তারপর step definition সেই story-কে C# code-এর সাথে connect করে।
```

## Bangla Quick Reference

এই project run করলে flow:

```text
dotnet test চালান
.NET solution পড়ে
Framework project build হয়
Test project build হয়
Reqnroll feature file পড়ে
NUnit scenario run করে
BeforeScenario Chrome open করে
Step definition page object call করে
Page object Selenium দিয়ে website control করে
NUnit Assert result check করে
AfterScenario browser close করে
```

Playwright project-এর সাথে মিল:

```text
Playwright .spec.ts      ~= Reqnroll .feature + step definition
beforeEach               ~= BeforeScenario
afterEach                ~= AfterScenario
expect                   ~= Assert.That
page object              ~= page object
npx playwright test      ~= dotnet test
```

সবচেয়ে গুরুত্বপূর্ণ:

```text
Feature file বলে কী test হবে।
Step definition বলে কোন C# code run হবে।
Page object website control করে।
```
