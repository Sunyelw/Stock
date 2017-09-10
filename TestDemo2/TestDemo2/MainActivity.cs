using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;

namespace TestDemo2
{
    [Activity(Label = "TestDemo2", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {            
            base.OnCreate(bundle);
            //两种视图加载方法
            SetContentView(Resource.Layout.Main);

            Button a = FindViewById<Button>(Resource.Id.MyButton);
            a.Click += delegate { a.Text = string.Format("Click {0} times", count++); };

            TextView t1 = FindViewById<TextView>(Resource.Id.textView1);

            LinearLayout layout = new LinearLayout(this);
            layout.Orientation = Orientation.Vertical;

            TextView tv = new TextView(this);
            tv.Text = "First View.";

            Button b = new Button(this);
            b.Text = "Go Next View.";
            b.Click  += b_Click;

            EditText et = FindViewById<EditText>(Resource.Id.editText1);
            //et.Text = "Please input your code.";
            

            layout.AddView(tv);
            layout.AddView(b);
            //layout.AddView(et);
            //SetContentView(layout);
            
        }

        void b_Click(object sender, EventArgs e)
        {
            Intent intent = new Android.Content.Intent(this, typeof(Activity1));
            intent.PutExtra("MessageName", "hi, this is View1");
            StartActivity(intent);
        }
    }
}

