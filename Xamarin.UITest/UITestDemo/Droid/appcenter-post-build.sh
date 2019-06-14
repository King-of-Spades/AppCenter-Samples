# Comments
App_Center_Test_Command='appcenter test run uitest --app "XTCTeam/UITestDemo-1" --devices "XTCTeam/galaxy-s9-and-google-pixels-android-7-dot-1-2-9-dot-0" --app-path $APPCENTER_OUTPUT_DIRECTORY/com.companyname.UITestDemo.apk  --test-series "master" --locale "en_US" --build-dir $APPCENTER_SOURCE_DIRECTORY/Xamarin.UITest/UITestDemo/UITestDemo.UITest/bin/Debug --async --token API_KEY'

echo "Hello World! I'm a post-build script!"
echo "I run at the end of your build." 
echo "Documentation: https://docs.microsoft.com/en-us/appcenter/build/custom/scripts/#post-clone"

echo "Attempting to upload & run test suite using source directory: " $APPCENTER_SOURCE_DIRECTORY
echo "& output directory: " $APPCENTER_OUTPUT_DIRECTORY

echo $App_Center_Test_Command
App_Center_Test_Command=${App_Center_Test_Command/'API_KEY'/$API_KEY}
eval $App_Center_Test_Command
echo "end post-build script"