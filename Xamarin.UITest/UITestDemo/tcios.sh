# Setup & usage
# Step 0 Build the UITest project & generate an IPA using the "Debug" configuration (or use the provided IPA)
# Step 1 Generate an AppCenter upload command and paste it to the variable
TestCloud_Command='paste upload command here'

# Step 2 Provide the (absolute or relative) path to the IPA
app_path='precompiledApps/UITestDemo.ipa'

# Step 3 Provide the (absolute or relative) path to the UITest project bin folder
build_dir='UITestDemo.UITest/bin/Debug'

# Step 4 Provide the Xamarin.UITest version the project is built with
uitest='2.2.3'

# Step 5 run using the command "sh tcios.sh"

# Script injects app_path & build_dir and executes resulting command
TestCloud_Command=${TestCloud_Command/'yourAppFile.ipa'/$app_path}
TestCloud_Command=${TestCloud_Command/'pathToTestDllFolder'/$build_dir}
TestCloud_Command=${TestCloud_Command/'[version]'/$uitest}
eval $TestCloud_Command