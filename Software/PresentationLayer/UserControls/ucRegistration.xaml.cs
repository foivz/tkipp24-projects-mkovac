using BusinessLogicLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PresentationLayer.UserControls {
    /// <summary>
    /// Interaction logic for ucRegistration.xaml
    /// </summary>
    public partial class ucRegistration : UserControl {
        private MainWindow MainWindow;
        private RoleService roleService = new RoleService();
        private UserService service = new UserService();
        public ucRegistration(MainWindow mainWindow) {
            InitializeComponent();
            MainWindow=mainWindow;
            LoadRoles();
        }
        private void LoadRoles() {
            var roles = roleService.GetRoles();
            cmbRole.ItemsSource = roles;
            cmbRole.DisplayMemberPath = "Name";
            cmbRole.SelectedValuePath = "Id";
        }

        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e) {
            Regex regex = new Regex("[^0-9+]+");
            e.Handled = regex.IsMatch(e.Text) && txtTelephone.Text.Length == 0 && e.Text != "+";
        }

        public bool ValidatePhone(string phone) {
            if (!Regex.IsMatch(phone, @"^\+?\d{0,14}$")) {
                MessageBox.Show("Invalid phone number format. Only digits and a leading + are allowed.");
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e) {
            if (txtOIB.Text.Length != 11) {
                MessageBox.Show("OIB must be exactly 11 digits long.");
                return;
            }
            if (cmbSex.SelectedItem == null) {
                MessageBox.Show("Please select a sex.");
                return;
            }

            if (!ValidatePhone(txtTelephone.Text)) {
                return;
            }
            int roleId = (int)cmbRole.SelectedValue;
            Role selectedRole = roleService.GetRoleById(roleId);
            if (selectedRole == null) {
                MessageBox.Show("Selected role does not exist.");
                return;
            }
            var user = new User {
                OIB=txtOIB.Text,
                Username = txtUsername.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Password = txtPassword.Text,
                Email = txtEmail.Text,
                DateOfBirth = DateofBirth.SelectedDate,
                Sex = (cmbSex.SelectedItem as ComboBoxItem)?.Content.ToString(),
                Telephone = txtTelephone.Text,
                Role = selectedRole
            };
            service.AddUser(user);
            MainWindow.controlPanel.Content= new ucAdministeringEmployees(MainWindow);
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            MainWindow.controlPanel.Content= new ucAdministeringEmployees(MainWindow);
        }
    }
}
