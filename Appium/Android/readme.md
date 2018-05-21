# Overview (Appium-Android)
This sample includes an APK file and a pre-written Appium test suite prepared for running in AppCenter/Test or testcloud.xamarin.com. Please see this document for information on preparing an existing Appium test suite for running in AppCenter: https://docs.microsoft.com/en-us/appcenter/test-cloud/preparing-for-upload/appium

# Installation
If you haven't previously set up Appium, you can do so by following these steps:

1. Install `Node.js/NPM`: https://www.npmjs.com/get-npm
2. Install Appium:
   - **Windows** This guide shows how to install Appium on Windows: https://www.edgewordstraining.co.uk/2017/07/05/install-appium-server-windows/

   - **OSX** Use this command in the Terminal (This may require additional permission arguments to work: https://github.com/npm/npm/issues/17268): 
   > `sudo npm install -g appium`

3. Install Maven:
https://maven.apache.org/install.html

4. Set the ANDROID_HOME path enviroment variable. https://stackoverflow.com/questions/28296237/set-android-home-environment-variable-in-mac

By default typically the Android SDK is located at `~/Library/Android/sdk` (Mac) or `%LOCALAPPDATA%\Android\sdk` (Windows)
 

# Building & running locally
(Note: The author of this sample used IntelliJ IDEA 2017.3.4 (Ultimate Edition) on Mac OS X 10.13.3, though other tools for building may work.)

1. Provide the absolute path to swiftnote.apk here: [Maven/src/test/java/com/microsoft/altframeworktraining/StartAppTest.java#L32](Maven/src/test/java/com/microsoft/altframeworktraining/StartAppTest.java#L32) 
2. Build the Maven project using your perferred method. Your IDE may prompt you to auto-apply some settings, in which case confirm them. 
3. Make sure to start the local Appium server before running tests, otherwise the tests will fail. 

# Uploading app & tests
1. Build the Maven project.
2. Generate a command line for upload. [Directions](/../../#upload-commands)
3. Run the upload command with project-specific arguments:
   - **OS X** paste your command as the value for 'AppCenter_Test_Command' in 'upload.sh'. In terminal navigate to the Maven folder and run 'sh upload.sh' to generate the 'test/upload' folder and then upload to AppCenter/Test
   - **Windows** The 'upload.sh' file is not technically compatible with Windows, however it shows how to modify the generated command to upload this sample manually.
   
See Also: [upload.sh](Maven/upload.sh)


# About Swiftnotes Sample App
Within this repo, the sourcecode for this app can be found in the [Espresso/Swiftnotes](../../espresso/swiftnotes) folder. That folder also contains the LICENSE file for the sample.

## License
Copyright &copy; 2017 Adrian Chifor

Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
