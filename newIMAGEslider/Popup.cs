
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
using Android.Webkit;

namespace PI1M_Dashboard.T1.Droid
{
	[Activity (Label = "s")]
	public class Popup : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.popup);
			// Create your application here
			string url = Intent.GetStringExtra ("url") ?? "Data not available";


			WebView webView = FindViewById<WebView> (Resource.Id.LocalWebView);
			webView.SetWebViewClient (new WebViewClient ());

			//webView.LoadUrl ("http://www.xamarin.com");

			// Some websites will require Javascript to be enabled
			webView.Settings.JavaScriptEnabled = true;
			webView.LoadUrl(url);

			// allow zooming/panning            
			webView.Settings.BuiltInZoomControls = true;
			webView.Settings.UseWideViewPort = true;	
			webView.SetInitialScale (1);

			webView.Settings.SetSupportZoom (true);

			// scrollbar stuff            
			webView.ScrollBarStyle = ScrollbarStyles.OutsideOverlay; 
			// so there's no 'white line'            
			webView.ScrollbarFadingEnabled = false;
		}
	}
}
