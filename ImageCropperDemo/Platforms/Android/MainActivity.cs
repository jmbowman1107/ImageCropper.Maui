using System;
using Android.App;
using Android.Content.PM;
using Android.OS;

namespace ImageCropperDemo
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            new ImageCropper.Maui.Platform().Init(this);
            base.OnCreate(savedInstanceState);
        }
    }
}