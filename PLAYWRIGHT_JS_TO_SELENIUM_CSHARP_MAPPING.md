# Playwright JS To Selenium C# Mapping

If you know Playwright with JavaScript, these ideas are similar:

```text
Playwright page.goto(...)       -> Selenium driver.Navigate().GoToUrl(...)
Playwright locator(...).fill()  -> Selenium FindElement(...).SendKeys(...)
Playwright locator(...).click() -> Selenium FindElement(...).Click()
expect(...)                     -> Assert.That(...)
```

The syntax is different, but the testing idea is similar.
