# Selenium Study Notes

Selenium controls the browser.

Simple idea:

```text
Open browser.
Find element.
Type or click.
Read result.
```

Bangla:

```text
Selenium browser control করে।
মানে browser open করা, input খোঁজা, type করা, click করা, result পড়া।
```

## Project Context

In this repo, Selenium code should stay mainly in:

```text
SauceDemo.Framework/Pages/*.cs
SauceDemo.Tests/Hooks/DriverHooks.cs
```

Step definitions should call page object methods instead of calling Selenium directly.

Bangla:

```text
এই project-এ Selenium locator/action Page class-এর ভিতরে রাখবেন।
Step definition-এ সরাসরি driver.FindElement লেখা avoid করবেন।
```

## WebDriver

Example:

```csharp
IWebDriver driver = new ChromeDriver();
```

Meaning:

```text
Open Chrome and control it with Selenium.
```

In this project, Chrome opens in:

```text
SauceDemo.Tests/Hooks/DriverHooks.cs
```

## Go To A Page

Example:

```csharp
driver.Navigate().GoToUrl("https://www.saucedemo.com");
```

Meaning:

```text
Tell the browser to open this website.
```

Playwright comparison:

```javascript
await page.goto("https://www.saucedemo.com");
```

## Locator

A locator tells Selenium how to find something on the page.

Example:

```csharp
By.Id("user-name")
```

Meaning:

```text
Find the element with id="user-name".
```

## Find Element

Example:

```csharp
driver.FindElement(usernameField)
```

Meaning:

```text
Find the username input on the page.
```

## Type Text

Example:

```csharp
driver.FindElement(usernameField).SendKeys(username);
```

Meaning:

```text
Find the username box and type text into it.
```

Playwright comparison:

```javascript
await page.locator("#user-name").fill(username);
```

## Click

Example:

```csharp
driver.FindElement(loginButton).Click();
```

Meaning:

```text
Find the login button and click it.
```

Playwright comparison:

```javascript
await page.locator("#login-button").click();
```

## Read Text

Example:

```csharp
driver.FindElement(errorMessage).Text;
```

Meaning:

```text
Find the error message and read its text.
```

## Waits

Sometimes the page is not ready yet.

Selenium may fail if it clicks or types too early.

This project uses:

```csharp
WebDriverWait
```

Simple idea:

```text
Wait until the element is visible and usable.
Then interact with it.
```

You can see this in:

```text
SauceDemo.Framework/Pages/CheckoutPage.cs
```

## Close Browser

Example:

```csharp
driver.Quit();
```

Meaning:

```text
Close the whole browser.
```

## Best Beginner Rule

Put Selenium code in page classes.

Good:

```text
LoginPage.cs uses driver.FindElement(...)
```

Avoid:

```text
Step definitions use driver.FindElement(...)
```

## Selenium vs Playwright Quick Map

```text
Selenium ChromeDriver()                  ~= Playwright chromium.launch()
Selenium driver.Navigate().GoToUrl(url)  ~= Playwright page.goto(url)
Selenium By.Id("user-name")              ~= Playwright page.locator("#user-name")
Selenium FindElement(...).SendKeys(text) ~= Playwright locator.fill(text)
Selenium FindElement(...).Click()        ~= Playwright locator.click()
Selenium element.Text                    ~= Playwright locator.textContent()
Selenium WebDriverWait                   ~= Playwright auto-waiting / expect()
Selenium driver.Quit()                   ~= Playwright browser.close()
```

Bangla:

```text
Playwright-এ page.locator(...) বেশি ব্যবহার করেন।
Selenium-এ driver.FindElement(...) বেশি ব্যবহার করা হয়।
Playwright অনেক wait নিজে করে, Selenium-এ explicit wait বেশি দরকার হয়।
```

## Side-By-Side Login Example

Selenium C#:

```csharp
driver.Navigate().GoToUrl("https://www.saucedemo.com");
driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
driver.FindElement(By.Id("login-button")).Click();
```

Playwright TypeScript:

```typescript
await page.goto("https://www.saucedemo.com");
await page.locator("#user-name").fill("standard_user");
await page.locator("#password").fill("secret_sauce");
await page.locator("#login-button").click();
```

Main difference:

```text
Playwright waits automatically more often.
Selenium often needs explicit waits.
```

That is why this project uses `WebDriverWait` in `CheckoutPage.cs`.

Bangla:

```text
এই কারণে CheckoutPage.cs-এ WebDriverWait আছে।
এটা element ready হওয়া পর্যন্ত অপেক্ষা করে।
```

## Bangla Quick Reference

```text
Selenium = browser automation tool
IWebDriver = browser control করার main object
ChromeDriver = Chrome browser চালানোর driver
By.Id / By.CssSelector / By.XPath = element খোঁজার locator
FindElement = page থেকে element খোঁজা
SendKeys = input field-এ text লেখা
Click = button/link click করা
Text = element-এর text পড়া
WebDriverWait = element ready হওয়া পর্যন্ত wait করা
Quit = browser বন্ধ করা
```

Playwright-এর সাথে মিল:

```text
driver.Navigate().GoToUrl(url)  ~= page.goto(url)
driver.FindElement(locator)     ~= page.locator(selector)
SendKeys(text)                  ~= fill(text)
Click()                         ~= click()
element.Text                    ~= textContent()
WebDriverWait                   ~= Playwright auto-wait / expect wait
driver.Quit()                   ~= browser.close()
```

সবচেয়ে গুরুত্বপূর্ণ:

```text
Playwright অনেক wait নিজে করে।
Selenium-এ অনেক সময় আপনাকে wait লিখতে হয়।
```
