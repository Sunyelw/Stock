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

namespace App2
{
    [Activity(Label = "Activity1")]
    public class Activity1 : Activity
    {
        Button btnTimeClose, btnTimeValues,btnReturn;
        int nowHour, nowMinute;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //LinearLayout layout = new LinearLayout(this);
            //layout.Orientation = Orientation.Vertical;
            SetContentView(Resource.Layout.Main);
            nowHour = DateTime.Now.Hour;
            nowMinute = DateTime.Now.Minute;
          
            btnTimeClose = FindViewById<Button>(Resource.Id.btnTimeClose);
            btnTimeClose.Click += new EventHandler(btnTimeClose_Click);
            btnTimeValues = FindViewById<Button>(Resource.Id.btnTimeValues);
            btnTimeValues.Click += new EventHandler(btnTimeValues_Click);
            btnReturn = FindViewById<Button>(Resource.Id.btnReturn);
            btnReturn.Click += new EventHandler(btnReturn_Click);

            //layout.AddView(btnTimeClose);
            //layout.AddView(btnTimeValues);
            //layout.AddView(btnReturn);
            //SetContentView(layout);
            
        }

        public void btnTimeValues_Click(object sender, EventArgs e)
        {
            DigitalClock dc = FindViewById<DigitalClock>(Resource.Id.dc);

            DatePicker dp = FindViewById<DatePicker>(Resource.Id.dp);
            TextView dptv = FindViewById<TextView>(Resource.Id.dptv);
            DateTime dt = new DateTime(dp.Year, dp.Month + 1, dp.DayOfMonth, nowHour, nowMinute, 0);
            dptv.Text = dt.ToString();
            TextView tptv = FindViewById<TextView>(Resource.Id.tptv);
            tptv.Text = "¹¦ÄÜ°´Å¥";
        }
        void btnTimeClose_Click(object sender, EventArgs e)
        {
            this.Finish();
        }
        void btnReturn_Click(object sender, EventArgs e)
        {
            Intent intent = new Android.Content.Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
        void tp_TimeChanged(TimePicker view, int hourofDay, int minute)
        {
            nowHour = hourofDay;
            nowMinute = minute;
        }
    }
}