using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Airline.DataSetTableAdapters;
using Airline.Models;

namespace Airline
{
    public partial class UserWindow : Window
    {
        private DataSet.UsersRow user;
        public UserWindow(DataSet.UsersRow user)
        {
            InitializeComponent();
            this.user = user;
            dataGrid.ItemsSource = Session.getSessionsForUser(user);
            initHelloMessage();
            initSpentTimeMessage();
            initNumberCrashesMessage();
        }

        private void initHelloMessage()
        {
            String message = "Hi " + user.FirstName + ", Welcome to AMONIC Airlines.";
            hello_label.Content = message;
        }

        private void initSpentTimeMessage()
        {
            String message = "Time spent on system: " + Session.getAmountSpentTime(user);
            spent_time_label.Content = message;
        }

        private void initNumberCrashesMessage()
        {
            String message = "Number of crashes: " + Session.getCountCrashes(user);
            crashes_label.Content = message;
        }

        private void exit_menu_item_Click(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            loginWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            loginWindow.Show();
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            closeEvent();
        }

        private void closeEvent()
        {
            DataSet.SessionsRow lastSession = Session.getLastSession(user);
            DateTime date = DateTime.Now;
            TimeSpan logout_time = new TimeSpan(hours: date.Hour, minutes: date.Minute, seconds: date.Second);
            TimeSpan login_time = TimeSpan.Parse(lastSession.login_time);
            String spent_time = logout_time.Subtract(login_time).ToString();
            Session.updateSession(lastSession.date, lastSession.login_time, logout_time.ToString(), spent_time, lastSession.reason, user.ID, lastSession.id);
            Properties.Settings.Default.IsLogout = true;
            Properties.Settings.Default.Login = "";
            Properties.Settings.Default.Save();
        }
    }
}
