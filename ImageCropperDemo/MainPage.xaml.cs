namespace ImageCropperDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected async void OnClickedRectangle(object sender, EventArgs e)
        {
            imageView.Source = null;
            new ImageCropper.Maui.ImageCropper()
            {
                //                PageTitle = "Test Title",
                //                AspectRatioX = 1,
                //                AspectRatioY = 1,
                Success = (imageFile) =>
                {
                    Dispatcher.Dispatch(() =>
                    {
                        imageView.Source = ImageSource.FromFile(imageFile);
                    });
                },
                Failure = () => {
                    Console.WriteLine("Error capturing an image to crop.");
                }
            }.Show(this);
        }

        private async void OnClickedCircle(object sender, EventArgs e)
        {
            imageView.Source = null;
            new ImageCropper.Maui.ImageCropper()
            {
                CropShape = ImageCropper.Maui.ImageCropper.CropShapeType.Oval,
                Success = (imageFile) =>
                {
                    Dispatcher.Dispatch(() =>
                    {
                        imageView.Source = ImageSource.FromFile(imageFile);
                    });
                },
                Failure = () => {
                    Console.WriteLine("Error capturing an image to crop.");
                }
            }.Show(this);
        }
    }
}