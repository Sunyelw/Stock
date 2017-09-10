using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Database;
using Android.Provider;

namespace TestDemo3
{
    [Activity(Label = "Gallery View Sample", MainLauncher = true, Icon = "@drawable/icon")]
    public class GalleryViewSample : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            CreateGallery();

        }


        private void CreateGallery()
        {
            Gallery g = this.FindViewById<Gallery>(Resource.Id.gallery1);
            g.Adapter = new ImageAdapter(this);
        }
    }
}
