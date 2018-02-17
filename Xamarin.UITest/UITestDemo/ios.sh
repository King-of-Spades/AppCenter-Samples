# Setup & usage
# Step 0 Build the UITest project & generate an IPA using the "Debug" configuration
# Step 1 Generate an AppCenter upload command and paste it to the variable
AppCenter_Test_Command='paste upload command here'

# Step 2 Provide the (absolute or relative) path to the IPA
app_path='UITestDemo.ipa'

# Step 3 Provide the (absolute or relative) path to the UITest project bin folder
build_dir='UITestDemo.UITest/bin/Debug'

# Step 4 run using the command "sh ios.sh"


# Scripted logic
# Script injects app_path & build_dir and executes resulting command
AppCenter_Test_Command=${AppCenter_Test_Command/'pathToFile.ipa'/$app_path}
AppCenter_Test_Command=${AppCenter_Test_Command/'pathToUITestBuildDir'/$build_dir}

# Execute injected command
eval $AppCenter_Test_Command