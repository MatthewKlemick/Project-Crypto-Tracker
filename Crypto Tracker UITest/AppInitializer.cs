using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Crypto_Tracker_UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android.InstalledApp("com.companyname.project_crypto_tracker").EnableLocalScreenshots().StartApp();
            }
            else
            {
                return ConfigureApp.iOS.StartApp();
            }

            
        }
    }
}