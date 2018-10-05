# Building & running tests locally
## Building
Steps on how to build Swiftnotes:
1. Make sure you have the latest version of Android Studio with Gradle v4.1 and the required Android SDK Tools installed (26.1.1 Build tools)
2. Open the project using *Android Studio > File > Import Project*
3. Select *build.gradle* in Swiftnotes. (Picking another directory may still seem to open the project, but cause trouble building.)
4. Go to *File > Project Structure > SDK Location* and make sure Android SDK and JDK paths are set.
5. Select *Build > Rebuild Project*

## Running tests
To run tests locally:
1. Make sure you can build the app (see above)
2. Navigate in Android Studio to *app > java > com.moonpi.swifnotes (androidTest) > CreateNoteTest*
3. Right-click *CreateNoteTest* and select *Run 'CreateNoteTest'*
4. Select a device or emulator from the dialog to install the app and run the tests. 

# Uploading app & tests
1. Build the app & tests locally. (Running locally is optional but a good idea)
2. Generate a command line for upload. [Directions](/../../#upload-commands)
3. Run the upload command with project-specific arguments:
   - **OS X** paste your command as the value for 'AppCenter_Test_Command' in 'upload.sh'. In terminal navigate to the Maven folder and run 'sh upload.sh' to upload to AppCenter/Test
   - **Windows** The 'upload.sh' file is not technically compatible with Windows, however it shows how to modify the generated command to upload this sample manually.
See Also: [upload.sh](upload.sh)

# License for Swiftnotes sample app

Copyright &copy; 2017 Adrian Chifor

Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
