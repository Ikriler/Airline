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
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            username_textbox.Text = "admi@mail.ru";
            password_textbox.Text = "1";
        }

        private void login_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UsersTableAdapter usersTableAdapter = new UsersTableAdapter();
                DataSet.UsersDataTable userDataRows = new DataSet.UsersDataTable();


                usersTableAdapter.Fill(userDataRows);

                String userName = username_textbox.Text;
                String password = password_textbox.Text;

                DataSet.UsersRow user = userDataRows.Where(u => u.Email.Equals(userName) && u.Password.Equals(password) && u.Active.Equals(true)).FirstOrDefault();

                if (user != null && user.Active)
                {

                    LogoutReasonWindow logoutReasonWindow = new LogoutReasonWindow(user);
                    logoutReasonWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    logoutReasonWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неправильные данные или аккаунт не активен");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exit_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
