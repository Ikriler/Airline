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
    public partial class AddUserWindow : Window
    {
        private AdminWindow adminWindow;

        public AddUserWindow(AdminWindow adminWindow)
        {
            InitializeComponent();

            this.adminWindow = adminWindow;
            adminWindow.IsEnabled = false;

            initOfficesComboBox();
        }

        private void initOfficesComboBox()
        {
            offices_combobox.ItemsSource = Office.getClearOfficesForCombo();
        }

        private void insertUser(string email, string firstName, string password, string lastName, int office_id, int role_id, string birthdate)
        {
            if (User.checkEmailExists(email))
            {
                MessageBox.Show("Email exists!");
                return;
            }

            if (email == "" || firstName == "" || lastName == "" || password == "")
            {

                MessageBox.Show("Fields must not be empty!");
                return;
            }

            if(birthdate == "")
            {
                MessageBox.Show("Birthdate must not be empty!");
                return;

            }

            DateTime birthdate_dateTime = new DateTime();

            try
            {
                birthdate_dateTime = DateTime.Parse(birthdate);
            }
            catch
            {
                MessageBox.Show("Error in birthdate!");
                return;
            }

            if(birthdate_dateTime > DateTime.Now)
            {
                MessageBox.Show("Birthdate must not be future!");
                return;
            }

            User.insertUser(role_id, email, password, firstName, lastName, office_id, birthdate_dateTime);
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            adminWindow.IsEnabled = true;
        }

        private void cancel_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void save_button_Click(object sender, RoutedEventArgs e)
        {
            string email = email_textbox.Text;
            string firstName = firstName_textbox.Text;
            string lastName = lastName_textbox.Text;
            string password = password_textbox.Text;
            string birthdate = birthdate_datepicker.Text;

            int office_id = Office.getOfficeByName(offices_combobox.SelectedItem as string).ID;

            int role_id = 2;

            insertUser(email, firstName, password, lastName, office_id, role_id, birthdate);
        }
    }
}
