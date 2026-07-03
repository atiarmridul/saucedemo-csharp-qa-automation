# C# Basics For This Project

This note explains only the C# ideas you see in this project.

Bangla:

```text
এই note-এ শুধু এই project-এ যেসব C# concept দেখবেন সেগুলো সহজভাবে explain করা হয়েছে।
```

## Project Context

This note explains C# using examples from this repo:

```text
SauceDemo.Framework/Pages/LoginPage.cs
SauceDemo.Framework/Pages/CheckoutPage.cs
SauceDemo.Tests/StepDefinitions/PurchaseStepDefinitions.cs
SauceDemo.Tests/Hooks/DriverHooks.cs
```

Bangla:

```text
এই C# note শুধু এই project-এর code বুঝার জন্য।
অন্য advanced C# topic এখানে রাখা হয়নি।
```

## `using`

Example:

```csharp
using OpenQA.Selenium;
```

Meaning:

```text
I want to use code from this library.
```

Like JavaScript import:

```javascript
import something from "library";
```

## `namespace`

Example:

```csharp
namespace SauceDemo.Framework.Pages;
```

Meaning:

```text
Put this class inside this named group.
```

It helps organize code.

## `class`

Example:

```csharp
public class LoginPage
```

Meaning:

```text
This is a box for login page code.
```

## `private`

Example:

```csharp
private readonly IWebDriver driver;
```

Meaning:

```text
Only this class can use this value.
```

## `public`

Example:

```csharp
public void Login(...)
```

Meaning:

```text
Other classes can call this method.
```

## `readonly`

Example:

```csharp
private readonly IWebDriver driver;
```

Meaning:

```text
Set this value once, then keep using it.
```

## `void`

Example:

```csharp
public void Open()
```

Meaning:

```text
This method does an action and returns nothing.
```

## `string`

Example:

```csharp
string username
```

Meaning:

```text
This value is text.
```

## Constructor

Example:

```csharp
public LoginPage(IWebDriver driver)
{
    this.driver = driver;
}
```

Meaning:

```text
When creating LoginPage, give it a browser.
Save that browser inside the class.
```

## Method

Example:

```csharp
public void ClickLoginButton()
{
    driver.FindElement(loginButton).Click();
}
```

Meaning:

```text
This is a reusable action.
When called, it clicks the login button.
```

## Property

Example:

```csharp
private LoginPage LoginPage => new(BrowserDriver.Current);
```

Meaning:

```text
When I ask for LoginPage, create a LoginPage using the current browser.
```

## `const`

Example:

```csharp
private const string StandardUsername = "standard_user";
```

Meaning:

```text
This value never changes.
```

## `null!`

Example:

```csharp
public static IWebDriver Current { get; set; } = null!;
```

Meaning:

```text
C#, trust me. This value will be set before I use it.
```

Use it carefully.

Bangla:

```text
null! মানে C#-কে বলা: "এখন null দেখাচ্ছে, কিন্তু run করার আগে value set হবে।"
ভুল জায়গায় ব্যবহার করলে runtime error হতে পারে।
```

## Best Beginner Rule

When reading C# code, ask:

```text
1. What class am I in?
2. What method is running?
3. What object is this method using?
4. What action is happening?
```

Bangla:

```text
C# code পড়ার সময় ভাবুন:
আমি কোন class-এ আছি?
কোন method চলছে?
কোন object ব্যবহার হচ্ছে?
কী action হচ্ছে?
```

## C# vs JavaScript/TypeScript Quick Map

```text
C# using                  ~= JS/TS import
C# namespace              ~= folder/module grouping
C# class                  ~= JS/TS class
C# private                ~= TS private
C# public                 ~= normal public method/property
C# string                 ~= TS string
C# void                   ~= TS void
C# const string           ~= TS const value: string
C# readonly field         ~= TS readonly property
C# method                 ~= JS/TS function inside a class
C# constructor            ~= JS/TS constructor
```

Bangla:

```text
C# অনেকটা TypeScript-এর মতো strict।
JavaScript-এ type না দিলেও চলে, কিন্তু C#-এ বেশিরভাগ জায়গায় type স্পষ্ট থাকে।
```

## Side-By-Side Class Example

C#:

```csharp
public class LoginPage
{
    private readonly IWebDriver driver;

    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
    }
}
```

TypeScript:

```typescript
class LoginPage {
  private readonly page: Page;

  constructor(page: Page) {
    this.page = page;
  }
}
```

Simple meaning:

```text
Both classes save the browser/page object so methods can use it later.
```

## Important Difference

C# is stricter than JavaScript.

In C#, this must say the type:

```csharp
string username
```

In JavaScript, you may write:

```javascript
const username = "standard_user";
```

In TypeScript, it is closer to C#:

```typescript
const username: string = "standard_user";
```

## Bangla Quick Reference

```text
using      = অন্য library/class ব্যবহার করার permission/import
namespace  = code group করে রাখার জায়গা
class      = related code রাখার box
private    = শুধু এই class-এর ভিতরে ব্যবহার করা যাবে
public     = অন্য class থেকেও ব্যবহার করা যাবে
readonly   = একবার value set হলে সাধারণত আর change করা হবে না
void       = method কাজ করবে, কিন্তু কিছু return করবে না
string     = text value
const      = fixed value, change হবে না
constructor = object create করার সময় প্রথমে run হয়
method     = class-এর ভিতরের function
property   = class-এর ভিতরের value access করার shortcut
```

Playwright/TypeScript-এর সাথে মিল:

```text
C# class       ~= TypeScript class
C# method      ~= TypeScript class method
C# constructor ~= TypeScript constructor
C# string      ~= TypeScript string
C# void        ~= TypeScript void
```

সবচেয়ে গুরুত্বপূর্ণ:

```text
C# JavaScript-এর চেয়ে strict।
TypeScript জানলে C# বুঝতে সহজ হবে।
```
