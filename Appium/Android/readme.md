# Overview (Appium-Android)
This sample includes an APK file and a pre-written Appium test suite prepared for running in AppCenter/Test or testcloud.xamarin.com. Please see this document for information on preparing an existing Appium test suite for running in AppCenter: https://docs.microsoft.com/en-us/appcenter/test-cloud/preparing-for-upload/appium

# Build & running locally
1. Build the Maven project using your perferred method. Your IDE may prompt you to auto-apply some settings, in which case confirm them. 
2. If you wish to run the tests locally on a device or emulator, make sure to start the local Appium server before running tests, otherwise the tests will fail. 

(Note: The author of this sample used IntelliJ IDEA 2017.3.4 (Ultimate Edition) on Mac OS X 10.13.3, though other tools for building may work.)

# Uploading to AppCenter/Test
1. Build the Maven project.
2. Generate a command line for upload. [Directions](../../AppCenter-Test-Samples#appcentertest-command-line)
3. Run the upload command with project-specific arguments:
   - **OS X** paste your command as the value for 'AppCenter_Test_Command' in 'upload.sh'. In terminal navigate to the Maven folder and run 'sh upload.sh' to generate the 'test/upload' folder and then upload to AppCenter/Test
   - **Windows** The 'tcupload.sh' file is not technically compatible with Windows, however it shows how to modify the generated command to upload this sample manually.
   
See Also: [upload.sh](Maven/upload.sh)

# Uploading to Xamarin Test Cloud
1. Build the Maven project
2. Generate a command line for upload. [Directions](../../AppCenter-Test-Samples#testcloud-command-line)
3. Unzip 'Maven/xtcMac.zip' or 'Maven/xtcWindows.zip' depending on the platform you're using.
4. Run the upload command with project-specific arguments:
   - **OS X** paste your command as the value for 'TestCloud_Command' in 'tcupload.sh'. In terminal navigate to the Maven folder and run 'sh tcupload.sh' to generate the 'test/upload' folder and then upload to AppCenter/Test.
   - **Windows** The 'tcupload.sh' file is not technically compatible with Windows, however it shows how to modify the generated command to upload this sample manually.
   
See Also: [tcupload.sh](Maven/tcupload.sh)