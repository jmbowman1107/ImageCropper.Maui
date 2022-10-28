namespace ImageCropper.Maui
{
    public class Platform
    {
        public void Init()
        {
            DependencyService.Register<IImageCropperWrapper, PlatformImageCropper>();
        }
    }
}
