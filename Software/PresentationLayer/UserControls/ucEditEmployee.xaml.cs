using BusinessLogicLayer;
using EntityLayer;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PresentationLayer.UserControls {
    /// <summary>
    /// Interaction logic for ucEditEmployee.xaml
    /// </summary>
    public partial class ucEditEmployee : UserControl {
        private MainWindow MainWindow;
        private User currentuser;
        private RoleService roleService = new RoleService();
        public ucEditEmployee(MainWindow mainWindow) {
            InitializeComponent();
            MainWindow=mainWindow;
            LoadRoles();
            EnableAllFields(true);
            LoadSexOptions();
        }
        private void LoadRoles() {
            var roles = roleService.GetRoles();
            cmbRole.ItemsSource = roles;
            cmbRole.DisplayMemberPath = "Name";
            cmbRole.SelectedValuePath = "Id";
        }

        private void LoadSexOptions() {
            var sexOptions = new List<string> { "M", "Ž" };
            cmbSex.ItemsSource = sexOptions;
        }

        public void SetEmployeeData(User user) {
            currentuser = user;
            txtOIB.Text = user.OIB;
            txtUsername.Text = user.Username;
            txtFirstName.Text = user.FirstName;
            txtLastName.Text = user.LastName;
            txtEmail.Text = user.Email;
            txtPassword.Text = user.Password;
            txtTelephone.Text = user.Telephone;
            DateofBirth.SelectedDate = user.DateOfBirth;
            cmbSex.SelectedItem = user.Sex;
            cmbRole.SelectedValue = user.Id_role;
        }
        private void EnableAllFields(bool isEnabled) {
            txtOIB.IsEnabled=isEnabled;
            txtUsername.IsEnabled = isEnabled;
            txtFirstName.IsEnabled = isEnabled;
            txtLastName.IsEnabled = isEnabled;
            txtEmail.IsEnabled = isEnabled;
            txtPassword.IsEnabled = isEnabled;
            txtTelephone.IsEnabled = isEnabled;
            DateofBirth.IsEnabled = isEnabled;
            cmbSex.IsEnabled = isEnabled;
            cmbRole.IsEnabled = isEnabled;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e) {
            if (txtOIB.Text.Length != 11) {
                MessageBox.Show("OIB must be exactly 11 digits long.");
                return;
            }
                currentuser.OIB=txtOIB.Text;
                currentuser.FirstName = txtFirstName.Text;
                currentuser.LastName = txtLastName.Text;
                currentuser.Username = txtUsername.Text;
                currentuser.Email = txtEmail.Text;
                currentuser.Password = txtPassword.Text;
                currentuser.Telephone = txtTelephone.Text;
                currentuser.DateOfBirth = DateofBirth.SelectedDate;
                if (cmbSex.SelectedItem != null)
                currentuser.Sex = cmbSex.SelectedItem.ToString();
                if (cmbRole.SelectedItem != null && cmbRole.SelectedValue != null)
                currentuser.Id_role = Convert.ToInt32(cmbRole.SelectedValue);

                 UserService userService = new UserService();
                userService.UpdateUser(currentuser);
                MainWindow.controlPanel.Content = new ucAdministeringEmployees(MainWindow);
            } 
        
        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            MainWindow.controlPanel.Content= new ucAdministeringEmployees(MainWindow);
        }
    }
}
