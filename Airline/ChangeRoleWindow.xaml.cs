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
    public partial class ChangeRoleWindow : Window
    {
        private AdminWindow adminWindow;
        private DataSet.UsersRow user;
        public ChangeRoleWindow(AdminWindow adminWindow, DataSet.UsersRow user)
        {
            InitializeComponent();

            this.adminWindow = adminWindow;
            this.user = user;

            adminWindow.IsEnabled = false;

            initOfficesComboBox();
            initFields();
        }

        private void initOfficesComboBox()
        {
            offices_combobox.ItemsSource = Office.getClearOfficesForCombo();
        }

        private void initFields()
        {
            email_textbox.Text = user.Email;
            firstName_textbox.Text = user.FirstName;
            lastName_textbox.Text = user.LastName;

            offices_combobox.SelectedIndex = Office.getClearOfficesForCombo().IndexOf(Office.getOfficeById(user.OfficeID).Title);

            if (user.RoleID == 1)
            {
                role_administrator_radio.IsChecked = true;
            }
            else
            {
                role_user_radio.IsChecked = true;
            }
        }

        private void updateUser(string email, string firstName, string lastName, int office_id, int role_id, int original_id)
        {
            if (User.checkEmailExists(email, original_id))
            {
                MessageBox.Show("Email exists!");
                return;
            }

            if (email == "" || firstName == "" || lastName == "")
            {

                MessageBox.Show("Fields must not be empty!");
                return;
            }

            User.updateUser(role_id, email, firstName, lastName, office_id, original_id);
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            adminWindow.IsEnabled = true;
        }

        private void apply_button_Click(object sender, RoutedEventArgs e)
        {
            string email = email_textbox.Text;
            string firstName = firstName_textbox.Text;
            string lastName = lastName_textbox.Text;

            int office_id = Office.getOfficeByName(offices_combobox.SelectedItem as string).ID;

            int role_id = role_administrator_radio.IsChecked == true ? 1 : 2;

            updateUser(email, firstName, lastName, office_id, role_id, user.ID);
        }

        private void cancel_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
