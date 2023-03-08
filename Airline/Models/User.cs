using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Airline.DataSetTableAdapters;

namespace Airline.Models
{
    internal class User
    {
        public static DataSet.UsersRow getUserByLogin(String login)
        {
            DataSet.UsersDataTable users = initUsersDataTable();

            DataSet.UsersRow user = users.Where(dataBaseUser => dataBaseUser.Email.Equals(login)).FirstOrDefault();

            return user;
        }

        public static DataSet.UsersDataTable initUsersDataTable()
        {
            UsersTableAdapter tableAdapterForUsers = new UsersTableAdapter();
            DataSet.UsersDataTable users = new DataSet.UsersDataTable();

            tableAdapterForUsers.Fill(users);

            return users;
        }

        public static void login(DataSet.UsersRow user)
        {
            switch (user.RoleID)
            {
                case 1:
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    adminWindow.Show();
                    break;
                case 2:
                    UserWindow userWindow = new UserWindow(user);
                    userWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    userWindow.Show();
                    break;
                default:
                    return;
            }
            Properties.Settings.Default.IsLogout = false;
            Properties.Settings.Default.Login = user.Email;
            Properties.Settings.Default.Save();
        }

    }
}
