using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace App2
{
    [Activity(Label = "App2", MainLauncher = true, Icon = "@drawable/One")]
    public class MainActivity : Activity
    {
        
        Button jump;
        //TimePicker tp;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
                      
            //tp = FindViewById<TimePicker>(Resource.Id.tp);

            //jump = FindViewById<Button>(Resource.Id.myButton);
            //jump.Click += new EventHandler(jump_Click);
            
        }
        private void jump_Click(object sender, EventArgs e)
        {
            //Intent intent = new Android.Content.Intent(this, typeof(Activity1));
            //StartActivity(intent);
        }

        
        
        
    }
}

