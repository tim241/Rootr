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

namespace Rootr
{
    [Activity(Label = "dd")]
    public class dd : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            // TODO: Add image selector with a (build-in?) file browser + add a partition selector.
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.dd);
            Button write = FindViewById<Button>(Resource.Id.button1);
            EditText image = FindViewById<EditText>(Resource.Id.editText1);
            EditText partition = FindViewById<EditText>(Resource.Id.editText2);
            write.Click += delegate { Java.Lang.Runtime.GetRuntime().Exec("su -C dd if=" + image.Text + " of=" + partition.Text); };         
        }
    }
}