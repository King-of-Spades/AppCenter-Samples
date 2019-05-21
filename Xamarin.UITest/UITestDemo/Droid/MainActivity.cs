using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Com.Microsoft.Appcenter.Utils;

namespace UITestDemo.Droid
{
    [Activity(Label = "UITestDemo.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App(RunningInAppCenter()));
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
        }

        private bool RunningInAppCenter()
        {
            try
            {
                var arguments = InstrumentationRegistryHelper.Arguments;
                var runningInAppCenter = arguments.GetString("RUNNING_IN_APP_CENTER");
                if (runningInAppCenter == null || runningInAppCenter != "1")
                {
                    return false;
                }

                return true;
            }
            catch (Java.Lang.LinkageError)
            {
                return false;
            }
            catch (Java.Lang.IllegalStateException)
            {
                return false;
            }
        }
    }
}
