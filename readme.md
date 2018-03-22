# AppCenter/Test samples
These samples are preconstructed to demonstrate how each test framework included can be used along with a demo app in AppCenter/Test. Where practical they are also compatible with Xamarin Test Cloud.

Primary documentation for AppCenter/Test is available here: https://docs.microsoft.com/en-us/appcenter/test-cloud/

# Upload commands
No matter which test framework you are using, to run apps in AppCenter/Test or Xamarin Test Cloud, you **must** generate a prototype upload commandline in one of the systems using the wizard. This command line requires modifications in order to be executed, which the test framework-specific upload scripts demonstrate for basic usage. 

### AppCenter/Test command line
1. Log into https://appcenter.ms
2. If you have not already created your app, do so by selecting **Add new > Add new app**. (More info: https://docs.microsoft.com/en-us/appcenter/dashboard/creating-and-managing-apps)
3. Name your app, select the target OS of your app, and the platform your app is written in. 
4. Select the **Test** icon on the left side of the screen, it is a circle with a checkmark inside of it.
5. Click **New test run**
6. Select the devices you wish to run your tests on.
7. Configure the test framework you are using.
8. On the submit screen follow the "prerequesites" step if this is your first time creating a run in AppCenter/Test. 
9. Copy the command from **Running Tests > Upload and schedule tests**. 

##### Example (Your exact command will differ)
> appcenter test run appium --app "kegr/ReadmeDemo" --devices "kegr/top-4" --app-path pathToFile.apk  --test-series "master" --locale "en_US" --build-dir target/upload

### TestCloud command line
1. Log into https://testcloud.xamarin.com/
2. Select **New Test Run**
3. Select a new or existing app for your upload.
4. Select your devices to test on.
5. On the last screen, you can choose the testing framework & OS you are uploading your tests from to get the prototype command.

##### Example (Your exact command will differ)
> xtc test yourAppFile.apk [API_KEY] --devices [DEVICE_HASH] --series "master" --locale "en_US" --user [EMAIL] --workspace target/upload

I have removed the [API_KEY], [DEVICE_HASH] & [EMAIL] values for privacy reasons, however these will automatically be included when you generate the prototype from the wizard in Test Cloud.

# Framework Samples in this Repo
## Appium
These samples include the AppCenter/Test specific steps documented here: https://docs.microsoft.com/en-us/appcenter/test-cloud/preparing-for-upload/appium

- [Appium Android Sample](Appium/Android) This sample includes an APK file and a pre-written Appium test suite prepared for running in AppCenter/Test. 

- [Appium iOS Sample](Appium/iOS) This sample includes IPA & app files and a pre-written Appium test suite prepared for running in AppCenter/Test.

## Xamarin.UITest
This sample includes the AppCenter/Test specific steps documented here: https://docs.microsoft.com/en-us/appcenter/test-cloud/preparing-for-upload/uitest

- [Xamarin.UITest Android & iOS sample](Xamarin.UITest/UITestDemo) This Xamarin.Forms sample app is compatible with both iOS & Android; and includes a Xamarin.UITest project for the actual tests. 


## Espresso
This sample includes the AppCenter/Test specific steps documented here: https://docs.microsoft.com/en-us/appcenter/test-cloud/preparing-for-upload/espresso



<!--
### iOS (Unfinished)
We are still working on completing an iOS sample.

## XCUITest (Unfinished)
This sample includes an XCUITest in an Xcode app set up to run in AppCenter/Test based on the steps documented here: https://docs.microsoft.com/en-us/appcenter/test-cloud/preparing-for-upload/xcuitest

-->