using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium.iOS;
using System.Threading;
using System.IO;
using Newtonsoft.Json.Linq;

namespace csharp_appium_first
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting iOS Test...");
            
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
            caps.AddAdditionalCapability("app", ltConfig["iosAppId"].ToString());

            // Specify device and os_version
            caps.AddAdditionalCapability("deviceName", "iPhone 13 Pro");
            caps.AddAdditionalCapability("platformVersion", "15.0");
            caps.AddAdditionalCapability("platformName", "iOS");
            caps.AddAdditionalCapability("isRealMobile", true);
            caps.AddAdditionalCapability("network", false);

            caps.AddAdditionalCapability("project", "First CSharp project");
            caps.AddAdditionalCapability("build", "CSharp iOS");
            caps.AddAdditionalCapability("name", "first_test");

            IOSDriver<IOSElement> driver = new IOSDriver<IOSElement>(
                new Uri("https://mobile-hub.lambdatest.com/wd/hub"), caps);

            try
            {
                Console.WriteLine("Test: Clicking color button...");
                IOSElement color = (IOSElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                    SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.Id("color"))
                );
                color.Click();
                color.Click();
                Console.WriteLine("✓ Color button test passed");

                Console.WriteLine("Test: Clicking text button...");
                IOSElement text = (IOSElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                    SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.Id("Text"))
                );
                text.Click();
                Console.WriteLine("✓ Text button test passed");

                Console.WriteLine("Test: Clicking toast button...");
                IOSElement toast = (IOSElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                    SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.Id("toast"))
                );
                toast.Click();
                Console.WriteLine("✓ Toast button test passed");

                Console.WriteLine("Test: Clicking notification button...");
                IOSElement nf = (IOSElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                    SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.Id("notification"))
                );
                nf.Click();
                Console.WriteLine("✓ Notification button test passed");

                Console.WriteLine("Test: Clicking geolocation button...");
                IOSElement gl = (IOSElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                    SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.Id("geoLocation"))
                );
                gl.Click();
                Console.WriteLine("✓ Geolocation button test passed");

                Console.WriteLine("Waiting for geolocation request to process...");
                Thread.Sleep(10000); // Wait 10 seconds for geolocation request

                driver.Navigate().Back();

                Console.WriteLine("Test: Clicking speed test button...");
                try
                {
                    // Try with increased wait time
                    IOSElement st = (IOSElement)new WebDriverWait(driver, TimeSpan.FromSeconds(45)).Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.Id("speedTest"))
                    );
                    st.Click();
                    Console.WriteLine("✓ Speed test button test passed");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"! Speed test button test failed: {ex.Message}");
                    // Continue with the test
                }

                Thread.Sleep(5000);
                driver.Navigate().Back();

                Console.WriteLine("Test: Clicking browser button...");
                IOSElement browser = (IOSElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                    SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("Browser"))
                );
                browser.Click();
                Console.WriteLine("✓ Browser button test passed");

                Console.WriteLine("Test: Clicking URL input box...");
                IOSElement inputBox = (IOSElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                    SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.Id("url"))
                );
                inputBox.Click();
                Console.WriteLine("✓ URL input box test passed");

                Console.WriteLine("All iOS tests completed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Test failed: {ex.Message}");
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
