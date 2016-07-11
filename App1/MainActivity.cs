using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Webkit;

namespace App1
{
    [Activity(Label = "App1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity , View.IOnClickListener 
    {

        WebView web;
        WebSettings setting;
        int count = 1;

        public void OnClick(View v)
        {
            throw new NotImplementedException();
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            web = FindViewById<WebView>(Resource.Id.webview);
            setting = web.Settings;

            web.Settings.SetSupportZoom(true);
            web.Settings.BuiltInZoomControls = true;
            web.Settings.LoadWithOverviewMode = true;
            web.ScrollBarStyle = ScrollbarStyles.OutsideOverlay;
            web.ScrollbarFadingEnabled = true;

            setting.JavaScriptEnabled = true;
            setting.SetSupportZoom(true);
            setting.DisplayZoomControls = false;
            web.SetWebViewClient(new MyWebViewClient());
            web.SetWebChromeClient(new WebChromeClient());
            web.LoadUrl("http://kbibazaar.com/tbx");



            




        }

        public class MyWebViewClient : WebViewClient
        {
            public override bool ShouldOverrideUrlLoading(WebView view, string url)
            {
                view.LoadUrl(url);
                return true;
            }


        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();


            web.GoBack();
            
        }


        public override bool OnKeyDown(Android.Views.Keycode keyCode, Android.Views.KeyEvent e)
        {
            if (keyCode == Keycode.Back && web.CanGoBack())
            {
                web.GoBack();
                return true;
            }

            return base.OnKeyDown(keyCode, e);
        }


    }


}

