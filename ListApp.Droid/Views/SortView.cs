using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using Java.IO;
using ListApp.Core;
using MvvmCross.Droid.Views;
using Console = System.Console;
using Debug = System.Diagnostics.Debug;

namespace ListApp
{
    [Activity(Theme = "@android:style/Theme.Material.Light", Label = "Сортировка задач", MainLauncher = true,
        HardwareAccelerated = true)]
    public class SortView : MvxActivity
    {
        public new SortViewModel ViewModel
        {
            get { return (SortViewModel) base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public override bool OnNavigateUp()
        {
            Finish();
            return true;
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            SetContentView(Resource.Layout.Sort);
            var listView = FindViewById<ListView>(Resource.Id.ListView);
            var dictTime = new JavaDictionary<string, object>()
            {
                { "img", Resource.Drawable.clock},
                {"name", "Отсортировать по дате"}
                
            };
            var dictPriority = new JavaDictionary<string, object>()
            {
                { "img", Resource.Drawable.important},
                {"name", "Отсортировать по приоритету"}

            };
            var dictName = new JavaDictionary<string, object>()
            {
                { "img", Resource.Drawable.people},
                {"name", "Отсортировать по имени"}

            };
            var simpleAdapter = new SimpleAdapter(
                this, new IDictionary<string, object>[] { dictTime, dictPriority, dictName }, Resource.Layout.sort_list_item, new[] { "img", "name" },
                new[] { Resource.Id.img, Resource.Id.name });
            listView.Adapter = simpleAdapter;
            listView.ItemClick += (sender, args) => Finish();
        }

    }
}