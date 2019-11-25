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

namespace DBProductS
{
    [Activity(Label = "edData")]
    class edData : Activity
    {
        public static string NAME;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.EDdata);


            Button btnEDIT = FindViewById<Button>(Resource.Id.btnEdit);
            Button btnBack = FindViewById<Button>(Resource.Id.btnBack);
            EditText edtPRICE = FindViewById<EditText>(Resource.Id.edtPrice);
            EditText edtWEITH = FindViewById<EditText>(Resource.Id.edtWeight);


            btnBack.Click += delegate {
                StartActivity(typeof(MainActivity));
            };



            btnEDIT.Click += delegate {
                DateTime now = DateTime.Now;
                try
                {
                    DBPath.Database.EDIT_DATA(NAME, Convert.ToDouble(edtPRICE.Text), Convert.ToDouble(edtWEITH.Text), now);
                }
                catch (Exception)
                {
                    AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);
                    alertDialog.SetTitle("Операция не может быть выполнена!");
                    alertDialog.SetMessage("Необходимо ввести значение в поле.");
                    alertDialog.SetPositiveButton("ОК", delegate
                    {
                        alertDialog.Dispose();
                    });
                    alertDialog.Show();
                }
                edtPRICE.Text = "";
                edtWEITH.Text = "";

            };

            
        }
    }
}