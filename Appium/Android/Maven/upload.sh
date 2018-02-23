Build_TestUpload_Command='mvn -DskipTests -P prepare-for-upload package'

# Generate an AppCenter/Test upload command and paste it to the variable
AppCenter_Test_Command='paste command here'

# Provide the (absolute or relative) path to the APK
app_path='../swiftnote.apk'

# Run using the command "sh upload.sh"
eval $Build_TestUpload_Command

AppCenter_Test_Command=${AppCenter_Test_Command/'pathToFile.apk'/$app_path}
eval $AppCenter_Test_Command
