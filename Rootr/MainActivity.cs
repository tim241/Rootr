using Android.App;
using Android.Widget;
using Android.OS;
using System.IO;
using System;

namespace Rootr
{
    [Activity(Label = "Rootr", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {     
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            try
            {
                Java.Lang.Runtime.GetRuntime().Exec("su");
            }
            catch(Java.IO.IOException e)
            {
                if (e.ToString().Contains("null"))
                {
                    // TODO: Block back button from bypassing the "Device is not rooted" Msgbox.  
                    new AlertDialog.Builder(this).SetTitle("Error:").SetMessage("Device is not rooted.").SetPositiveButton("Okay",(sender, args) => { System.Environment.Exit(1); }).Show();
                }
                else
                    Toast.MakeText(ApplicationContext, e.ToString(), ToastLength.Long).Show(); 
            }
            Button button1 = FindViewById<Button>(Resource.Id.button1);
            button1.Click += delegate
            {
                StartActivity(typeof(mount));
            };
        }
    }
}

