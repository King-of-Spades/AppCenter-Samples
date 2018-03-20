# Provide AppCenter/Test upload command & path to IPA.
AppCenter_Test_Command='paste command here'
app_path='../UITestDemo.ipa'

# Run using the command "sh upload.sh"
Build_TestUpload_Command='mvn -DskipTests -P prepare-for-upload package'
echo $Build_TestUpload_Command
eval $Build_TestUpload_Command

AppCenter_Test_Command=${AppCenter_Test_Command/'pathToFile.ipa'/$app_path}
echo $AppCenter_Test_Command
eval $AppCenter_Test_Command
