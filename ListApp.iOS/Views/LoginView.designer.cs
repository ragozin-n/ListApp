// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ListApp.iOS
{
    [Register ("LoginView")]
    partial class LoginView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIWebView LoginWebView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (LoginWebView != null) {
                LoginWebView.Dispose ();
                LoginWebView = null;
            }
        }
    }
}