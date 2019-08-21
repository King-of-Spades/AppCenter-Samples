# Environment Variables created by App Center
APPCENTER_SOURCE_DIRECTORY="/Users/kentgreen/Documents/GitHub/AppCenter-Test-Samples"
APPCENTER_OUTPUT_DIRECTORY="/Users/kentgreen/Documents/GitHub/AppCenter-Test-Samples/Xamarin.UITest/FormsGallery/precompiled-apps"
APPCENTER_BRANCH='gh-category-experiments'

TEAM_APP='XTCTeam/Forms-Gallery-Android'
DEVICE_SET='XTCTeam/8-dot-1-9-dot-0-galaxy-note-9-pixel'
UITEST_PATH='Xamarin.UITest/FormsGallery/FormsGallery.UITest'

# DEBUGGING
# echo "contents of UITest directory:" 
# ls $APPCENTER_SOURCE_DIRECTORY/$UITEST_PATH

# Upload tests
App_Center_Test_Command='appcenter test run uitest --app $TEAM_APP --devices $DEVICE_SET --app-path $APPCENTER_OUTPUT_DIRECTORY/com.appcenter.FormsGallery.apk  --test-series "gh-$APPCENTER_BRANCH" --locale "en_US" --build-dir $APPCENTER_SOURCE_DIRECTORY/$UITEST_PATH/bin/Debug --async --include-category "ContentPage" --uitest-tools-dir $APPCENTER_SOURCE_DIRECTORY/Xamarin.UITest/FormsGallery/packages/Xamarin.UITest.*/tools'

echo $App_Center_Test_Command
eval $App_Center_Test_Command