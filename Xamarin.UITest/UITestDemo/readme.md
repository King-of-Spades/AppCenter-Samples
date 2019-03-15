# Build Status Badges
- iOS App (simulator build) (master branch) - [![Build status](https://build.appcenter.ms/v0.1/apps/0165f989-7687-45c4-8495-fd1f3e22a728/branches/master/badge)](https://appcenter.ms)

# Overview (Xamarin.UITest - Cross-Platform)
This sample is designed for use in Visual Studio & includes the sourcecode for a Xamarin.Forms app on Android & iOS platforms & a Xamarin.UITest project. It also includes a precompiled APK & IPA incase you want to try only building, running and uploading Xamarin.UITest.

# Building & running locally
You can either build the entire solution, or you can just build the Xamarin.UITest project. 

## Windows users
Compared to running on Mac, Xamarin.UITests have additional requirements and limitations as follows:
- Xamarin.UITest cannot be run locally against iOS apps in Windows, even if using a paired Mac capable of building iOS apps.
- NUnitTestAdapter 2.1.1 is required to run tests locally in Windows. It is not required to run tests in Mac or tests submitted to Visual Studio App Center Test.
- You must set the ANDROID_HOME enviroment variable to the main folder of your Android SDK. You can create this variable as follows:
    1. Go to **Control Panel > System > Advanced System Settings > Environment Variables > System Variables* > New…** 
    2. Name the variable `ANDROID_HOME` and set it to your Android SDK path. (For example `C:\Program Files (x86)\Android\android-sdk`, your location may vary.)
    3. Close all instances of Visual Studio and reopen for the updated `ANDROID_HOME` to take effect.
- You must use the `.ApkFile()` method to [point to the APK](UITestDemo.UITest/AppInitializer.cs#L30).

## Running locally without building the Android/iOS apps
You can run the UITest project locally without building the app projects by using precompiled files:

1. Open "UITestDemo.UITest > AppInitializer.cs"
2. Point to the app files:
- To use the precompiled APK, uncomment the line for '.ApkFile' 
- To use the precompiled iOS simulator .app, unzip the app & uncomment the line for '.AppBundle'
(You cannot use the precompiled IPA for local testing because it will not be signed for one of your devices. If you build the IPA for the project first though, you can install it on the device and point to it using '.InstalledApp'.)

3. Build the Xamarin.UITest project.
4. Running the tests differs slightly if you're using Visual Studio for Mac or Visual Studio on Windows:
   - **VS for Mac** - Go to **View > Pads > Unit Tests > Run All** 
   - **VS for Windows** - Go to **Test > Windows > Test Explorer > Run All**. When testing on Windows, only Android is supported.


## Running locally with building the Android/iOS apps
1. You can build individual projects or the entire solution by right-clicking them in the solution pad and selecting "Build [Project/Solution Name]." 

2. Be aware of the following considerations for using Xamarin.UITest with these built projects:
   - 'UITestDemo.Droid' must be built using a "Release" configuration. This is because by default a "Debug" build of a Xamarin.Android project includes the "Shared Mono Runtime" which is not compatible with Xamarin.UITest.
   - 'UITestDemo.iOS' must be built using a "Debug" configuration. This is because by default iOS apps built for distrbution are rejected from the iOS app store if they contain 'Calabash' the testing framework which allows Xamarin.UITest to interact with iOS apps. 
   - Android APKs can be run on either a physical Android device or emulator interchangably. iOS must use a '.app' build to run on an iOS simulator & an '.IPA' with a valid signing identity to run on an iOS device.

3. Running the tests differs slightly if you're using Visual Studio for Mac or Visual Studio on Windows:
   - **VS for Mac** - Go to **View > Pads > Unit Tests > Run All** 
   - **VS for Windows** - Go to **Test > Windows > Test Explorer > Run All**. When testing on Windows, only Android is supported; and you must also set the [`.ApkFile()` path in the AppInitializer.cs ConfigureApp statement](/Xamarin.UITest/UITestDemo/UITestDemo.UITest/AppInitializer.cs#L31)

# Uploading tests
1. Build the Xamarin.UITest project.
2. Generate a command line for upload: [Directions](/../../#upload-commands)
3. Update the upload command with project-specific arguments:
   - **OS X** paste your command as the value for 'AppCenter_Test_Command' in 'android.sh' or 'ios.sh' depending on the platform. You can run these files using 'sh android.sh' or 'sh ios.sh'.
   - **Windows** The '.sh' files are not technically compatible with Windows, however it shows how to modify the generated command to upload this sample manually.

#### See Also   
- Android upload script: [android.sh](android.sh)
- iOS upload script: [ios.sh](ios.sh)
