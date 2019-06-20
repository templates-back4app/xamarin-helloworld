using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Parse;

namespace HelloWorldParseServer.Droid
{
    [Activity(Label = "HelloWorldParseServer", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            ParseClient.Initialize(new ParseClient.Configuration
            {
                ApplicationId = GetString(Resource.String.back4app_app_id),
                WindowsKey = GetString(Resource.String.back4app_dotnet_key),
                Server = GetString(Resource.String.back4app_server_url)
            });

            ParsePush.ParsePushNotificationReceived += ParsePush.DefaultParsePushNotificationReceivedHandler;
            ParseInstallation.CurrentInstallation["GCMSenderId"] = "754373890304";
            ParseInstallation.CurrentInstallation.SaveAsync();

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
    }
}