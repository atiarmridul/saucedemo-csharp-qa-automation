# Page Object Model Study Notes

Page Object Model is a way to organize automation code.

Simple idea:

```text
One web page = one C# class
```

Bangla:

```text
Page Object Model মানে: website-এর প্রতিটি page-এর জন্য আলাদা class রাখা।
যেমন Login page-এর জন্য LoginPage.cs।
```

## Project Context

This repo has these page objects:

```text
SauceDemo.Framework/Pages/LoginPage.cs
SauceDemo.Framework/Pages/InventoryPage.cs
SauceDemo.Framework/Pages/CartPage.cs
SauceDemo.Framework/Pages/CheckoutPage.cs
```

Each class matches a real SauceDemo page or screen.

Bangla:

```text
এই project-এ প্রতিটি SauceDemo page/screen-এর জন্য আলাদা Page class আছে।
```

## Why Use It?

Without Page Object Model, tests become messy.

Bad:

```text
Test step finds username field.
Test step types password.
Test step clicks checkout.
Test step finds cart count.
```

Better:

```text
LoginPage handles login.
InventoryPage handles products.
CartPage handles cart.
CheckoutPage handles checkout.
```

## This Project's Page Classes

```text
LoginPage.cs
```

Handles:

- Open login page
- Enter username
- Enter password
- Click login
- Read login error

```text
InventoryPage.cs
```

Handles:

- Add product to cart
- Open shopping cart
- Read cart item count

```text
CartPage.cs
```

Handles:

- Start checkout
- Return to products page

```text
CheckoutPage.cs
```

Handles:

- Enter checkout information
- Finish order
- Read confirmation message

## Page Class Pattern

Most page classes look like this:

```text
1. Store browser
2. Store locators
3. Create action methods
```

Example:

```csharp
private readonly By loginButton = By.Id("login-button");

public void ClickLoginButton()
{
    driver.FindElement(loginButton).Click();
}
```

Meaning:

```text
Remember where the login button is.
Create a method that clicks it.
```

## Step Definitions Should Be Clean

Good:

```csharp
LoginPage.Login(username, password);
```

Avoid:

```csharp
driver.FindElement(By.Id("user-name")).SendKeys(username);
```

Why?

```text
Step definitions should describe test behavior.
Page classes should handle page details.
```

## Easy Rule

If the code knows about:

```text
By.Id
By.CssSelector
By.XPath
driver.FindElement
```

It probably belongs in a page class.

Bangla:

```text
যদি code-এ By.Id, By.XPath, driver.FindElement থাকে,
তাহলে সেটা সাধারণত Page class-এ থাকা উচিত।
Step definition-এ না।
```

## Page Object Model In Playwright

The idea is the same in Selenium and Playwright.

Selenium C# page object:

```csharp
public class LoginPage
{
    public void Login(string username, string password)
    {
        EnterUsername(username);
        EnterPassword(password);
        ClickLoginButton();
    }
}
```

Playwright TypeScript page object:

```typescript
class LoginPage {
  constructor(private readonly page: Page) {}

  async login(username: string, password: string) {
    await this.page.locator("#user-name").fill(username);
    await this.page.locator("#password").fill(password);
    await this.page.locator("#login-button").click();
  }
}
```

Same idea:

```text
The test says "login".
The page object knows how login works.
```

## Selenium vs Playwright Page Object Difference

```text
Selenium page object stores IWebDriver.
Playwright page object stores Page.
```

```text
Selenium actions are usually synchronous in C#.
Playwright actions are usually async and use await.
```

Bangla:

```text
Playwright TypeScript-এ প্রায় সব action-এর আগে await থাকে।
এই C# Selenium project-এ action গুলো বেশিরভাগ জায়গায় সরাসরি method call হিসেবে লেখা।
```

## Bangla Quick Reference

```text
Page Object Model = page-wise code organize করার pattern
একটা page = একটা class
LoginPage = login page-এর locator/action
InventoryPage = product page-এর locator/action
CartPage = cart page-এর locator/action
CheckoutPage = checkout page-এর locator/action
```

কেন দরকার:

```text
test step clean থাকে।
locator এক জায়গায় থাকে।
button/input change হলে শুধু page class update করলেই হয়।
```

Playwright-এর সাথে মিল:

```text
Selenium C# Page Object stores IWebDriver
Playwright TS Page Object stores Page
দুই জায়গাতেই idea একই: test যেন শুধু action বলে, details page object জানে।
```

ভালো pattern:

```text
Step Definition -> LoginPage.Login(...)
LoginPage       -> driver.FindElement(...).Click()
```
