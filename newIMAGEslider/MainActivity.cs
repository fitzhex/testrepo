using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;
using Android.Graphics.Drawables;
using com.refractored;
using Android.Support.V4.View;
using Android.Util;
using Android.Graphics;
using System.Threading;
using System.Timers;
using ViewPagerIndicator;

namespace PI1M_Dashboard.T1.Droid
{
	[Activity (Label = "Sample", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : BaseActivity, ViewPager.IOnPageChangeListener
	{
		int count = 1;

		protected override int LayoutResource {
			get {
				return Resource.Layout.activity_main;
			}
		}

		private MyPagerAdapter adapter;
		private Drawable oldBackground = null;
		private int currentColor;
		private ViewPager pager;
		private PagerSlidingTabStrip tabs;


		int x=0;
		int end=7;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			adapter = new MyPagerAdapter(SupportFragmentManager);
			pager = FindViewById<ViewPager> (Resource.Id.pager);
			tabs = FindViewById<PagerSlidingTabStrip> (Resource.Id.tabs);
			pager.Adapter = adapter;
			tabs.Visibility = ViewStates.Invisible;
			tabs.SetViewPager (pager);

			var pageMargin = (int)TypedValue.ApplyDimension (ComplexUnitType.Dip, 4, Resources.DisplayMetrics);
			pager.PageMargin = pageMargin;
			tabs.OnPageChangeListener = this;

			PageIndicator mIndicator = FindViewById<CirclePageIndicator> (Resource.Id.indicator);
			mIndicator.SetViewPager (pager);

			mIndicator.SetOnPageChangeListener (new MyPageChangeListener (this));


//			timer.Elapsed+=timer_Elapsed;
//			timer.Start();


		    SupportActionBar.SetDisplayHomeAsUpEnabled(false);
		    SupportActionBar.SetHomeButtonEnabled(false);
		}

	
		private void TimerCallback(Object o) {
			// Display the date/time when this method got called.
		while (x <= end) {
				x++;
				Console.Error.WriteLine ("x"+x);

			}
			// Force a garbage collection to occur for this demo.
			//GC.Collect();
		}

		static System.Timers.Timer timer = new System.Timers.Timer(3000);
		static int i = 0;

		private  void timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			i++;
			RunOnUiThread (() => pager.SetCurrentItem (i, true));

			Console.WriteLine("=================================================");
			Console.WriteLine("                  DIFFUSE THE BOMB");
			Console.WriteLine(""); 
			Console.WriteLine("                Time Remaining:  " + i.ToString());
			Console.WriteLine("");        
			Console.WriteLine("=================================================");

			if (i == 10) 
			{
				Console.WriteLine("");
				Console.WriteLine("==============================================");
				Console.WriteLine("         B O O O O O M M M M M ! ! ! !");
				Console.WriteLine("");
				Console.WriteLine("               G A M E  O V E R");
				Console.WriteLine("==============================================");

				i = 0;
				//.Dispose();
			}

			GC.Collect();
		}
	


		#region IOnTabReselectedListener implementation
		public void OnTabReselected (int position)
		{
			Toast.MakeText(this, "Tab reselected: " + position, ToastLength.Short).Show();
		}
		#endregion

//		private void ChangeColor(Color newColor) {
//			tabs.SetBackgroundColor(newColor);
//		
//			// change ActionBar color just if an ActionBar is available
//			Drawable colorDrawable = new ColorDrawable(newColor);
//			Drawable bottomDrawable = new ColorDrawable(Resources.GetColor(Android.Resource.Color.Transparent));
//			LayerDrawable ld = new LayerDrawable(new Drawable[]{colorDrawable, bottomDrawable});
//			if (oldBackground == null) {
//				SupportActionBar.SetBackgroundDrawable(ld);
//			} else {
//				TransitionDrawable td = new TransitionDrawable(new Drawable[]{oldBackground, ld});
//				SupportActionBar.SetBackgroundDrawable(td);
//				td.StartTransition(200);
//			}
//
//			oldBackground = ld;
//			currentColor = newColor;
//		}
//		[Java.Interop.Export("onColorClicked")]
//		public void OnColorClicked(View v) {
//			var color = Color.ParseColor(v.Tag.ToString());
//			ChangeColor(color);
//		}

		protected override void OnSaveInstanceState (Bundle outState)
		{
			base.OnSaveInstanceState (outState);
			outState.PutInt ("currentColor", currentColor);
		}

		protected override void OnRestoreInstanceState (Bundle savedInstanceState)
		{
			base.OnRestoreInstanceState (savedInstanceState);
			currentColor = savedInstanceState.GetInt ("currentColor");
//			ChangeColor (new Color (currentColor));
		}


		public void OnPageScrolled (int position, float positionOffset, int positionOffsetPixels)
		{
			Console.Error.Write (1);

		}

		public void OnPageSelected (int position)
		{
			Console.Error.Write (0);
		
		}

		public void OnPageScrollStateChanged (int state)
		{
			Console.Error.Write (2);

		}


	}

	public class MyPageChangeListener : Java.Lang.Object, ViewPager.IOnPageChangeListener
	{
		Context _context;
		#region tobeimplemented

		public MyPageChangeListener (Context context)
		{
			_context = context;	
		}
		#endregion
		#region IOnPageChangeListener implementation
		public void OnPageScrollStateChanged (int p0)
		{

		}

		public void OnPageScrolled (int p0, float p1, int p2)
		{
		}

		public void OnPageSelected (int position)
		{
		}
		#endregion
	}

	public class MyPagerAdapter : FragmentPagerAdapter{
		private  string[] Titles = {"Categories", "Home", "Top Paid", "Top Free", "Top Grossing", "Top New Paid",
			"Top New Free", "Trending", "Trending", "Trending", "Trending"};

		public MyPagerAdapter(Android.Support.V4.App.FragmentManager fm) : base(fm)
		{
		}

		public override Java.Lang.ICharSequence GetPageTitleFormatted (int position)
		{
			return new Java.Lang.String (Titles [position]);
		}
		#region implemented abstract members of PagerAdapter
		public override int Count {
			get {
				return Titles.Length;
			}
		}
		#endregion
		#region implemented abstract members of FragmentPagerAdapter
		public override Android.Support.V4.App.Fragment GetItem (int position)
		{
			return SuperAwesomeCardFragment.NewInstance (position);
		}
		#endregion
	}
}


