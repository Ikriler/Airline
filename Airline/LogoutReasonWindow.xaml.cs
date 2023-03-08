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
using Airline.Models;

namespace Airline
{
    public partial class LogoutReasonWindow : Window
    {
        private DataSet.UsersRow user;
        private bool isLogout;
        private DataSet.SessionsRow lastSession;

        public LogoutReasonWindow()
        {
            InitializeComponent();
            initUser();
            isLogout = Properties.Settings.Default.IsLogout;
            setMessage();
            relocate();
        }

        public void initUser()
        {
            String login = Properties.Settings.Default.Login; 
            if(login != null && login != "")
            {
                user = User.getUserByLogin(login);
            }
        }

        public void relocate()
        {
            if(user != null && isLogout)
            {
                User.login(user);
                this.Close();
            }
            else if (user == null) {
                Login loginWindow = new Login();
                loginWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                loginWindow.Show();
                this.Close();
            }
        }

        public void setMessage()
        {
            if(user != null)
            {
                lastSession = Session.getLastSession(user);
                message.Content = $"No logut detected for yout last login on {lastSession.date} at {lastSession.login_time}";
            }
            else
            {
                message.Content = "No message";
            }
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            String reason = textError.Text;
            if (reason == null || reason == "")
            {
                MessageBox.Show("Reason must not be empty!");
            }
            else
            {
                Session.updateSession(lastSession.date, lastSession.login_time, lastSession.logout_time, lastSession.spent_time, reason, user.ID, lastSession.id);
                Session.startSessionInit(user);
                User.login(user);
                this.Close();
            }
        }
    }
}
