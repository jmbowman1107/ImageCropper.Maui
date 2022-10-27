using Foundation;
using UIKit;

namespace ImageCropperDemo
{
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            ImageCropper.Maui.Platform.Init();
            return base.FinishedLaunching(application, launchOptions);
        }
    }
}