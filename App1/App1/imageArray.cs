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
    [Activity(Label = "imageArray")]
    public class ImageAdapter : BaseAdapter
    {
        Context context;
        Dictionary<int, ImageView> dict;
        public ImageAdapter(Context c)
        {
            context = c;
            dict = new Dictionary<int, ImageView>();
        }
        public override int Count
        {
            get { return thumbIds.Length; }
        }
        public override  Java.Lang.Object GetItem(int position){return null;}
        public override long GetItemId(int position){return 0;}


        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            bool bOut;
            ImageView i;
            bOut = dict.TryGetValue(position, out i);

            if (bOut == false)
            {
                i = new ImageView(context);
                i.SetImageResource(thumbIds[position]);
                i.LayoutParameters = new Gallery.LayoutParams(150,100);
                i.SetScaleType(ImageView.ScaleType.CenterInside);
                dict.Add(position,i);
            }
            return i;
        }        int[] thumbIds = {                         Resource.Drawable.log1,                         Resource.Drawable.log2,                         Resource.Drawable.log3,                         Resource.Drawable.log4                         };
    }
}