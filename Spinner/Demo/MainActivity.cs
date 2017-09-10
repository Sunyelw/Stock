using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Demo
{
    [Activity(Label = "Demo", MainLauncher = true, Icon = "@drawable/Icon")]
    public class MainActivity : Activity
    {
        Spinner state;
        TextView tvSp;
        ArrayAdapter<String> aas;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            state = FindViewById<Spinner>(Resource.Id.Sp);
            tvSp = FindViewById<TextView>(Resource.Id.tvSp);
            aas = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem);
            state.Adapter = aas;
            aas.Add(String.Empty);
            aas.Add("Alabam");
            aas.Add("China");
            aas.Add("American");
            aas.Add("California");

            state.Adapter = aas;
            state.ItemSelected += sp_ItemSelected;
            
            
        }

        void sp_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            tvSp.Text = Convert.ToString(aas.GetItem(e.Position));
        }
    }
}

