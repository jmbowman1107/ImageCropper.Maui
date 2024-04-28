# ImageCropper.Maui

.NET MAUI plugin to crop and rotate photos. 

Ported over and updated from from : https://github.com/stormlion227/ImageCropper.Forms

[![NuGet](https://img.shields.io/nuget/v/ImageCropper.Maui.svg)](https://www.nuget.org/packages/ImageCropper.Maui/)

Supports Android and iOS.
* Android library from : https://github.com/CanHub/Android-Image-Cropper
* iOS library from : https://github.com/TimOliver/TOCropViewController

## Features

* Cropping image.
* Rotating image.
* Aspect ratio.
* Circle/Rectangle shape.

## Screen-Shots

### Android
<img src="ScreenShots/Android_Rectangle.gif" alt="Crop/Rotate image(Rectangle/Android)"/> <img src="ScreenShots/Android_Circle.gif" alt="Crop/Rotate image(Circle/Android)"/>

### iOS
<img src="ScreenShots/iOS_Rectangle.gif" alt="Crop/Rotate image(Rectangle/iOS)"/> <img src="ScreenShots/iOS_Circle.gif" alt="Crop/Rotate image(Circle/iOS)" />

## Setup

* Install the [nuget package](https://www.nuget.org/packages/ImageCropper.Maui/) in portable and all platform specific projects. NOTE: TOCropView.Maui results in long file paths, and if your base repo path is little long, this package cannot be succesfully installed from Visual Studio. To work around this issue install the package using 'dotnet restore' from the CLI.
  
* This plugin uses the **MediaPicker**, so be sure to complete the full setup this. Please fully read through the [MediaPicker description](https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/device-media/picker).

### Android

Add the following to your AndroidManifest.xml inside the <application> tags:
```xml	
	<activity android:name="com.canhub.cropper.CropImageActivity"
	          android:theme="@style/Base.Theme.AppCompat"/>	
```

In MainActivity.cs file:
```cs
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            new ImageCropper.Maui.Platform().Init(this);
            base.OnCreate(savedInstanceState);
        }
    }


### iOS

In AppDelegate.cs file:

```cs
     new ImageCropper.Maui.Platform().Init(this);
```
## Usage

### Show ImageCropper page.
```cs
    new ImageCropper()
    {
        Success = (imageFile) =>
        {
            Dispatcher.Dispatch(() =>
            {
                imageView.Source = ImageSource.FromFile(imageFile);
            });
        }
    }.Show(this);
```
### Show it with additional parameters.
```cs
    new ImageCropper()
    {
        PageTitle = "Test Title",
        AspectRatioX = 1,
        AspectRatioY = 1,
	CropShape = ImageCropper.CropShapeType.Oval,
	SelectSourceTitle = "Select source",
	TakePhotoTitle = "Take Photo",
	PhotoLibraryTitle = "Photo Library",
	CancelButtonTitle = "Cancel",
        Success = (imageFile) =>
        {
            Dispatcher.Dispatch(() =>
            {
                imageView.Source = ImageSource.FromFile(imageFile);
            });
        }
    }.Show(this);
```
### Show it with a image
```cs
    new ImageCropper()
    {
        Success = (imageFile) =>
        {
            Dispatcher.Dispatch(() =>
            {
                imageView.Source = ImageSource.FromFile(imageFile);
            });
        }
    }.Show(this, imageFileName);
```
### Properties
* PageTitle
* AspectRatioX
* AspectRatioY
* CropShape
* Initial image can be set in Show function.

## Contributions
Contributions are welcome!
