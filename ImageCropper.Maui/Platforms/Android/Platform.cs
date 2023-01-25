using AndroidX.Activity.Result;
using Com.Canhub.Cropper;
using Fragment = AndroidX.Fragment.App.Fragment;
using Object = Java.Lang.Object;

namespace ImageCropper.Maui
{
    public class Platform : Fragment, IActivityResultCallback
    {
        public MauiAppCompatActivity AppActivity { get; set; }

        public void Init(MauiAppCompatActivity activity)
        {
            DependencyService.Register<IImageCropperWrapper, PlatformImageCropper>();
            AppActivity = activity;;
            ImageCropperActivityResultLauncher = activity.RegisterForActivityResult(new CropImageContract(), this);
        }

        public static ActivityResultLauncher ImageCropperActivityResultLauncher { get; set; }

        public void OnActivityResult(Object cropImageResult)
        {
            if (cropImageResult is CropImage.ActivityResult result)
            {
                if (result.IsSuccessful)
                {
                    ImageCropper.Current.Success?.Invoke(result.GetUriFilePath(AppActivity, true));
                }
                else
                {
                    ImageCropper.Current.Failure?.Invoke();
                }
            }
            else
            {
                ImageCropper.Current.Failure?.Invoke();
            }
        }
    }
}
