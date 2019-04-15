using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Manage_ME
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private DispatcherTimer _timer;

        public MainPage()
        {
            this.InitializeComponent(); 
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
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            PSV1.IsPaneOpen = !PSV1.IsPaneOpen;
        }
        
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshUI(this, null);
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(0.5);
            _timer.Tick += RefreshUI;
            _timer.Start();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            if (_timer != null)
            {
                _timer.Stop();
            }
        }
        public void RefreshUI(object sender, object e)
        {
            DateTime dt = DateTime.Now;
            Date.Text = dt.ToString("M");
            day.Text = dt.DayOfWeek.ToString();
            int seconds = dt.Second;
            int minutes = dt.Minute;
            int hour = dt.Hour;

            // Time 
            if (Hours.Text != dt.Hour.ToString("D2"))
            {
                Hours.Text = dt.Hour.ToString("D2");
            }

            if (Minutes.Text != dt.Minute.ToString("D2"))
            {
                Minutes.Text = dt.Minute.ToString("D2");
            }

            if (Seconds.Text != dt.Second.ToString("D2"))
            {
                Seconds.Text = dt.Second.ToString("D2");
            }
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Pomodoro));
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PageSettings));
        }
    }
}
