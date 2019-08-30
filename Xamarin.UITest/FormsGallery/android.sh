# Setup & usage
# Step 0 Build the UITest project & generate an APK using the "Release" configuration (or use the provided APK)
# Step 1 Generate an AppCenter upload command and paste it to the variable
AppCenter_Test_Command='appcenter test run uitest --app "XTCTeam/Forms-Gallery-Android" --devices "XTCTeam/8-dot-1-9-dot-0-galaxy-note-9-pixel" --app-path pathToFile.apk  --test-series "master" --locale "en_US" --build-dir pathToUITestBuildDir'

# Step 2 Provide the (absolute or relative) path to the apk
app_path='precompiledApps/com.appcenter.FormsGallery.apk'

# Step 3 Provide the (absolute or relative) path to the UITest project bin folder
build_dir='FormsGallery.UITest/bin/Debug'

# Step 4 add --include argument
include=' --include "includedDataFile.txt"'

# Step 5 run using the command "sh android.sh"

# Script injects app_path & build_dir and executes resulting command
AppCenter_Test_Command=${AppCenter_Test_Command/'pathToFile.apk'/$app_path}
AppCenter_Test_Command=${AppCenter_Test_Command/'pathToUITestBuildDir'/$build_dir}
AppCenter_Test_Command+=$include
echo $AppCenter_Test_Command
eval $AppCenter_Test_Command
