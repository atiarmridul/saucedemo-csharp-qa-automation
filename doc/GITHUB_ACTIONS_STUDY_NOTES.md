# GitHub Actions Study Notes

GitHub Actions runs tests automatically in GitHub.

Simple idea:

```text
Push code to GitHub.
GitHub starts a clean computer.
GitHub runs the tests.
GitHub shows pass or fail.
```

Bangla:

```text
GitHub Actions GitHub-এর ভিতরে automatically test চালায়।
আপনি code push করলে GitHub নতুন machine-এ project চালিয়ে দেখে test pass করে কিনা।
```

## Project Context

This repo has one GitHub Actions workflow:

```text
.github/workflows/tests.yml
```

It runs this command:

```bash
dotnet test SauceDemoAutomation.slnx --configuration Release --no-restore
```

Bangla:

```text
এই project-এর GitHub Actions শুধু test suite run করার জন্য।
```

## Workflow File

This project has:

```text
.github/workflows/tests.yml
```

That file tells GitHub how to run the tests.

## When It Runs

```yaml
on:
  push:
  pull_request:
```

Meaning:

```text
Run tests when code is pushed.
Run tests when a pull request is opened or updated.
```

## Runner

```yaml
runs-on: ubuntu-latest
```

Meaning:

```text
Use a fresh Linux machine.
```

## Checkout Code

```yaml
- name: Checkout code
  uses: actions/checkout@v4
```

Meaning:

```text
Download your repository code into the GitHub machine.
```

## Setup .NET

```yaml
- name: Setup .NET
  uses: actions/setup-dotnet@v4
  with:
    dotnet-version: '10.0.x'
```

Meaning:

```text
Install .NET so the project can build and test.
```

## Restore

```yaml
dotnet restore SauceDemoAutomation.slnx
```

Meaning:

```text
Download project packages.
```

## Run Tests

```yaml
dotnet test SauceDemoAutomation.slnx --configuration Release --no-restore
```

Meaning:

```text
Build and run the test suite.
```

## Why This Matters

For the assignment, CI shows:

```text
Another engineer can run the tests.
The tests are not only working on your computer.
```

## Compared With Playwright CI

Playwright TypeScript CI often runs:

```yaml
- run: npm ci
- run: npx playwright install --with-deps
- run: npx playwright test
```

This C# Selenium project runs:

```yaml
- run: dotnet restore SauceDemoAutomation.slnx
- run: dotnet test SauceDemoAutomation.slnx --configuration Release --no-restore
```

Quick map:

```text
npm ci                    ~= dotnet restore
npx playwright test       ~= dotnet test
playwright.config.ts      ~= .csproj files + Reqnroll/NUnit setup
package.json dependencies ~= NuGet PackageReference entries
```

Main idea:

```text
Different commands, same purpose:
install dependencies, then run tests.
```

Bangla:

```text
Playwright project-এ npm ci আর npx playwright test চলে।
এই .NET project-এ dotnet restore আর dotnet test চলে।
কাজ একই: dependency install করা, তারপর test চালানো।
```

## Bangla Quick Reference

```text
GitHub Actions = GitHub-এর CI/CD system
workflow file = .github/workflows/tests.yml
push = code GitHub-এ পাঠানো
pull_request = PR open/update হলে run করা
runner = GitHub-এর temporary machine
checkout = repository code download করা
setup-dotnet = .NET install করা
dotnet restore = NuGet package download করা
dotnet test = test run করা
```

Playwright CI-এর সাথে মিল:

```text
npm ci                 ~= dotnet restore
npx playwright test    ~= dotnet test
package.json           ~= .csproj PackageReference
playwright.config.ts   ~= test/framework configuration files
```

সবচেয়ে গুরুত্বপূর্ণ:

```text
CI প্রমাণ করে test শুধু আপনার laptop-এ না,
fresh GitHub machine-এও run করতে পারে।
```
