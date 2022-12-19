using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.LifecycleEvents;

namespace ImageCropper.Maui.Extensions
{
    public static class StartUpExtensions
    {
        public static void UseImageCropper(this MauiAppBuilder builder)
        {
            builder.ConfigureLifecycleEvents(a =>
            {
//#if ANDROID
                a.AddAndroid(android => 
                {
                    android.OnCreate((b, c) =>
                    {
                        new Platform().Init((MauiAppCompatActivity)Microsoft.Maui.ApplicationModel.Platform.CurrentActivity);
                    });
                });
//#elif IOS
                a.AddiOS(iOS =>
                {
                    iOS.FinishedLaunching( (fl, sd) =>
                    {
                        new Platform().Init();
                    });
                });

//#endif
            });
//#if ANDROID
//var test = Microsoft.Maui.ApplicationModel.Platform.CurrentActivity;
//var test2 = MauiApplication.Current;
//            

//#elif IOS
//            
//#endif

        }
    }
}
