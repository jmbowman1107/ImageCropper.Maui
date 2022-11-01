using Android.Content;
using Android.OS;
using Android.Views;
using AndroidX.ViewBinding;

namespace Com.Canhub.Cropper.Databinding
{
    public partial class CropImageActivityBinding
    {
        View IViewBinding.Root => this.Root;
    }
}

namespace Com.Canhub.Cropper
{
    public partial class CropImageContract
    {
        public override Intent CreateIntent(Context context, Java.Lang.Object? input)
        {
            return this.CreateIntent(context, (CropImageContractOptions)input);
        }
    }
}