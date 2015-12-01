using Android.Support.V4.App;
using Android.OS;
using Android.Support.V4.View;


using Android.Widget;
using System.Collections.Generic;
using Square.Picasso;
using System;
using Android.Content;

namespace PI1M_Dashboard.T1.Droid
{
	public class SuperAwesomeCardFragment : Fragment
	{
		private int position;
		public static SuperAwesomeCardFragment NewInstance(int position)
		{
			var f = new SuperAwesomeCardFragment ();
			var b = new Bundle ();
			b.PutInt("position", position);
			f.Arguments = b;
			return f;
		}

		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			position = Arguments.GetInt ("position");
		}


		public override Android.Views.View OnCreateView (Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Bundle savedInstanceState)
		{
			var activity = Activity;
			List<string> list = new List<string>();
			list.Add ("http://myshop.pi1m.my/productImage/large/1444533960_17.jpg");
			list.Add ("http://myshop.pi1m.my/productImage/large/1444534057_11212641_1609266135987591_2834759448456854827_o.jpg");
			list.Add ("http://myshop.pi1m.my/productImage/large/1444533716_serunding%20pantang%202.jpg");
			list.Add ("http://myshop.pi1m.my/productImage/large/1444531420_ikan%20bilis.jpg");
			list.Add ("http://myshop.pi1m.my/productImage/large/1444446507_11703093_710210295781033_4275767256610608265_n.jpg");
			list.Add ("http://myshop.pi1m.my/productImage/large/1444445559_12039569_968112303227019_8292818094866461492_n.jpg");
			list.Add ("http://myshop.pi1m.my/productImage/large/1444385557_dnars.jpg");
			list.Add ("http://myshop.pi1m.my/productImage/large/1444385805_SET%20JIHAN.jpg");
			list.Add ("http://myshop.pi1m.my/productImage/large/1444384474_KAWAII.jpg");
			list.Add ("http://myshop.pi1m.my/productImage/large/1444323034_Karpet-01-300x225.jpg");
			list.Add ("http://myshop.pi1m.my/productImage/large/1444323034_Karpet-01-300x225.jpg");




			var root = inflater.Inflate(Resource.Layout.fragment_card, container, false);
			ImageView iv = root.FindViewById<ImageView> (Resource.Id.imageview);
			Picasso.With(activity)
				.Load(list[position])
				.Into(iv);
			//iv.SetImageResource (Resource.Drawable.ic_launcher);

			iv.Click += (object sender, System.EventArgs e) => popup(list[position]);

			ViewCompat.SetElevation(root, 50);
			return root;
		}

		private void popup(string url)
		{
			var activity2 = new Intent (Activity, typeof(Popup));
			activity2.PutExtra ("url", url);
			StartActivity (activity2);		
		}


	}
}

