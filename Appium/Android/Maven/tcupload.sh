# Setup & usage
# Step 0
# Step 1 Generate an AppCenter upload command and paste it to the variable
Build_Upload_Command='mvn -DskipTests -P prepare-for-upload package'
TestCloud_Command='paste command here'

# Step 3 Provide the (absolute or relative) path to the APK
app_path='../swiftnote.apk'

# Step 4 Select the path to the xtcMac/xtc or xtcWin/xtc file based on the system you're uploading from
platform='xtcMac/xtc'

# Step 4 run using the command "sh testcloud.sh"

# Scripted logic
# Script injects maven_path and builds test/upload
eval $Build_Upload_Command

# Script injects app_path & platform and executes resulting command
TestCloud_Command=${TestCloud_Command/'yourAppFile.apk'/$app_path}
TestCloud_Command=${TestCloud_Command/'xtc'/$platform}
eval $TestCloud_Command
