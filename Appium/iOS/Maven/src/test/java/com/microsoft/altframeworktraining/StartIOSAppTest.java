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

/**
 * Created by krukow on 05/02/2018.
 */
public class StartIOSAppTest {
    private EnhancedIOSDriver<IOSElement> driver;
    @Rule
    public TestWatcher watcher = Factory.createWatcher();

    public static EnhancedIOSDriver<IOSElement> startApp() throws MalformedURLException {
        DesiredCapabilities capabilities = new DesiredCapabilities();

        capabilities.setCapability(MobileCapabilityType.PLATFORM_NAME, "ios");

        // carthage
        /*
                sudo mkdir /usr/local/Frameworks
                sudo chown -R $(whoami) /usr/local/Frameworks
                brew install carthage

         */
        // npm install -g ios-deploy
        // expected: libimobile

        //change this Note: I'm using an .ipa + physical device, see:
        // http://appium.io/docs/en/drivers/ios-xcuitest-real-devices/
        // http://appium.io/docs/en/drivers/ios-xcuitest/index.html
        capabilities.setCapability(MobileCapabilityType.DEVICE_NAME, "9a273f502194583335a0fa4fae089c4e9bb0bd98");
        capabilities.setCapability(MobileCapabilityType.UDID, "9a273f502194583335a0fa4fae089c4e9bb0bd98");

        //change this Note: to resign and install the web driver agent
        //capabilities.setCapability("xcodeOrgId", "<Team ID>");
        //capabilities.setCapability("xcodeSigningId", "iPhone Developer");
        capabilities.setCapability("xcodeOrgId", "H2H58GY7CF");
        capabilities.setCapability("xcodeSigningId", "iPhone Developer");
        capabilities.setCapability("showXcodeLog", true);

        //change this
        // also make sure you run rake binaries:fetch_sample_apps from that project
        // I recommend resigning the app and installing it on the device up front
        String appPath = "/Users/krukow/code/test-cloud-test-apps/XTCiOSSampleProject/test-app/XTCiOSSample.ipa";

        //capabilities.setCapability(MobileCapabilityType.APP, appPath);
        capabilities.setCapability("bundleId","com.xamarin.XTCiOSSampleProject");
        capabilities.setCapability(MobileCapabilityType.AUTOMATION_NAME, "XCUITest");

        URL url = new URL("http://localhost:4723/wd/hub");

        return Factory.createIOSDriver(url, capabilities);
    }


    @Test
    public void canStartAppInTest() throws MalformedURLException, InterruptedException {
        driver = startApp();
        IOSElement elem =  driver.findElement(By.name("Date Picker"));
        driver.label("App Launched");
        elem.click();
        Thread.sleep(5000);
        driver.label("tapped Date Picker");
    }

    @After
    public void after() throws Exception {
        if (driver != null) {
            driver.quit();
        }
    }

}
