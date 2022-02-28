﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using Prism;
using Prism.Ioc;

[assembly: Shiny.ShinyApplication(
  ShinyStartupTypeName = "XamarinHelloBle.Client.Startup",
  XamarinFormsAppTypeName = "XamarinHelloBle.Client.App")]

namespace XamarinHelloBle.Droid
{
  public class AndroidInitializer : IPlatformInitializer
  {
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
      // Register any platform specific implementations
    }
  }

  [Activity(Theme = "@style/MainTheme",
            ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
  public partial class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
  {
    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
    {
      Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
      //// ShinyOnRequestPermissionsResult(requestCode, permissions, grantResults);
      base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
    }

    protected override void OnCreate(Bundle savedInstanceState)
    {
      //// this.ShinyOnCreate();  // Shiny.ShinyOnCreate();

      TabLayoutResource = Resource.Layout.Tabbar;
      ToolbarResource = Resource.Layout.Toolbar;

      base.OnCreate(savedInstanceState);

      global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
      LoadApplication(new Client.App(new AndroidInitializer()));
    }
  }
}
