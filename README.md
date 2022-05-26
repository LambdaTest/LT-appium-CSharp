# C# ![pw](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)

<img height="300" src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white">

*C# is a multi-paradigm programming language that includes functional, imperative, declarative, generic, object-oriented, and component-oriented programming disciplines.*

*Learn the basics of [Appium testing on the LambdaTest platform.](https://www.lambdatest.com/support/docs/getting-started-with-appium-testing/)*

## Table of Contents

* [Objective](#objective)
* [Pre-requisites](#pre-requisites)
* [Run Your First Test](#run-your-first-test)

## C# With Appium

In this topic, you will learn how to configure and run your **C#** automation testing scripts with **Appium** on **LambdaTest Real Device Cloud platform**.

## Objective

By the end of this topic, you will be able to:

1. Run a sample automation script of **C#** for application testing with **Appium** on **LambdaTest**.
2. Run test cases in **parallel** using WebDriverIO with Appium to reduce build times.
3. Learn more about Desired Capabilities for Appium testing.
4. Explore advanced features of LambdaTest.

## Pre-requisites

Before you can start performing App automation testing with Appium, you have to set up Visual Studio:

<img height="300" src="https://user-images.githubusercontent.com/95698164/170299253-3166f596-3214-4c9f-88c4-885deb5966e7.png">

- Clone/Download the Github Repository.

- Open the Android/iOS project using the file with a .sln extension.

### Setting Up Your Authentication

Make sure you have your LambdaTest credentials with you to run test automation scripts on LambdaTest. To obtain your access credentials, [purchase a plan](https://billing.lambdatest.com/billing/plans) or access the [Automation Dashboard](https://appautomation.lambdatest.com/).

**Step-2:** Set LambdaTest `Username` and `Access Key` in environment variables.

**For Linux/macOS:**

  {`export LT_USERNAME="${ YOUR_LAMBDATEST_USERNAME()}" \\
export LT_ACCESS_KEY="${ YOUR_LAMBDATEST_ACCESS_KEY()}`}"
  
**For Windows:**

  {`set LT_USERNAME="${ YOUR_LAMBDATEST_USERNAME()}" \
set LT_ACCESS_KEY="${ YOUR_LAMBDATEST_ACCESS_KEY()}`}"
 
### Upload Your Application

**Step-3:** Upload your **_iOS_** application (.ipa file) or **_android_** application (.apk file) to the LambdaTest servers using our **REST API**. You need to provide your **Username** and **AccessKey** in the format `Username:AccessKey` in the **cURL** command for authentication. Make sure to add the path of the **appFile** in the cURL request. Here is an example cURL request to upload your app using our REST API:

**Using App File:**

**For Linux/macOS:**

{`curl -u "${ YOUR_LAMBDATEST_USERNAME()}:${ YOUR_LAMBDATEST_ACCESS_KEY()}" \\
--location --request POST 'https://manual-api.lambdatest.com/app/upload/realDevice' \\
--form 'name="Android_App"' \\
--form 'appFile=@"/Users/macuser/Downloads/proverbial_android.apk"' 
`}

**For Windows:**

{`curl -u "${ YOUR_LAMBDATEST_USERNAME()}:${ YOUR_LAMBDATEST_ACCESS_KEY()}" -X POST "https://manual-api.lambdatest.com/app/upload/realDevice" -F "appFile=@"/Users/macuser/Downloads/proverbial_android.apk""`}

**Using App URL:**

**For Linux/macOS:**

{`curl -u "${ YOUR_LAMBDATEST_USERNAME()}:${ YOUR_LAMBDATEST_ACCESS_KEY()}" \\
--location --request POST 'https://manual-api.lambdatest.com/app/upload/realDevice' \\
--form 'name="Android_App"' \\
--form 'url="https://prod-mobile-artefacts.lambdatest.com/assets/docs/proverbial_android.apk"'`}

**For Windows:**

{`curl -u "${ YOUR_LAMBDATEST_USERNAME()}:${ YOUR_LAMBDATEST_ACCESS_KEY()}" -X POST "https://manual-api.lambdatest.com/app/upload/realDevice" -d "{\"url\":\"https://prod-mobile-artefacts.lambdatest.com/assets/docs/proverbial_android.apk\",\"name\":\"sample.apk\"}"`}

**Tip:**

- If you do not have any **.apk** or **.ipa** file, you can run your sample tests on LambdaTest by using our sample :link: [Android app](https://prod-mobile-artefacts.lambdatest.com/assets/docs/proverbial_android.apk) or sample :link: [iOS app](https://prod-mobile-artefacts.lambdatest.com/assets/docs/proverbial_ios.ipa).
- Response of above cURL will be a **JSON** object containing the `App URL` of the format - <lt://APP123456789123456789> and will be used in the next step.

## Run Your First Test

Once you are done with the above-mentioned steps, you can initiate your first C# test on LambdaTest.

Test Scenario: Check out [Android.cs](https://github.com/LambdaTest/LT-appium-CSharp/blob/master/android/csharp-appium-android/Program.cs) file to view the sample test script for android and [iOS.cs](https://github.com/LambdaTest/LT-appium-CSharp/blob/master/ios/csharp-appium-ios/Program.cs) for iOS.

### Configuring Your Test Capabilities

**Step-4:** You can update your custom capabilities in test scripts. In this sample project, we are passing platform name, platform version, device name and app url (generated earlier) along with other capabilities like build name and test name via capabilities object. The capabilities object in the sample code are defined as:

<Tabs className="docs__val">

<TabItem value="ios-config" label="iOS" default>

```csharp title="iOS(.ipa)"
  DesiredCapabilities capabilities = new DesiredCapabilities();
	capabilities.setCapability("build", "your build name");
	capabilities.setCapability("name", "your test name");
	capabilities.setCapability("platformName", "iOS");
	capabilities.setCapability("deviceName", "iPhone 13 Pro");
	capabilities.setCapability("isRealMobile", true);
	capabilities.setCapability("platformVersion","15.0");
	capabilities.setCapability("Visual", true);
	capabilities.setCapability("Console", true);
	capabilities.setCapability("Network", true);

```

</TabItem>
<TabItem value="android-config" label="Android" default>

```csharp title="Android(.apk)"
  DesiredCapabilities capabilities = new DesiredCapabilities();
	capabilities.setCapability("build", "your build name");
	capabilities.setCapability("name", "your test name");
	capabilities.setCapability("platformName", "Android");
	capabilities.setCapability("deviceName", "Galaxy S20");
	capabilities.setCapability("isRealMobile", true);
	capabilities.setCapability("platformVersion","11");
	capabilities.setCapability("Visual", true);
	capabilities.setCapability("Console", true);
	capabilities.setCapability("Network", true);

}
```

</TabItem>

</Tabs>

**Info Note:**

- You must add the generated **APP_URL** to the `"app"` capability in the config file.
- You can generate capabilities for your test requirements with the help of our inbuilt **[Capabilities Generator tool](https://www.lambdatest.com/capabilities-generator/beta/index.html)**. A more Detailed Capability Guide is available [here](https://www.lambdatest.com/support/docs/desired-capabilities-in-appium/).

### Executing The Tests

Click the **Play** icon to run the test.

<img height="300" src="https://user-images.githubusercontent.com/95698164/170299931-6e807cc1-d8ff-42c6-bdd2-3b48603c4d03.png">

**Info:** Your test results would be displayed on the test console (or command-line interface if you are using terminal/cmd) and on the :link: [LambdaTest App Automation Dashboard](https://appautomation.lambdatest.com/build).

## Additional Links

- [Advanced Configuration for Capabilities](https://www.lambdatest.com/support/docs/desired-capabilities-in-appium/)
- [How to test locally hosted apps](https://www.lambdatest.com/support/docs/testing-locally-hosted-pages/)
- [How to integrate LambdaTest with CI/CD](https://www.lambdatest.com/support/docs/integrations-with-ci-cd-tools/)

## LambdaTest Community :busts_in_silhouette:

The [LambdaTest Community](https://community.lambdatest.com/) allows people to interact with tech enthusiasts. Connect, ask questions, and learn from tech-savvy people. Discuss best practises in web development, testing, and DevOps with professionals from across the globe.

## Documentation & Resources :books:
      
If you want to learn more about the LambdaTest's features, setup, and usage, visit the [LambdaTest documentation](https://www.lambdatest.com/support/docs/). You can also find in-depth tutorials around test automation, mobile app testing, responsive testing, manual testing on [LambdaTest Blog](https://www.lambdatest.com/blog/) and [LambdaTest Learning Hub](https://www.lambdatest.com/learning-hub/).     
      
 ## About LambdaTest

[LambdaTest](https://www.lambdatest.com) is a leading test execution and orchestration platform that is fast, reliable, scalable, and secure. It allows users to run both manual and automated testing of web and mobile apps across 3000+ different browsers, operating systems, and real device combinations. Using LambdaTest, businesses can ensure quicker developer feedback and hence achieve faster go to market. Over 500 enterprises and 1 Million + users across 130+ countries rely on LambdaTest for their testing needs.

[<img height="70" src="https://user-images.githubusercontent.com/70570645/169649126-ed61f6de-49b5-4593-80cf-3391ca40d665.PNG">](https://accounts.lambdatest.com/register)
      
## We are here to help you :headphones:

* Got a query? we are available 24x7 to help. [Contact Us](mailto:support@lambdatest.com)
* For more info, visit - https://www.lambdatest.com

