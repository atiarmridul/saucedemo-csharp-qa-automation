# Cheat Sheet

Use this file when you want a quick reminder.

Bangla:

```text
এই file হলো quick revision note।
কোন tool কী করে, কোন command চালাতে হয়, আর Playwright-এর সাথে কী মিল আছে - এগুলো এখানে আছে।
```

## Project Context

This cheat sheet is only for this repo:

```text
SauceDemoAutomation
```

Main files:

```text
SauceDemoAutomation.slnx
SauceDemo.Framework/SauceDemo.Framework.csproj
SauceDemo.Tests/SauceDemo.Tests.csproj
SauceDemo.Tests/Features/Purchase.feature
```

Bangla:

```text
এই cheat sheet শুধু এই SauceDemoAutomation project বুঝার জন্য।
```

## Tools

```text
C#                 = programming language
.NET               = platform that builds/runs the C# project
.slnx              = solution file; groups projects together
.csproj            = project config file
NuGet              = .NET package manager
Selenium           = controls the browser
ChromeDriver       = lets Selenium control Chrome
Reqnroll           = reads Gherkin feature files
NUnit              = runs tests and checks pass/fail
Page Object Model  = keeps page actions inside page classes
GitHub Actions     = runs tests automatically on GitHub
```

Bangla:

```text
Selenium browser চালায়।
Reqnroll .feature file পড়ে।
NUnit test pass/fail বলে।
Page Object Model code clean রাখে।
.slnx পুরো workspace ধরে রাখে।
.csproj package/config ধরে রাখে।
```

## .NET Quick Map

```text
SauceDemoAutomation.slnx = whole solution
SauceDemo.Framework.csproj = framework project config
SauceDemo.Tests.csproj = test project config
PackageReference = NuGet dependency
bin/ = compiled output
obj/ = temporary build files
```

Playwright comparison:

```text
.slnx              ~= workspace/root project
.csproj            ~= package.json + config
PackageReference   ~= dependencies in package.json
dotnet restore     ~= npm ci
dotnet build       ~= npm run build / tsc
dotnet test        ~= npx playwright test
dotnet --info      ~= node --version + npm --version
```

Bangla:

```text
.NET project বুঝতে হলে .slnx আর .csproj আগে বুঝুন।
.slnx সব project একসাথে ধরে।
.csproj বলে project কীভাবে build হবে আর কোন package লাগবে।
```

Useful .NET commands:

```bash
dotnet --info
dotnet restore SauceDemoAutomation.slnx
dotnet build SauceDemoAutomation.slnx
dotnet test SauceDemoAutomation.slnx
```

## Project Map

```text
SauceDemo.Framework
  Drivers/     -> browser helper
  Pages/       -> page object classes

SauceDemo.Tests
  Features/        -> Gherkin scenarios
  StepDefinitions/ -> Gherkin step-এর C# code
  Hooks/           -> browser open/close setup
```

## Run Tests

```bash
dotnet test SauceDemoAutomation.slnx
```

Expected:

```text
Passed: 3
Failed: 0
```

Playwright comparison:

```text
dotnet test              ~= npx playwright test
SauceDemoAutomation.slnx ~= whole Playwright project
.csproj packages         ~= package.json dependencies
```

## Reqnroll Quick Map

```text
Feature  = big behavior area
Scenario = one test case
Given    = starting condition
When     = action
Then     = expected result
And      = continue previous step type
```

Bangla:

```text
Given = test কোথা থেকে শুরু
When = user কী action করে
Then = expected result কী
```

Playwright comparison:

```text
Reqnroll Scenario        ~= Playwright test(...)
Given/When/Then          ~= test steps
BeforeScenario           ~= beforeEach
AfterScenario            ~= afterEach
```

## NUnit Quick Map

```csharp
Assert.That(actual, Is.EqualTo(expected));
Assert.That(text, Does.Contain(expectedText));
```

Playwright comparison:

```typescript
expect(actual).toBe(expected);
await expect(locator).toContainText(expectedText);
```

Bangla:

```text
Assert.That মানে result check করা।
মিললে pass, না মিললে fail।
```

## Selenium Quick Map

```csharp
driver.Navigate().GoToUrl(url);
driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
driver.FindElement(By.Id("login-button")).Click();
driver.Quit();
```

Playwright comparison:

```typescript
await page.goto(url);
await page.locator("#user-name").fill("standard_user");
await page.locator("#login-button").click();
await browser.close();
```

Bangla:

```text
FindElement = element খোঁজা
SendKeys = input-এ text লেখা
Click = click করা
Quit = browser বন্ধ করা
```

## Page Object Model Rule

Good:

```text
Step definition calls LoginPage.Login(...)
LoginPage contains driver.FindElement(...)
```

Avoid:

```text
Step definition directly uses driver.FindElement(...)
```

Bangla:

```text
locator আর Selenium action Page class-এ রাখুন।
Step definition শুধু readable test action বলবে।
```

## Files You Usually Edit

```text
SauceDemo.Tests/Features/Purchase.feature
SauceDemo.Tests/StepDefinitions/PurchaseStepDefinitions.cs
SauceDemo.Framework/Pages/*.cs
```

## Files You Should Not Edit

```text
bin/
obj/
*.feature.cs
```

Bangla:

```text
Purchase.feature.cs generated file।
এটা edit করবেন না।
Purchase.feature edit করবেন।
```
