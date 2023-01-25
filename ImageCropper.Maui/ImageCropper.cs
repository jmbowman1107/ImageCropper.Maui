using System.IO;

namespace ImageCropper.Maui
{
    public class ImageCropper
    {
        public static ImageCropper Current { get; set; }

        public ImageCropper()
        {
            Current = this;
        }

        public enum CropShapeType
        {
            Rectangle,
            Oval
        };

        public CropShapeType CropShape { get; set; } = CropShapeType.Rectangle;

        public int AspectRatioX { get; set; } = 0;

        public int AspectRatioY { get; set; } = 0;

        public string PageTitle { get; set; } = null;

        public string SelectSourceTitle { get; set; } = "Select source";

        public string TakePhotoTitle { get; set; } = "Take Photo";

        public string PhotoLibraryTitle { get; set; } = "Photo Library";

        public string CancelButtonTitle { get; set; } = "Cancel";

        /// <summary>
        /// Boton para realizar el recorte
        /// </summary>
        public string CropButtonTitle { get; set; } = "Crop";

        public Action<string> Success { get; set; }

        public Action Failure { get; set; }

        /*
        public PickMediaOptions PickMediaOptions { get; set; } = new PickMediaOptions
        {
            PhotoSize = PhotoSize.Large,
        };

        public StoreCameraMediaOptions StoreCameraMediaOptions { get; set; } = new StoreCameraMediaOptions();
        */

        public MediaPickerOptions MediaPickerOptions { get; set; } = new MediaPickerOptions();

        public async void Show(Page page, string imageFile = null)
        {
            if (imageFile == null)
            {
                FileResult file = null;
                string newFile = null;

                string action = await page.DisplayActionSheet(SelectSourceTitle, CancelButtonTitle, null, TakePhotoTitle, PhotoLibraryTitle);
                try
                {
                    if (action == TakePhotoTitle)
                    {
                        file = await MediaPicker.CapturePhotoAsync(MediaPickerOptions);
                    }
                    else if (action == PhotoLibraryTitle)
                    {
                        file = await MediaPicker.PickPhotoAsync(MediaPickerOptions);
                    }
                    else
                    {
                        Failure?.Invoke();
                        return;
                    }

                    if (file != null)
                    {
                        // save the file into local storage
                        newFile = Path.Combine(FileSystem.CacheDirectory, file.FileName);

                        //Mover a cache local
                        if (File.Exists(newFile))
                        {
                            File.Delete(newFile);
                        }

                        //Copiarlo llevaba mucho trabajo
                        using (var stream = await file.OpenReadAsync())
                        using (var newStream = File.OpenWrite(newFile))
                        {
                            await stream.CopyToAsync(newStream);
                            stream.Close();
                            newStream.Close();
                        }

                        //File.Move(file.FullPath, newFile);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
                }

                if (file == null || newFile == null)
                {
                    Failure?.Invoke();
                    return;
                }
                if (DeviceInfo.Platform == DevicePlatform.Android)
                {
                    //Delay for fix Xamarin.Essentials.Platform.CurrentActivity no MediaPicker
                    await Task.Delay(TimeSpan.FromMilliseconds(2000));
                }
                imageFile = newFile;
            }

            // small delay
            await Task.Delay(TimeSpan.FromMilliseconds(100));
            DependencyService.Get<IImageCropperWrapper>().ShowFromFile(this, imageFile);
        }
    }
}