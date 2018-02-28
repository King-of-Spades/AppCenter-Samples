# Provide Test Cloud upload command
TestCloud_Command='paste your command here'
# Delete 'app/build/outputs/apk' because the script is unable to update it when reading the slashes. The "workspace" variable below will add the path back in.

# provide a path to the APK, the workspace, and the unzipped xtcMac or xtcWin folder.
apk_path='app/build/outputs/apk/debug/app-debug.apk'
workspace='--workspace app/build/outputs/apk/androidTest/debug'
platform='xtcMac/xtc'

# Run using the command "sh tcupload.sh"

# Script injects app_path & platform and executes resulting command
TestCloud_Command=${TestCloud_Command/'--workspace'/$workspace}
TestCloud_Command=${TestCloud_Command/'yourAppFile.apk'/$apk_path}
TestCloud_Command=${TestCloud_Command/'xtc'/$platform}
echo $TestCloud_Command # For debugging only, prints the final command that will be submitted by eval
eval $TestCloud_Command