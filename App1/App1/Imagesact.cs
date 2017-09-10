using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App1
{
    [Activity(Label = "Imagesact", MainLauncher = true, Icon = "@drawable/icon")]
    public class Imagesact : Activity
    {
        Button btnClose;
        ImageButton ib;
        ImageView iv;
        Gallery g;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.images);

            btnClose = FindViewById<Button>(Resource.Id.btnImageClose);
            btnClose.Click += new EventHandler(btnClose_Click);
            g = FindViewById<Gallery>(Resource.Id.gal);
            TextView gtv = FindViewById<TextView>(Resource.Id.galtv);
            ib = FindViewById<ImageButton>(Resource.Id.ib);
            ib.SetImageResource(Resource.Drawable.log1);
            ib.Click += new EventHandler(ib_Click);
            ib.FocusChange += new EventHandler<View.FocusChangeEventArgs>(ib_FocusChange);
            iv = FindViewById<ImageView>(Resource.Id.iv);
            iv.SetImageResource(Resource.Drawable.log2);
            g.Adapter = new ImageAdapter(this);

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Finish();
        }
        private void ib_Click(object sneder, EventArgs e)
        {
            ib.SetImageResource(Resource.Drawable.log3); 
        }
        private void ib_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            if (e.HasFocus)
            {
                ib.SetImageResource(Resource.Drawable.log1);
            }
            else
            {
                ib.SetImageResource(Resource.Drawable.log3);
            }
        }
    }
}