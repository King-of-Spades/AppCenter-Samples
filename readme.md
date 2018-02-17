# AppCenter/Test samples
These samples are preconstructed to demonstrate how each test framework included can be used along with a demo app in AppCenter/Test.

Primary documentation for AppCenter/Test is available here: https://docs.microsoft.com/en-us/appcenter/test-cloud/

The sections below point to specific samples within this repo. The readme also shows prototype command lines for each framework. These command lines must be modified based on specifics of your system & AppCenter/Test account.

# Appium
## Android
This sample includes an APK file and a pre-written Appium test suite prepared for running in AppCenter/Test. It includes the AppCenter/Test specific steps documented here: https://docs.microsoft.com/en-us/appcenter/test-cloud/preparing-for-upload/appium

## iOS
We are still working on completing an iOS sample.

# Espresso (Android Only)
This sample includes an Android Studio solution with the root folder set to **AppCenter-Test-Samples/Espresso/Swiftnotes-solution**. It includes the AppCenter/Test specific steps documented here: https://docs.microsoft.com/en-us/appcenter/test-cloud/preparing-for-upload/espresso

## Example command line
> appcenter test run espresso --app [USER/APPNAME] --devices [DEVICE_SET] --app-path pathToFile.apk  --test-series [SERIES] --locale [LOCALE] --build-dir pathToEspressoBuildFolder 

# Xamarin.UITest 
This sample includes a Xamarin.Forms app project which is compatible with both iOS & Android; as well as a Xamarin.UITest project for the actual tests. It includes the AppCenter/Test specific steps documented here: https://docs.microsoft.com/en-us/appcenter/test-cloud/preparing-for-upload/uitest

# XCUITest
This sample includes an XCUITest in an Xcode app set up to run in AppCenter/Test based on the steps documented here: https://docs.microsoft.com/en-us/appcenter/test-cloud/preparing-for-upload/xcuitest