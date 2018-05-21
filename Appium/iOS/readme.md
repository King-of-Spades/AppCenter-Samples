# Overview (Appium-iOS)
This sample includes an .app iOS simulator file & an .IPA iOS device file. It also has a pre-written Appium test suite prepared for running in AppCenter/Test or testcloud.xamarin.com. 

Please see this document for information on preparing an existing Appium test suite for running in AppCenter: https://docs.microsoft.com/en-us/appcenter/test-cloud/preparing-for-upload/appium

# Installation
If you haven't previously set up Appium, you can do so by following these steps:

1. Install `Node.js/NPM`: https://www.npmjs.com/get-npm
2. Install Appium by using this command in the Terminal (it may require additional permission arguments to work: https://github.com/npm/npm/issues/17268): 
> sudo npm install -g appium

3. Install Maven: https://maven.apache.org/install.html

4. Install carthage:
> brew install carthage

5. Install ios-deploy 
> npm install -g ios-deploy

(Note: The author of this sample used IntelliJ IDEA 2017.3.4 (Ultimate Edition) on Mac OS X 10.13.3, though other tools for building/running may work.)
 
# Building & running locally
1. You have to make some setup specific modifications to the tests to make them runnable locally. Those are documented here:
   - Initial / Simulator setup: http://appium.io/docs/en/drivers/ios-xcuitest/index.html
   - Additional steps for real devices: http://appium.io/docs/en/drivers/ios-xcuitest-real-devices/
   - The sample also has commented lines on how you can modify it to run locally:
[Maven/src/test/java/com/microsoft/altframeworktraining/StartIOSAppTest.java#L28-L46](Maven/src/test/java/com/microsoft/altframeworktraining/StartIOSAppTest.java#L28-L46) 
2. Build the Maven project using your perferred method. Your IDE may prompt you to auto-apply some settings, in which case confirm them. 
3. Make sure to start the local Appium server before running tests, otherwise the tests will fail.  

# Uploading app & tests
*Note: Only .IPA files are compatible in App Center Test, because physical iOS devices are used, not simulators*

1. Build the Maven project.
2. Generate a command line for upload. [Directions](/../../#upload-commands)
3. Run the upload command with project-specific arguments:
   - **OS X** paste your command as the value for 'AppCenter_Test_Command' in 'upload.sh'. In terminal navigate to the Maven folder and run 'sh upload.sh' to generate the 'test/upload' folder and then upload to AppCenter/Test
   - **Windows** The 'upload.sh' file is not technically compatible with Windows, however it shows how to modify the generated command to upload this sample manually.
   
See Also: [upload.sh](Maven/upload.sh)

# About Sample App
The sample app is the Xamarin.Forms iOS app sourcecode found in the Xamarin.UITest sample here: https://github.com/King-of-Spades/AppCenter-Test-Samples/tree/master/Xamarin.UITest/UITestDemo

The sample was created using a Xamarin.Forms template project with Xamarin.UITest support added. Including or removing Xamarin.UITest has no effect on running Appium iOS tests against this sample according to our QA tests; so if you wish to build the same sample from the iOS source it should work normally. 