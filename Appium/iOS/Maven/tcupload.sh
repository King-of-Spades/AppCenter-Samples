# Provide Test Cloud upload command, path to APK & path to xtc file for the OS.
TestCloud_Command='paste command here'
app_path='../swiftnote.apk'
platform='xtcMac/xtc'

# Run using the command "sh tcupload.sh"
Build_Upload_Command='mvn -DskipTests -P prepare-for-upload package'
eval $Build_Upload_Command

# Script injects app_path & platform and executes resulting command
TestCloud_Command=${TestCloud_Command/'yourAppFile.apk'/$app_path}
TestCloud_Command=${TestCloud_Command/'xtc'/$platform}
eval $TestCloud_Command
