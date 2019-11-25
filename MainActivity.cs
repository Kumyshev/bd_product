using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace DBProductS
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            
            Button btnKARP = FindViewById<Button>(Resource.Id.btnKarp);
            btnKARP.Click += delegate {
                edData.NAME = "КАРП";
                StartActivity(typeof(edData));
            };
            Button btnAmur = FindViewById<Button>(Resource.Id.btnAmur);
            btnAmur.Click += delegate {
                edData.NAME = "АМУР";
                StartActivity(typeof(edData));
            };
            Button btnForel = FindViewById<Button>(Resource.Id.btnForel);
            btnForel.Click += delegate {
                edData.NAME = "ФОРЕЛЬ";
                StartActivity(typeof(edData));
            };
            Button btnTolstolobik = FindViewById<Button>(Resource.Id.btnTolstolobik);
            btnTolstolobik.Click += delegate {
                edData.NAME = "ТОЛСТОЛОБИК";
                StartActivity(typeof(edData));
            };
            Button btnSom = FindViewById<Button>(Resource.Id.btnSom);
            btnSom.Click += delegate {
                edData.NAME = "СОМ";
                StartActivity(typeof(edData));
            };

            Button btnStatistics = FindViewById<Button>(Resource.Id.btnStatistics);
            btnStatistics.Click += delegate {
                StartActivity(typeof(getData));
            };
            Button btnExit = FindViewById<Button>(Resource.Id.btnExit);
            btnExit.Click += delegate {
                var activity = (Activity)this;
                activity.FinishAffinity();
            };

        }
    }
}