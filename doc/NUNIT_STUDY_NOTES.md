# NUnit Study Notes

NUnit is the test runner used by this project.

Simple idea:

```text
NUnit finds tests.
NUnit runs tests.
NUnit reports pass or fail.
```

Bangla:

```text
NUnit test run করে এবং বলে test pass করলো নাকি fail করলো।
Playwright-এর expect যেমন result check করে, NUnit-এ Assert.That result check করে।
```

In this project, Reqnroll writes the test methods from the Gherkin feature file, and NUnit runs those generated tests.

## Project Context

In this repo, NUnit is used by:

```text
SauceDemo.Tests/SauceDemo.Tests.csproj
SauceDemo.Tests/StepDefinitions/PurchaseStepDefinitions.cs
```

You usually do not create normal NUnit `[Test]` methods here.

Reqnroll scenarios become NUnit tests.

Bangla:

```text
এই project-এ আপনি সাধারণত [Test] method লিখবেন না।
Purchase.feature scenario থেকে Reqnroll NUnit test generate করে।
```

## Where NUnit Is Used

The NUnit packages are in:

```text
SauceDemo.Tests/SauceDemo.Tests.csproj
```

Important packages:

```xml
<PackageReference Include="NUnit" Version="4.3.2" />
<PackageReference Include="NUnit3TestAdapter" Version="5.0.0" />
```

Meaning:

```text
NUnit             -> gives us test/assertion features
NUnit3TestAdapter -> lets dotnet test discover and run NUnit tests
```

## Running NUnit Tests

You run the tests with:

```bash
dotnet test SauceDemoAutomation.slnx
```

Even though you do not directly type `nunit`, NUnit is still the test framework running underneath.

## Assertions

An assertion means:

```text
Check if the actual result matches what we expected.
```

In this project, assertions are in:

```text
SauceDemo.Tests/StepDefinitions/PurchaseStepDefinitions.cs
```

Example:

```csharp
Assert.That(CheckoutPage.GetConfirmationMessage(), Is.EqualTo(ExpectedConfirmationMessage));
```

ELI5 meaning:

```text
Look at the confirmation message.
Check that it is exactly the message we expected.
If yes, pass.
If no, fail.
```

Bangla:

```text
Assertion মানে check করা:
actual result কি expected result-এর মতো?
মিলে গেলে pass, না মিললে fail।
```

## `Assert.That`

This is NUnit's readable assertion style.

Pattern:

```csharp
Assert.That(actualValue, matcher);
```

Example:

```csharp
Assert.That(LoginPage.GetErrorMessage(), Does.Contain(ExpectedLoginErrorText));
```

Meaning:

```text
Get the real error message from the page.
Check that it contains the expected error text.
```

## Common NUnit Matchers

```csharp
Is.EqualTo("text")
```

Means:

```text
The value must exactly equal "text".
```

```csharp
Does.Contain("text")
```

Means:

```text
The value must contain "text" somewhere inside it.
```

```csharp
Is.True
```

Means:

```text
The value must be true.
```

```csharp
Is.False
```

Means:

```text
The value must be false.
```

```csharp
Is.Not.Null
```

Means:

```text
The value must not be empty/null.
```

## NUnit Attributes

An attribute is extra information placed above a class or method.

It looks like this:

```csharp
[Test]
```

### `[Test]`

Marks a method as a test.

Example:

```csharp
[Test]
public void LoginTest()
{
}
```

Meaning:

```text
NUnit, please run this method as a test.
```

In this project, you usually do not write `[Test]` directly because Reqnroll generates the NUnit tests from `.feature` files.

### `[SetUp]`

Runs before each test.

Example:

```csharp
[SetUp]
public void SetUp()
{
}
```

Meaning:

```text
Before each test, run this setup code.
```

In this project, we use Reqnroll's `[BeforeScenario]` instead.

### `[TearDown]`

Runs after each test.

Example:

```csharp
[TearDown]
public void TearDown()
{
}
```

Meaning:

```text
After each test, run this cleanup code.
```

In this project, we use Reqnroll's `[AfterScenario]` instead.

## NUnit vs Reqnroll In This Project

Think of it like this:

```text
Reqnroll = reads Gherkin and connects steps
NUnit    = runs the tests and reports results
```

Reqnroll gives structure:

```gherkin
Scenario: Happy path
```

NUnit runs it as a real automated test.

## What You Should Remember

- NUnit is the test runner.
- `dotnet test` uses NUnit through the test adapter.
- Assertions decide pass or fail.
- Reqnroll generates NUnit tests from Gherkin scenarios.
- In this project, assertions live in step definitions.

## NUnit vs Playwright Test

Playwright TypeScript:

```typescript
import { test, expect } from "@playwright/test";

test("login error", async ({ page }) => {
  await page.goto("https://www.saucedemo.com");
  await page.locator("#login-button").click();
  await expect(page.locator("[data-test='error']")).toContainText("Username is required");
});
```

NUnit style C#:

```csharp
[Test]
public void LoginError()
{
    Assert.That(LoginPage.GetErrorMessage(), Does.Contain("Username is required"));
}
```

In this project, Reqnroll creates the `[Test]` method for you from the `.feature` file.

## Assertion Map

```text
Playwright expect(value).toBe(text)              ~= NUnit Assert.That(value, Is.EqualTo(text))
Playwright expect(locator).toContainText(text)   ~= NUnit Assert.That(textValue, Does.Contain(text))
Playwright expect(locator).toBeVisible()         ~= NUnit Assert.That(element.Displayed, Is.True)
Playwright expect(value).not.toBeNull()          ~= NUnit Assert.That(value, Is.Not.Null)
```

Main difference:

```text
Playwright expect can wait for UI conditions.
NUnit Assert checks the value you give it right now.
```

So with Selenium + NUnit, page objects often wait first, then NUnit asserts.

Bangla:

```text
Playwright expect অনেক সময় নিজে wait করে।
NUnit Assert সাধারণত wait করে না।
তাই Selenium page object আগে wait করে, তারপর Assert check করে।
```

## Bangla Quick Reference

```text
NUnit = C#/.NET test framework
dotnet test = NUnit test run করার command
Assert.That = result check করার method
Is.EqualTo = exact match check
Does.Contain = text-এর ভিতরে expected অংশ আছে কিনা check
[Test] = method-কে test বানায়
[SetUp] = test-এর আগে run হয়
[TearDown] = test-এর পরে run হয়
```

এই project-এ:

```text
Reqnroll scenario generate করে।
NUnit সেই generated test run করে।
Step definition-এর Then step-এ Assert.That থাকে।
```

Playwright-এর সাথে মিল:

```text
NUnit Assert.That(actual, Is.EqualTo(expected)) ~= expect(actual).toBe(expected)
NUnit Assert.That(text, Does.Contain(value))    ~= expect(locator).toContainText(value)
NUnit [SetUp]                                  ~= beforeEach
NUnit [TearDown]                               ~= afterEach
```

সবচেয়ে গুরুত্বপূর্ণ:

```text
NUnit browser control করে না।
NUnit শুধু test run করে এবং result pass/fail বলে।
Browser control করে Selenium।
```
