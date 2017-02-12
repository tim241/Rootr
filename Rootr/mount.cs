using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Rootr
{
    [Activity(Label = "mount")]
    public class mount : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.mount);
            Button mount = FindViewById<Button>(Resource.Id.button1);
            EditText partition = FindViewById<EditText>(Resource.Id.editText1);
            EditText directory = FindViewById<EditText>(Resource.Id.editText2);
            mount.Click += delegate
            {
                Java.Lang.Runtime.GetRuntime().Exec("su - C mount " + partition.Text + " " + directory.Text);
            };
        }
    }
}