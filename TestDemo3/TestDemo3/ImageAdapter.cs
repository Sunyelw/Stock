using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Database;
using Android.Provider;

namespace TestDemo3
{
    public class ImageAdapter : BaseAdapter
    {
        Context _Context;
        ICursor _ImageCursor;
        protected ICursor ImageCursor
        {
            get
            {
                if (_ImageCursor == null)
                {
                    _ImageCursor = GetImageCursor();
                }
                return _ImageCursor;
            }
            set
            {
                _ImageCursor = value;
            }
        }
        public ImageAdapter(Context c)
        {
            _Context = c;
        }
        private ICursor GetImageCursor()
        {
            string[] Projection = { MediaStore.Images.Thumbnails.ImageId };
            var ImageCursor = ((Activity)_Context).ManagedQuery(MediaStore.Images.Thumbnails.ExternalContentUri,
                Projection, null, null, null);
            return ImageCursor;
        }
        public override int Count
        {
            get { return ImageCursor.Count; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            ImageCursor.MoveToPosition(position);
            var ImageId = ImageCursor.GetString(0);
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                ImageView ReturnView = new ImageView(_Context);
                ImageCursor.MoveToPosition(position);

                var ImageId = ImageCursor.GetString(0);
                ReturnView.SetImageURI(Android.Net.Uri.WithAppendedPath(MediaStore.Images.Thumbnails.ExternalContentUri, ImageId));
                ReturnView.SetScaleType(ImageView.ScaleType.CenterCrop);
                return ReturnView;
            }
            else
            {
                return (ImageView)convertView;
            }
        }
    }
}
