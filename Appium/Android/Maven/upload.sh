# Setup & usage
# Step 0
# Step 1 Generate an AppCenter upload command and paste it to the variable
Build_TestUpload_Command='mvn -DskipTests -P prepare-for-upload package'
AppCenter_Test_Command='appcenter test run appium --app "kegr/Swiftnotes" --devices "kegr/top-4" --app-path pathToFile.apk  --test-series "master" --locale "en_US" --build-dir target/upload'


# Step 2 Provide the (absolute or relative) path to the Maven folder


# Step 3 Provide the (absolute or relative) path to the APK
app_path='../swiftnote.apk'

# Step 4 run using the command "sh upload.sh"

# Scripted logic
# Script injects maven_path and builds test/upload
eval $Build_TestUpload_Command

# Script injects app_path and executes resulting command
AppCenter_Test_Command=${AppCenter_Test_Command/'pathToFile.apk'/$app_path}
eval $AppCenter_Test_Command
