namespace ImageCropper.Maui
{
    public class Platform
    {
        public static void Init()
        {
            DependencyService.Register<IImageCropperWrapper, PlatformImageCropper>();
        }
    }
}
