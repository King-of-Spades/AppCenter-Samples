# xtc test yourAppFile.apk 91e67e70dcdbc92ff86d0595b4e2e051 --devices dcbc14e0 --series "master" --user kent.green@xamarin.com --workspace app/build/outputs/apk
# 'paste command here'


# Provide Test Cloud upload command, path to APK & path to xtc file for the OS.
TestCloud_Command='xtc test yourAppFile.apk 91e67e70dcdbc92ff86d0595b4e2e051 --devices dcbc14e0 --series "master" --user kent.green@xamarin.com --workspace app/build/outputs/apk'
app_path='app/build/outputs/apk/debug/app-debug.apk'
workspace='app/build/outputs/apk/androidTest'

# Run using the command "sh tcupload.sh"

# Script injects app_path & platform and executes resulting command
TestCloud_Command=${TestCloud_Command/'yourAppFile.apk'/$app_path}
TestCloud_Command=${TestCloud_Command/'xtc'/$platform}
eval $TestCloud_Command
