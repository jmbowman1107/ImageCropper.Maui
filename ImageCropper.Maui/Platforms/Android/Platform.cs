using Android.App;
using Android.Content;
using Android.App.Frag
using Com.Canhub.Cropper;

namespace ImageCropper.Maui
{
    public class Platform
    {
        public static void Init()
        {
            DependencyService.Register<IImageCropperWrapper, PlatformImageCropper>();
        }

        public static async void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            new CropImageActivity().
            if (requestCode == CropImage.CropImageActivityRequestCode)
            {
                CropImage.ActivityResult result = CropImage.ActivityResult(data);

                // small delay
                await System.Threading.Tasks.Task.Delay(TimeSpan.FromMilliseconds(100));
                if (resultCode == Result.Ok)
                {
                    ImageCropper.Current.Success?.Invoke(result.Uri.Path);
                }
                else if ((int)resultCode == (int)(CropImage.CropImageActivityResultErrorCode))
                {
                    ImageCropper.Current.Faiure?.Invoke();
                }
            }
        }
    }
}
