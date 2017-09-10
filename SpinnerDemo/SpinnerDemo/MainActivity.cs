using Android.App;
using Android.OS;
using Android.Widget;

namespace SpinnerDemo
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Spinner _citySpinner;
        private TextView _cityNameView;
        private ArrayAdapter<string> _cityInfos;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            _citySpinner = FindViewById<Spinner>(Resource.Id.sp_city);

            //_citySpinner.SetBackgroundColor();
            _cityNameView = FindViewById<TextView>(Resource.Id.txt_cityName);

            _cityInfos = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem);
            _cityInfos.Add(string.Empty);
            _cityInfos.Add("成都");
            _cityInfos.Add("兰州");
            _cityInfos.Add("武汉");
            _cityInfos.Add("上海");

            _citySpinner.Adapter = _cityInfos;
            _citySpinner.ItemSelected += CitySelectedEvent;
        }

        private void CitySelectedEvent(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            _cityNameView.Text = _cityInfos.GetItem(e.Position);
        }
    }
}