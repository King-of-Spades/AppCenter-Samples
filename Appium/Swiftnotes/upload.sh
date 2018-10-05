# Provide AppCenter/Test upload command
AppCenter_Test_Command='paste upload command here'

# Point to APK & test build-dir 
apk_path='app/build/outputs/apk/debug/app-debug.apk'
build_dir='app/build/outputs/apk/androidTest/debug'

# Run using the command "sh upload.sh"

# Script injects set values
AppCenter_Test_Command=${AppCenter_Test_Command/'pathToFile.apk'/$apk_path}
AppCenter_Test_Command=${AppCenter_Test_Command/'pathToEspressoBuildFolder'/$build_dir}
echo $AppCenter_Test_Command 
eval $AppCenter_Test_Command