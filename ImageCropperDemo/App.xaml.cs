namespace ImageCropperDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            Window window = base.CreateWindow(activationState);

            window. += (s, e) =>
            {
                ImageCropper.Maui.Extensions.StartUpExtensions.UseImageCropper();
                // Custom logic
            };

            return window;
        }
    }
}