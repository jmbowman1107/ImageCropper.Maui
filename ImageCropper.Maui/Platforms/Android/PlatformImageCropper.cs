using Com.Canhub.Cropper;
using System.Diagnostics;
using Android.Graphics;
using 

namespace ImageCropper.Maui
{
    // All the code in this file is only included on Android.
    public class PlatformImageCropper : Fragment, IImageCropperWrapper
    {

        public void ShowFromFile(ImageCropper imageCropper, string imageFile)
        {
            try
            {
                
                CropImageContractOptions.ActivityBuilder activityBuilder = CropImage.Activity(Android.Net.Uri.FromFile(new Java.IO.File(imageFile)));
                activityBuilder.SetCropMenuCropButtonTitle(imageCropper.CropButtonTitle);
                activityBuilder.SetOutputCompressFormat(Bitmap.CompressFormat.Png);

                if (imageCropper.CropShape == ImageCropper.CropShapeType.Oval)
                {
                    var test = new CropImageView(Microsoft.Maui.ApplicationModel.Platform.CurrentActivity);
                    test.Crop
                    CropImageView().CropCornerShape = 
                    activityBuilder.SetCropShape(CropImageView.CropShape.Oval);
                }
                else
                {
                    activityBuilder.SetCropShape(CropImageView.CropShape.Rectangle);
                }

                if (imageCropper.AspectRatioX > 0 && imageCropper.AspectRatioY > 0)
                {
                    activityBuilder.SetFixAspectRatio(true);
                    activityBuilder.SetAspectRatio(imageCropper.AspectRatioX, imageCropper.AspectRatioY);
                }
                else
                {
                    activityBuilder.SetFixAspectRatio(false);
                }

                if (!string.IsNullOrWhiteSpace(imageCropper.PageTitle))
                {
                    activityBuilder.SetActivityTitle(imageCropper.PageTitle);
                }

                //Console.WriteLine("CurrentActivity. " + Xamarin.Essentials.Platform.CurrentActivity.PackageName);
                activityBuilder.Start(Microsoft.Maui.ApplicationModel.Platform.CurrentActivity); ;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

        }

    }
}