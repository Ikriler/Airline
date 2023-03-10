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
        public int id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public int age { get; set; }

        public string email { get; set; }

        public string role { get; set; }

        public string office { get; set; }

        public bool active { get; set; }

        public User(int id, string firstName, string lastName, int age, string email, string role, string office, bool active)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.email = email;
            this.role = role;
            this.office = office;
            this.active = active;
        }

        public static List<User> convertUsersRowToUserList(List<DataSet.UsersRow> usersRows)
        {
            List<User> users = new List<User>();

            foreach(DataSet.UsersRow usersRow in usersRows)
            {
                int age = getAgeByUser(usersRow);
                string role = Role.getRoleByUser(usersRow).Title;
                string office = Office.getOfficeByUser(usersRow).Title;
                User user = new User(usersRow.ID, usersRow.FirstName, usersRow.LastName, age, usersRow.Email, role, office, usersRow.Active);
                users.Add(user);
            }

            return users;
        }

        public static int getAgeByUser(DataSet.UsersRow user)
        {
            DateTime nowDate = DateTime.Now;

            int age = (int)Math.Ceiling(nowDate.Subtract(user.Birthdate).TotalDays / 365);

            return age;
        }

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
                    AdminWindow adminWindow = new AdminWindow(user);
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
        }

        public static DataSet.UsersRow getUserById(int id)
        {
            return initUsersDataTable().Where(u => u.ID.Equals(id)).First();
        }

        public static void changeUserActiveStatus(bool isActive, int user_id)
        {
            UsersTableAdapter tableAdapterForUsers = new UsersTableAdapter();

            tableAdapterForUsers.UpdateActive(isActive, user_id);
        }

        public static void insertUser(int role_id, string email, string password, string firstName, string lastName, int office_id, DateTime birthdate, bool active = true)
        {
            UsersTableAdapter tableAdapterForUsers = new UsersTableAdapter();

            tableAdapterForUsers.InsertUser(role_id, email, password, firstName, lastName, office_id, birthdate, active);
        }

        public static void updateUser(int role_id, string email, string firstName, string lastName, int office_id, int original_id)
        {
            UsersTableAdapter tableAdapterForUsers = new UsersTableAdapter();

            tableAdapterForUsers.UpdateUser(role_id, email, firstName, lastName, office_id, original_id);
        }

        public static bool checkEmailExists(string email, int user_id = 0)
        {
            DataSet.UsersRow dbUser = initUsersDataTable().Where(u => u.Email.Equals(email) && !u.ID.Equals(user_id)).FirstOrDefault();

            if(dbUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}