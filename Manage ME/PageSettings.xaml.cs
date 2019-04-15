using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Manage_ME
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageSettings : Page
    {
        Windows.Storage.ApplicationDataContainer localSettings = null;
       
        public PageSettings()
        {
            this.InitializeComponent();

            localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            
            ws.Value = Convert.ToDouble(localSettings.Values["session_duration"]);
            shortbreak.Value= Convert.ToDouble(localSettings.Values["short_break"]);
            longbreak.Value = Convert.ToDouble(localSettings.Values["long_break"]);
            noofws.Value = Convert.ToDouble(localSettings.Values["no_ofsessions"]);
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            
            if (rootFrame.CanGoBack)
            {
                // Show UI in title bar if opted-in and in-app backstack is not empty.
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Visible;
            }
            else
            {
                // Remove the UI from the title bar if in-app back stack is empty.
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Collapsed;
            }

            ws.Value = Convert.ToDouble(localSettings.Values["session_duration"]);
            shortbreak.Value = Convert.ToDouble(localSettings.Values["short_break"]);
            longbreak.Value = Convert.ToDouble(localSettings.Values["long_break"]);
            noofws.Value = Convert.ToDouble(localSettings.Values["no_ofsessions"]);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            localSettings.Values["session_duration"] = ws.Value;
            localSettings.Values["short_break"] = shortbreak.Value;
            localSettings.Values["long_break"] = longbreak.Value;
            localSettings.Values["no_ofsessions"] = noofws.Value;
            
            base.OnNavigatedFrom(e);
        }
       
        private void _default_Click(object sender, RoutedEventArgs e)
        {
            ws.Value = 25;
            shortbreak.Value = 5;
            longbreak.Value = 10;
            noofws.Value = 4;
        }
    }
}
