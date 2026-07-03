# .NET Basics For This Project

This note explains the .NET parts of this project in a beginner-friendly way.

Bangla:

```text
আপনি যদি .NET নতুন হন, এই file আগে পড়ুন।
এখানে solution, project, NuGet, build, restore, test - এগুলো সহজভাবে explain করা হয়েছে।
```

## Project Context

This note is not a full .NET course.

It only explains the .NET parts used in this repo:

```text
SauceDemoAutomation.slnx
SauceDemo.Framework/SauceDemo.Framework.csproj
SauceDemo.Tests/SauceDemo.Tests.csproj
```

Bangla:

```text
এই note শুধু এই project-এ দরকারি .NET concept explain করে।
সব .NET topic এখানে নেই।
```

## What Is .NET?

.NET is the platform that builds and runs C# projects.

Simple idea:

```text
C# = language
.NET = system that builds/runs C# code
```

Playwright comparison:

```text
C#/.NET project ~= TypeScript/Node.js project
dotnet command  ~= npm/npx commands
```

Bangla:

```text
JavaScript project চালাতে Node.js লাগে।
C# project build/run করতে .NET লাগে।
```

## .NET SDK vs Runtime

For this project, you need the .NET SDK.

Simple idea:

```text
.NET Runtime = only runs already-built apps
.NET SDK     = builds apps and runs tests
```

Because this is an automation project, you need:

```text
.NET 10 SDK
```

Check your installed .NET version:

```bash
dotnet --info
```

Playwright comparison:

```text
.NET SDK ~= Node.js + npm tooling
```

Bangla:

```text
শুধু runtime থাকলে project build/test করা যাবে না।
এই project-এর জন্য SDK দরকার।
dotnet --info চালালে installed .NET information দেখা যায়।
```

## What Is A Solution?

This file is the solution:

```text
SauceDemoAutomation.slnx
```

Simple idea:

```text
A solution is a container for one or more projects.
```

This solution contains:

```text
SauceDemo.Framework
SauceDemo.Tests
```

Playwright comparison:

```text
.slnx file ~= top-level project/workspace
```

Bangla:

```text
Solution হলো বড় box।
এই box-এর ভিতরে এক বা একাধিক project থাকে।
```

## What Is A Project?

A project has a `.csproj` file.

This repo has two projects:

```text
SauceDemo.Framework/SauceDemo.Framework.csproj
SauceDemo.Tests/SauceDemo.Tests.csproj
```

Simple idea:

```text
.csproj tells .NET how to build that project.
```

Playwright comparison:

```text
.csproj ~= package.json + some config
```

Bangla:

```text
.csproj file বলে project কোন .NET version ব্যবহার করবে,
কোন package লাগবে, আর কোন project reference আছে।
```

## Framework Project vs Test Project

```text
SauceDemo.Framework = reusable automation code
SauceDemo.Tests     = actual Reqnroll/NUnit tests
```

Why split them?

```text
Framework code is reusable.
Test project stays focused on scenarios and assertions.
```

Bangla:

```text
Framework project-এ page object আর browser helper থাকে।
Test project-এ feature, step definition, hook থাকে।
এতে code clean থাকে।
```

## What Is NuGet?

NuGet is the package manager for .NET.

Simple idea:

```text
NuGet downloads libraries for C# projects.
```

This project uses NuGet packages like:

```text
Selenium.WebDriver
Selenium.WebDriver.ChromeDriver
Reqnroll
NUnit
```

Playwright comparison:

```text
NuGet PackageReference ~= npm package dependency
dotnet restore         ~= npm install / npm ci
```

Bangla:

```text
JavaScript-এ npm package install করেন।
.NET-এ NuGet package restore করা হয়।
```

## Important Commands

### Restore Packages

```bash
dotnet restore SauceDemoAutomation.slnx
```

Meaning:

```text
Download all required NuGet packages.
```

Playwright comparison:

```text
dotnet restore ~= npm ci
```

Bangla:

```text
project-এর দরকারি package download করে।
```

### Build Project

```bash
dotnet build SauceDemoAutomation.slnx
```

Meaning:

```text
Compile the C# code and check for build errors.
```

Playwright comparison:

```text
dotnet build ~= npm run build / tsc
```

Bangla:

```text
C# code compile করে দেখে syntax/type error আছে কিনা।
```

### Run Tests

```bash
dotnet test SauceDemoAutomation.slnx
```

Meaning:

```text
Build the projects, then run the tests.
```

Playwright comparison:

```text
dotnet test ~= npx playwright test
```

Bangla:

```text
test চালানোর main command এটাই।
```

## Generated Folders

.NET creates these folders:

```text
bin/
obj/
```

Meaning:

```text
bin = compiled output
obj = temporary build files
```

Do not edit them.

You can delete them safely. .NET will recreate them.

Bangla:

```text
bin আর obj generated folder।
এগুলো edit করবেন না।
delete করলে dotnet আবার বানাবে।
```

## Generated Reqnroll File

Reqnroll may create:

```text
Purchase.feature.cs
```

Do not edit it.

Edit this instead:

```text
Purchase.feature
```

Bangla:

```text
Purchase.feature.cs auto-generated।
আপনার edit করার file হলো Purchase.feature।
```

## Where To Start Reading

Start with these files:

```text
SauceDemoAutomation.slnx
SauceDemo.Framework/SauceDemo.Framework.csproj
SauceDemo.Tests/SauceDemo.Tests.csproj
SauceDemo.Tests/Features/Purchase.feature
```

Beginner mental model:

```text
.slnx    = whole workspace
.csproj  = one project config
.feature = English-like test scenario
.cs      = C# code
```

Bangla:

```text
প্রথমে solution/project structure বুঝুন।
তারপর feature file পড়ুন।
তারপর step definition এবং page object পড়ুন।
```
