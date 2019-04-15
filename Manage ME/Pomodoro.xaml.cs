using NotificationsExtensions.Toasts;
using NotificationsExtensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.Background;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Manage_ME
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Pomodoro : Page
    {
        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        private DispatcherTimer pomodoro_timer;
        private DispatcherTimer shortbreak_timer;
        private DispatcherTimer longbreak_timer;
        private DispatcherTimer display_timer;
        private int counter = 0;
        private int session_duration, shortbreak, longbreak, no_ofsessions, display_min, display_sec;

        #region notifications
        
        ToastVisual visual = new ToastVisual()
        {
            TitleText = new ToastText()
            {
                Text = "Well Done!"
            },

            BodyTextLine1 = new ToastText()
            {
                Text = "It's time for a break."
            }
        };

        ToastVisual visual2 = new ToastVisual()
        {
            TitleText = new ToastText()
            {
                Text = "Concentrate!"
            },

            BodyTextLine1 = new ToastText()
            {
                Text = "It's time to work."
            }
        };

        ToastNotification toast1;
        ToastNotification toast2;

        #endregion

        public Pomodoro()
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            ToastContent toastContent2 = new ToastContent()
            {
                Visual = visual2
            };

            toast2 = new ToastNotification(toastContent2.GetXml());
            toast2 = new ToastNotification(toastContent2.GetXml());
            toast2.ExpirationTime = DateTime.Now.AddMinutes(1);
         
            TaskName.IsEnabled = false;
            TaskName.IsEnabled = true;
            
            pomodoro_timer = new DispatcherTimer();
            shortbreak_timer = new DispatcherTimer();
            longbreak_timer = new DispatcherTimer();
            display_timer = new DispatcherTimer();

            session_duration = Convert.ToInt32(localSettings.Values["session_duration"]);
            shortbreak = Convert.ToInt32(localSettings.Values["short_break"]);
            longbreak = Convert.ToInt32(localSettings.Values["long_break"]);
            no_ofsessions = Convert.ToInt32(localSettings.Values["no_ofsessions"]);

            Minutes.Text = session_duration.ToString();
            Seconds.Text = "00";

            pomodoro_timer.Interval = new TimeSpan(0, session_duration, 0);
            shortbreak_timer.Interval = new TimeSpan(0, shortbreak, 0);
            longbreak_timer.Interval = new TimeSpan(0, longbreak, 0);
            display_timer.Interval = new TimeSpan(0, 0, 1);

            display_timer.Tick += display_timer_Tick;
            pomodoro_timer.Tick += pomodoro_timer_Tick;
            shortbreak_timer.Tick += shortbreak_timer_Tick;
            longbreak_timer.Tick += longbreak_timer_Tick;

            startPomodoroTimer();
        }

        #region Button functions
        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            if (display_timer.IsEnabled)
                display_timer.Stop();

            if (pomodoro_timer.IsEnabled)
                pomodoro_timer.Stop();

            else if (shortbreak_timer.IsEnabled)
                shortbreak_timer.Stop();

            else
                longbreak_timer.Stop();

            this.Frame.Navigate(typeof(MainPage));
        }

        private void skip_button_Click(object sender, RoutedEventArgs e)
        {
            display_timer.Stop();

            if (pomodoro_timer.IsEnabled)
            {
                pomodoro_timer.Stop();
                break_call();
            }
            else if (shortbreak_timer.IsEnabled)
            {
                shortbreak_timer.Stop();
                timerToast();
                startPomodoroTimer();
            }
            else
            {
                longbreak_timer.Stop();
                timerToast();
                startPomodoroTimer();
            }
        }

        #endregion

        #region start timer
        private void startPomodoroTimer()
        {
            TaskName.IsEnabled = true;
            counter++;
            display_sec = 60;
            display_min = session_duration - 1;
            pomodoro_timer.Start();
            display_timer.Start();  
        }

        private void startShortBreakTimer()
        {
            TaskName.IsEnabled = false;
            display_sec = 60;
            display_min = shortbreak - 1;
            shortbreak_timer.Start();
            display_timer.Start();
        }

        private void startLongBreakTimer()
        {
            TaskName.IsEnabled = false;
            display_sec = 60;
            display_min = longbreak - 1;
            longbreak_timer.Start();
            display_timer.Start();
        }

        #endregion

        private void TaskName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TaskName.Text == "Enter Task")
                TaskName.Text = "";
        }

        private void TaskName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TaskName.Text == "")
                TaskName.Text = "Enter Task";
        }

        #region timer tick
        private void pomodoro_timer_Tick(object sender, object e)
        {
            display_timer.Stop();
            break_call();  
        }

        private void display_timer_Tick(object sender, object e)
        {
            if (display_sec == 0)
            {
                display_sec = 60;
                display_min--;
            }

            display_sec--;

            Minutes.Text = display_min.ToString("D2");
            Seconds.Text = display_sec.ToString("D2");
        }

        private void shortbreak_timer_Tick(object sender, object e)
        {
            display_timer.Stop();
            timerToast();
            startPomodoroTimer();
        }

        private void longbreak_timer_Tick(object sender, object e)
        {
            display_timer.Stop();
            timerToast();
            startPomodoroTimer();
        }

        #endregion
        private void break_call()
        {
            ToastNotificationManager.History.Clear();

            ToastContent toastContent1 = new ToastContent()
            {
                Visual = visual
            };        
            toast1 = new ToastNotification(toastContent1.GetXml());
            toast1.ExpirationTime = DateTime.Now.AddMinutes(1);
            ToastNotificationManager.CreateToastNotifier().Show(toast1);

            if (counter % no_ofsessions == 0)
                startLongBreakTimer();

            else
                startShortBreakTimer();
        }

        private void timerToast()
        {
            ToastNotificationManager.History.Clear();

            ToastContent toastContent2 = new ToastContent()
            {
                Visual = visual2
            };
            toast2 = new ToastNotification(toastContent2.GetXml());
            toast2.ExpirationTime = DateTime.Now.AddMinutes(1);
            ToastNotificationManager.CreateToastNotifier().Show(toast2);
        }
    }
}
