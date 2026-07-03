# Study Guide

This folder is for your personal study notes.

It is ignored by Git, so it will stay only on your machine.

Bangla:

```text
এই folder শুধু আপনার নিজের পড়াশোনার জন্য।
Git এই folder commit করবে না।
```

## What This Project Does

This project tests SauceDemo:

```text
https://www.saucedemo.com/
```

It uses:

- C#
- .NET
- Selenium
- Reqnroll
- NUnit
- Page Object Model

Bangla:

```text
এই project SauceDemo website test করে।
.NET C# project build/run করে।
Selenium browser চালায়।
Reqnroll English-like test scenario পড়ে।
NUnit test pass/fail বলে।
Page Object Model code গুছিয়ে রাখে।
```

## Project Context

Everything in this `doc/` folder is written for this project only:

```text
SauceDemoAutomation
```

When a note says "test project", it means:

```text
SauceDemo.Tests
```

When a note says "framework project", it means:

```text
SauceDemo.Framework
```

Bangla:

```text
এই doc folder-এর সব explanation এই SauceDemoAutomation project-এর জন্য।
এগুলো general .NET course না।
```

## Simple Project Map

```text
SauceDemo.Framework = page and browser helper code
SauceDemo.Tests     = test scenarios and step code
```

Bangla:

```text
SauceDemo.Framework = website page control করার reusable code
SauceDemo.Tests     = test scenario আর step-এর code
```

## Main Folders

```text
SauceDemo.Framework/Pages
```

Page classes live here.

Example:

```text
LoginPage.cs knows how to use the login page.
CartPage.cs knows how to use the cart page.
```

```text
SauceDemo.Framework/Drivers
```

Browser helper code lives here.

```text
SauceDemo.Tests/Features
```

Gherkin scenarios live here.

These are the plain-English test cases.

```text
SauceDemo.Tests/StepDefinitions
```

C# code that connects Gherkin steps to page classes lives here.

```text
SauceDemo.Tests/Hooks
```

Browser setup and cleanup code lives here.

## Test Flow

```text
1. Reqnroll reads Purchase.feature
2. BeforeScenario opens Chrome
3. Step definitions run the test steps
4. Page classes control the website
5. NUnit checks pass/fail
6. AfterScenario closes Chrome
```

## Page Object Model

Simple meaning:

```text
Keep Selenium element code inside page classes.
Keep test steps clean and readable.
```

Bangla:

```text
button/input খোঁজার code Page class-এর ভিতরে রাখুন।
test step যেন সহজ English-এর মতো পড়ে।
```

Good:

```text
LoginPage.Login(username, password)
```

Avoid:

```text
driver.FindElement(...) inside step definitions
```

## Run Tests

From the project root:

```bash
dotnet test SauceDemoAutomation.slnx
```

Expected:

```text
Passed: 3
Failed: 0
```

## Do Not Edit

Do not edit this generated file if it appears:

```text
Purchase.feature.cs
```

Edit this file instead:

```text
Purchase.feature
```

## More Notes

Read these when needed:

These notes compare C# / Selenium / NUnit / Reqnroll with JavaScript / TypeScript / Playwright where possible.

Bangla:

```text
আপনি যেহেতু Playwright JS জানেন, notes গুলোতে C# Selenium-এর সাথে Playwright-এর তুলনা রাখা হয়েছে।
```

```text
doc/DOTNET_BASICS_FOR_THIS_PROJECT.md
doc/CSharp_BASICS_FOR_THIS_PROJECT.md
doc/CHEATSHEET.md
doc/SELENIUM_STUDY_NOTES.md
doc/PAGE_OBJECT_MODEL_STUDY_NOTES.md
doc/PROJECT_FLOW_STUDY_NOTES.md
doc/SCENARIO_IMPLEMENTATION_MAP.md
doc/REQNROLL_STUDY_NOTES.md
doc/NUNIT_STUDY_NOTES.md
doc/GITHUB_ACTIONS_STUDY_NOTES.md
doc/TROUBLESHOOTING.md
```

## Best Study Order

1. `README.md`
2. `doc/STUDY_GUIDE.md`
3. `doc/CHEATSHEET.md`
4. `doc/DOTNET_BASICS_FOR_THIS_PROJECT.md`
5. `doc/PROJECT_FLOW_STUDY_NOTES.md`
6. `doc/SCENARIO_IMPLEMENTATION_MAP.md`
7. `doc/CSharp_BASICS_FOR_THIS_PROJECT.md`
8. `doc/REQNROLL_STUDY_NOTES.md`
9. `doc/NUNIT_STUDY_NOTES.md`
10. `doc/SELENIUM_STUDY_NOTES.md`
11. `doc/PAGE_OBJECT_MODEL_STUDY_NOTES.md`
12. `SauceDemo.Tests/Features/Purchase.feature`
13. `SauceDemo.Tests/StepDefinitions/PurchaseStepDefinitions.cs`
14. `SauceDemo.Framework/Pages/LoginPage.cs`
15. `doc/TROUBLESHOOTING.md`

## Bangla Quick Reference

```text
SauceDemo.Framework = reusable automation code
SauceDemo.Tests = actual test project
.slnx = full .NET solution/workspace
.csproj = one .NET project config
Features = English-like scenario
StepDefinitions = scenario line-এর C# code
Pages = website page control করার class
Hooks = browser open/close setup
Selenium = browser চালায়
Reqnroll = Gherkin scenario পড়ে
NUnit = test pass/fail বলে
GitHub Actions = GitHub-এ automatically test চালায়
```

Playwright mindset:

```text
আপনার Playwright .spec.ts-এর test story এখানে .feature file-এ।
আপনার Playwright page object-এর মতো এখানে Selenium page class আছে।
আপনার Playwright expect-এর মতো এখানে NUnit Assert.That আছে।
```
