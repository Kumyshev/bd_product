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
    [Activity(Label = "getData")]
    class getData : Activity
    {
        

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.GETdata);

            TextView text = FindViewById<TextView>(Resource.Id.lblItogo);
            ListView list = FindViewById<ListView>(Resource.Id.dbList);
            Button btnBack = FindViewById<Button>(Resource.Id.btnBack2);

            String[] dataNAME = { "ВСЯ РЫБА", "КАРП", "АМУР", "ТОЛСТОЛОБИК", "ФОРЕЛЬ", "СОМ" };
            ArrayAdapter<String> SelectNAMEadapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleSpinnerItem, dataNAME);
            SelectNAMEadapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            Spinner spSelectName = FindViewById<Spinner>(Resource.Id.spSelectName);
            spSelectName.Adapter = SelectNAMEadapter;


            String[] dataDATE = { "ЗА ВСЕ ВРЕМЯ", "ЗА ГОД", "ЗА КВАРТАЛ", "ЗА МЕСЯЦ", "ЗА СУТКИ" };
            ArrayAdapter<String> SelectDATEadapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleSpinnerItem, dataDATE);
            SelectDATEadapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            Spinner spSelectDate = FindViewById<Spinner>(Resource.Id.spSelectDate);
            spSelectDate.Adapter = SelectDATEadapter;


            string firstSelect = spSelectName.SelectedItem.ToString();



            btnBack.Click += delegate {
                StartActivity(typeof(MainActivity));
            };

            spSelectName.ItemSelected += (s, e) =>
            {
                if (firstSelect.Equals(spSelectName.SelectedItem.ToString()))
                {
                    Database.NAME = "ВСЯ РЫБА";
                }
                else
                {
                    Database.NAME = spSelectName.SelectedItem.ToString();
                    firstSelect = Database.NAME;
                    list.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, DBPath.Database.GET_DATA());
                    double sum = DBPath.Database.GET_SUM();
                    text.Text = "СУММА ИТОГО : " + sum + " РУБ.";
                }
            };


            string secondSelect = spSelectDate.SelectedItem.ToString();

            spSelectDate.ItemSelected += (s, e) =>
            {
                if (secondSelect.Equals(spSelectDate.SelectedItem.ToString()))
                {
                    Database.DATE = "ЗА ВСЕ ВРЕМЯ";
                    list.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, DBPath.Database.GET_DATA());
                    double sum = DBPath.Database.GET_SUM();
                    text.Text = "СУММА ИТОГО : " + sum + " РУБ.";
                }
                else
                {
                    Database.DATE = spSelectDate.SelectedItem.ToString();
                    secondSelect = Database.DATE;
                    list.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, DBPath.Database.GET_DATA());
                    double sum = DBPath.Database.GET_SUM();
                    text.Text = "СУММА ИТОГО : " + sum + " РУБ.";
                }
            };

            
            list.ItemClick += (s, e) =>
            {


                AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);
                alertDialog.SetTitle("Изменить запись!");
                alertDialog.SetMessage(Convert.ToString(list.GetItemAtPosition(e.Position)));
                alertDialog.SetNegativeButton("Нет", delegate { alertDialog.Dispose(); });
                alertDialog.SetPositiveButton("Да", delegate
                {
                    alertDialog.Dispose();
                });
                alertDialog.Show();

                //Toast.MakeText(this, Convert.ToString(list.GetItemAtPosition(e.Position)), ToastLength.Long).Show();
                
            };

        }
    }
}