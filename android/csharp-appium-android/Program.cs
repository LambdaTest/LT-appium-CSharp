using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium.Android;
using System.Threading;
using System.IO;
using Newtonsoft.Json.Linq;

namespace csharp_appium

{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Android Test...");
            
            // Load configuration
            var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "config.json");
            if (!File.Exists(configPath))
            {
                throw new FileNotFoundException("config.json not found. Please create it from config.template.json");
            }
            
            var config = JObject.Parse(File.ReadAllText(configPath));
            var ltConfig = config["lambdatest"];

            AppiumOptions caps = new AppiumOptions();

            caps.AddAdditionalCapability("user", ltConfig["username"].ToString());
            caps.AddAdditionalCapability("accessKey", ltConfig["accessKey"].ToString());
            caps.AddAdditionalCapability("app", ltConfig["androidAppId"].ToString());

            // Specify device and os_version
            caps.AddAdditionalCapability("deviceName", "Galaxy S20");
            caps.AddAdditionalCapability("platformVersion", "11");
            caps.AddAdditionalCapability("platformName", "Android");
            caps.AddAdditionalCapability("isRealMobile", true);
            caps.AddAdditionalCapability("network", false);

            caps.AddAdditionalCapability("project", "CSharp Sample Android");
            caps.AddAdditionalCapability("build", "CSharp Sample Android");
            caps.AddAdditionalCapability("name", "CSharp Sample Android");

            // Initialize the remote Webdriver using LambdaTest remote URL
            // and desired capabilities defined above
            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                new Uri("https://mobile-hub.lambdatest.com/wd/hub"), caps);

            // Test case for the sample Android app. 
            // If you have uploaded your app, update the test case here.
            Console.WriteLine("Test: Clicking color button...");
            AndroidElement color = (AndroidElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.Id("color"))
            );
            color.Click();
            color.Click();
            Console.WriteLine("✓ Color button test passed");

            Console.WriteLine("Test: Clicking text button...");
            AndroidElement text = (AndroidElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.Id("Text"))
            );
            text.Click();
            Console.WriteLine("✓ Text button test passed");

            Console.WriteLine("Test: Clicking toast button...");
            AndroidElement toast = (AndroidElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.Id("toast"))
            );
            toast.Click();
            Console.WriteLine("✓ Toast button test passed");

            Console.WriteLine("Test: Clicking notification button...");
            AndroidElement nf = (AndroidElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.Id("notification"))
            );
            nf.Click();
            Console.WriteLine("✓ Notification button test passed");

            Console.WriteLine("Test: Clicking geolocation button...");
            AndroidElement gl = (AndroidElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.Id("geoLocation"))
            );
            gl.Click();
            Console.WriteLine("✓ Geolocation button test passed");

            Console.WriteLine("Waiting for geolocation request to process...");
            Thread.Sleep(10000); // Wait 10 seconds for geolocation request

            driver.Navigate().Back();

            Console.WriteLine("Test: Clicking speed test button...");
            AndroidElement st = (AndroidElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.Id("speedTest"))
            );
            st.Click();
            Console.WriteLine("✓ Speed test button test passed");

            Thread.Sleep(5000);

            driver.Navigate().Back();

            Console.WriteLine("Test: Clicking browser button...");
            AndroidElement browser = (AndroidElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("Browser"))
            );
            browser.Click();
            Console.WriteLine("✓ Browser button test passed");

            Console.WriteLine("Test: Clicking URL input box...");
            AndroidElement inputBox = (AndroidElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.Id("url"))
            );
            inputBox.Click();
            Console.WriteLine("✓ URL input box test passed");

            Console.WriteLine("All Android tests completed successfully!");
            driver.Quit();
        }
    }
}
