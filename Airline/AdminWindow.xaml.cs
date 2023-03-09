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
    public partial class AdminWindow : Window
    {
        private DataSet.UsersRow user;

        private Window modalWindow;

        public AdminWindow(DataSet.UsersRow user)
        {
            InitializeComponent();
            this.user = user;
            initOfficesCombo();
            initUsersDataGrid();
        }

        private void initOfficesCombo()
        {
            officesCombo.ItemsSource = Office.getOfficesForCombo();
        }

        private void initUsersDataGrid(string office = "")
        {
            List<User> users =  new List<User>();
            if (office == "" || office == "All offices")
            {
                users = User.convertUsersRowToUserList(User.initUsersDataTable().ToList());
            }
            else
            {
                users = User.convertUsersRowToUserList(User.initUsersDataTable().ToList()).Where(u => u.office.Equals(office)).ToList();
            }
            dataGrid.ItemsSource = users;
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
            if (modalWindow != null) modalWindow.Close();
        }

        private void closeEvent()
        {
            DataSet.SessionsRow lastSession = Session.getLastSession(user);
            DateTime date = DateTime.Now;
            TimeSpan logout_time = new TimeSpan(hours: date.Hour, minutes: date.Minute, seconds: date.Second);
            TimeSpan login_time = TimeSpan.Parse(lastSession.login_time);
            String spent_time = logout_time.Subtract(login_time).ToString();
            Session.updateSession(lastSession.date, lastSession.login_time, logout_time.ToString(), spent_time, lastSession.reason, user.ID, lastSession.id);
        }

        private void add_user_menu_item_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUserWindow = new AddUserWindow(this);
            addUserWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            modalWindow = addUserWindow;
            addUserWindow.Show();
        }

        private void change_role_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                User selectedUser = dataGrid.SelectedItem as User;

                ChangeRoleWindow changeRoleWindow = new ChangeRoleWindow(this, User.getUserById(selectedUser.id));
                changeRoleWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                modalWindow = changeRoleWindow;
                changeRoleWindow.Show();
            }
            else
            {
                MessageBox.Show("Please select user");
            }
        }

        private void officesCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateDataGrid();
        }

        private void updateDataGrid()
        {
            if (officesCombo.SelectedItem != null)
            {
                initUsersDataGrid(officesCombo.SelectedItem as string);
            }
        }

        private void change_login_status_Click(object sender, RoutedEventArgs e)
        {
            if(dataGrid.SelectedItem != null)
            {
                User selectedUser = dataGrid.SelectedItem as User;

                User.changeUserActiveStatus(!selectedUser.active, selectedUser.id);

                updateDataGrid();
            }
            else
            {
                MessageBox.Show("Please select user");
            }
        }

        private void Window_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            updateDataGrid();
        }
    }
}
