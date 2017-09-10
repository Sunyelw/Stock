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

namespace TestDemo2
{
    [Activity(Label = "Activity1")]
    public class Activity1 : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            LinearLayout layout = new LinearLayout(this);
            layout.Orientation = Orientation.Vertical;

            TextView tv = new TextView(this);
            tv.Text = "Second View, the data from first View is:" + (Intent.GetStringExtra("MessageName") ?? "nothing said");
            layout.AddView(tv);
            SetContentView(layout);
        }
    }
}