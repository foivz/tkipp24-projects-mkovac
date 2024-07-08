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
    /// Interaction logic for ucEditChildren.xaml
    /// </summary>
    public partial class ucEditChildren : UserControl {
        private ChildService childService= new ChildService();
        private GroupService groupService = new GroupService();
        private MainWindow MainWindow;
        private Child currentChild;
        public ucEditChildren(MainWindow mainWindow) {
            InitializeComponent();
            MainWindow=mainWindow;
            LoadGroupNames();
            LoadSexOptions();
        }
        private void LoadGroupNames() {
            cmbGrupa.ItemsSource = groupService.GetAllGroups();
            cmbGrupa.DisplayMemberPath = "Name";
            cmbGrupa.SelectedValuePath = "Id";
        }
        private void LoadSexOptions() {
            var sexOptions = new List<string> { "M", "Ž" };
            cmbSex.ItemsSource = sexOptions;
        }
        public void SetChildData(Child child) {
            currentChild = child;
            txtOIB.Text = child.OIB.ToString();
            txtFirstName.Text = child.FirstName;
            txtLastName.Text = child.LastName;
            txtDateofBirth.SelectedDate = child.DateOfBirth;
            cmbSex.SelectedItem = child.Sex; ;
            txtAdress.Text = child.Adress;
            txtNationality.Text = child.Nationality;
            txtDevelopmentStatus.Text = child.DevelopmentStatus;
            txtMedicalInformation.Text = child.MedicalInformation;
            txtBirthPlace.Text = child.BirthPlace;
            cmbGrupa.SelectedValue = child.Id_Group;
            cmbSex.SelectedItem = child.Sex;

        }
        private void btnSave_Click(object sender, RoutedEventArgs e) {
          
            try {
                currentChild.OIB = int.Parse(txtOIB.Text);  
                currentChild.FirstName = txtFirstName.Text;
                currentChild.LastName = txtLastName.Text;
                currentChild.DateOfBirth = txtDateofBirth.SelectedDate.Value;
                if (cmbSex.SelectedItem != null)
                    currentChild.Sex = cmbSex.SelectedItem.ToString();
                currentChild.Adress = txtAdress.Text;
                currentChild.Nationality = txtNationality.Text;
                currentChild.DevelopmentStatus = txtDevelopmentStatus.Text;
                currentChild.MedicalInformation = txtMedicalInformation.Text;
                currentChild.BirthPlace = txtBirthPlace.Text;
                if (cmbGrupa.SelectedItem != null && cmbGrupa.SelectedValue != null)
                    currentChild.Id_Group = Convert.ToInt32(cmbGrupa.SelectedValue);

                var selectedGroup = cmbGrupa.SelectedItem as Group;
                if (selectedGroup == null || string.IsNullOrEmpty(selectedGroup.Name)) {
                    MessageBox.Show("Please select a group.");
                    return;
                }
                var selectedGroupName = selectedGroup.Name;

                childService.UpdateChild(currentChild, selectedGroupName);

                MainWindow.controlPanel.Content = new ucAdministeringChildren(MainWindow);
            } catch (Exception ex) {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            MainWindow.controlPanel.Content = new ucAdministeringChildren(MainWindow);

        }
    }
}
 
