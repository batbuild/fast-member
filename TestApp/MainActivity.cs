using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FastMember;
namespace TestApp
{
	public class MyType
	{
		public string MyName { get; set; }

		public void Something()
		{
			Console.WriteLine ("BLLLAAAAhh");
		}
	}
	[Activity(Label = "TestApp", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button>(Resource.Id.MyButton);
			var text = FindViewById<TextView>(Resource.Id.textView1);

			var owner = new MyType ();
			button.Click += delegate { 
				var typeAccessor = TypeAccessor.Create(typeof (MyType));
				typeAccessor[owner, "MyName"] = "Monkeys";
				button.Text = string.Format("{0} clicks! {1}", count++, owner.MyName); 

			};
		}
	}
}

