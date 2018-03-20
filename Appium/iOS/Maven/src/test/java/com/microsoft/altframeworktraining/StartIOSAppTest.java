package com.microsoft.altframeworktraining;

import com.microsoft.appcenter.appium.Factory;
import com.microsoft.appcenter.appium.EnhancedIOSDriver;
import org.junit.rules.TestWatcher;
import org.junit.Rule;
import io.appium.java_client.ios.IOSDriver;
import io.appium.java_client.ios.IOSElement;
import io.appium.java_client.remote.MobileCapabilityType;
import org.junit.After;
import org.junit.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.remote.DesiredCapabilities;

import java.net.MalformedURLException;
import java.net.URL;

public class StartIOSAppTest {
    private EnhancedIOSDriver<IOSElement> driver;
    @Rule
    public TestWatcher watcher = Factory.createWatcher();

    public static EnhancedIOSDriver<IOSElement> startApp() throws MalformedURLException {
        DesiredCapabilities capabilities = new DesiredCapabilities();

        capabilities.setCapability(MobileCapabilityType.PLATFORM_NAME, "ios");

        // This needs to go in the readme or be deleted outright
        // npm install -g ios-deploy
        // http://appium.io/docs/en/drivers/ios-xcuitest-real-devices/
        // http://appium.io/docs/en/drivers/ios-xcuitest/index.html

        // uncomment for running locally
        // 1. Run 'xcrun instruments -s devices' in terminal
        // 2. Paste the device or simulator ID you need to replace <Device ID> below
        // capabilities.setCapability(MobileCapabilityType.DEVICE_NAME, "<Device ID>");
        // capabilities.setCapability(MobileCapabilityType.UDID, "<Device ID>");

        // 3. (Local device only) Set your Team ID for your signing identity and uncomment below
        // capabilities.setCapability("xcodeOrgId", "<Team ID>");
        // capabilities.setCapability("xcodeSigningId", "iPhone Developer");
        capabilities.setCapability("showXcodeLog", true);

//        4. Uncomment the lines for either the (local) iOS simulator or (local) iOS device below
//        (Simulator)
//        String appPath = "/Users/kentgreen/Projects/AppCenter-Test-Samples/Appium/iOS/UITestDemo.iOS.app";
//        capabilities.setCapability(MobileCapabilityType.APP, appPath);

//        (Device)
//        String ipaPath = "/Users/kentgreen/Projects/AppCenter-Test-Samples/Appium/iOS/UITestDemo.ipa";
//        capabilities.setCapability(MobileCapabilityType.APP, ipaPath);


        capabilities.setCapability("bundleId","com.companyname.UITestDemo");
        capabilities.setCapability(MobileCapabilityType.AUTOMATION_NAME, "XCUITest");

        URL url = new URL("http://localhost:4723/wd/hub");

        return Factory.createIOSDriver(url, capabilities);
    }


    @Test
    public void canStartAppInTest() throws MalformedURLException, InterruptedException {
        driver = startApp();
        driver.label("App Launched");
        IOSElement elem =  driver.findElement(By.name("Add"));
        elem.click();
        Thread.sleep(5000);
        driver.label("tapped Add button");
    }

    @After
    public void after() throws Exception {
        if (driver != null) {
            driver.quit();
        }
    }

}
