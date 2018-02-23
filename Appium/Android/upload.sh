# Setup & usage
# Step 0
# Step 1 Generate an AppCenter upload command and paste it to the variable
AppCenter_Test_Command='appcenter test run appium --app "kegr/Swiftnotes" --devices "kegr/top-4" --app-path pathToFile.apk  --test-series "master" --locale "en_US" --build-dir target/upload'

# Step 2 Provide the (absolute or relative) path to the APK
app_path='swiftnote.apk'

# Step 3 run using the command "sh android.sh"

# Scripted logic
# Script injects app_path & build_dir and executes resulting command
AppCenter_Test_Command=${AppCenter_Test_Command/'pathToFile.apk'/$app_path}

# Execute injected command
eval $AppCenter_Test_Command
