using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TestDemo1
{
    [Activity(Label = "TestDemo1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        TextView tv;
        protected override void OnCreate(Bundle bundle)
        {
            
            base.OnCreate(bundle);
            LinearLayout layout = new LinearLayout(this);
            layout.Orientation = Orientation.Vertical;
            tv = new TextView(this);
            tv.Text = "Hello baby";

            Button b = new Button(this);
            b.Text = "click your ideo";
            b.Click += b_Click;
            
            layout.AddView(tv);
            layout.AddView(b);
            
            SetContentView(layout);
        }
        void b_Click(Object sender, EventArgs e)
        {
            tv.Text = "Click times: " + count;
            count++;
        }
    }
}

