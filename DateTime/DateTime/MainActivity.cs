using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace DateTime1
{
    [Activity(Label = "DateTime", MainLauncher = true, Icon = "@drawable/Icon")]
    public class MainActivity : Activity
    {
        Button btnTimeClose, btnTimeValues;
        int nowHour, nowMinute;
        TimePicker tp;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            btnTimeClose = FindViewById<Button>(Resource.Id.btnTimeClose);
            btnTimeClose.Click += new EventHandler(btnTimeClose_Click);
            btnTimeValues = FindViewById<Button>(Resource.Id.btnTimeValues);
            btnTimeValues.Click += new EventHandler(btnTimeValues_Click);
            nowHour = DateTime.Now.Hour;
            nowMinute = DateTime.Now.Minute;

            tp = FindViewById<TimePicker>(Resource.Id.tp);



        }
        void btnTimeValues_Click(object sender, EventArgs e)
        {
            TextView tv = FindViewById<TextView>(Resource.Id.dctv);
            DigitalClock dc = FindViewById<DigitalClock>(Resource.Id.dc);
            tv.Text = dc.Text;

            DatePicker dp = FindViewById<DatePicker>(Resource.Id.dp);
            TextView dptv = FindViewById<TextView>(Resource.Id.dptv);
            DateTime dt = new DateTime(dp.Year, dp.Month + 1, dp.DayOfMonth, nowHour, nowMinute, 0);
            dptv.Text = dt.ToString();
            TextView tptv = FindViewById<TextView>(Resource.Id.tptv);
            tptv.Text = "功能按钮";
        }
        void tp_TimeChanged(TimePicker view, int hourofDay, int minute)
        {
            nowHour = hourofDay;
            nowMinute = minute;
        }
        void btnTimeClose_Click(object sender, EventArgs e)
        {
            this.Finish();
        }
    }
}