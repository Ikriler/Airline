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

        private DataSet.SessionsRow lastSession;

        public LogoutReasonWindow(DataSet.UsersRow user)
        {
            InitializeComponent();
            this.user = user;
            setMessage();
        }

        public void relocate()
        {
            bool checkIsLogout = Session.getLogoutStatus(user);
            if(checkIsLogout)
            {
                Session.startSessionInit(user);
                User.login(user);
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            relocate();
        }
    }
}
