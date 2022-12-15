using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium.iOS;
using System.Threading;

namespace csharp_appium_first

{
    class Program
    {
        static void Main(string[] args)
        {
            AppiumOptions caps = new AppiumOptions();

            caps.AddAdditionalCapability("user", "YOUR_LT_USERNAME"); //Enter the Username here
            caps.AddAdditionalCapability("accessKey", "YOUR_LT_ACCESS_KEY");  //Enter the Access key here

            // Set URL of the application under test
            caps.AddAdditionalCapability("app", "APP_URL"); //Enter the App URL here.

            // Specify device and os_version
            caps.AddAdditionalCapability("deviceName", "iPhone 12"); //Change the device name here
            caps.AddAdditionalCapability("platformVersion", "15");
            caps.AddAdditionalCapability("platformName", "iOS");
            caps.AddAdditionalCapability("isRealMobile", true);
            caps.AddAdditionalCapability("network", false);

            caps.AddAdditionalCapability("project", "First CSharp project");
            caps.AddAdditionalCapability("build", "CSharp iOS");
            caps.AddAdditionalCapability("name", "first_test");

            IOSDriver<IOSElement> driver = new IOSDriver<IOSElement>(
                new Uri("https://mobile-hub.lambdatest.com/wd/hub"), caps);

            IOSElement color = (IOSElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.Id("color"))
            );
            color.Click();
            color.Click();

            IOSElement text = (IOSElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.Id("Text"))
            );
            text.Click();

            IOSElement toast = (IOSElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.Id("toast"))
            );
            toast.Click();

            IOSElement nf = (IOSElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.Id("notification"))
            );
            nf.Click();

            IOSElement gl = (IOSElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.Id("geoLocation"))
            );
            gl.Click();

            Thread.Sleep(5000);

            driver.Navigate().Back();

            IOSElement st = (IOSElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.Id("speedTest"))
            );
            st.Click();

            Thread.Sleep(5000);

            driver.Navigate().Back();

            IOSElement browser = (IOSElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("Browser"))
            );
            browser.Click();

            IOSElement inputBox = (IOSElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.Id("url"))
            );
            inputBox.Click();


            driver.Quit();

        }
    }
}
