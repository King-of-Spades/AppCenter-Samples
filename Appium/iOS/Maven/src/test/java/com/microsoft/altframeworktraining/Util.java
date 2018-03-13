package com.microsoft.altframeworktraining;

import io.appium.java_client.android.AndroidDriver;
import io.appium.java_client.android.AndroidElement;
import org.openqa.selenium.By;

public class Util {
    public static AndroidElement findByByOrName(AndroidDriver<AndroidElement> driver, By by, String name) {
        try {
            return  driver.findElement(by);

        } catch (org.openqa.selenium.NoSuchElementException e) {
            return findByName(driver, name);
        }
    }

    public static AndroidElement findByName(AndroidDriver<AndroidElement> driver, String name) {
        return driver.findElementByAndroidUIAutomator(
                "new UiScrollable(new UiSelector().scrollable(true).instance(0)).scrollIntoView(new UiSelector().text(\""
                        + name + "\").instance(0))");
    }

}
