using BusinessLogicLayer;
using EntityLayer;
using System;
using System.Windows;
using System.Windows.Controls;

namespace PresentationLayer.UserControls
{
    /// <summary>
    /// Interaction logic for ucEditEquipment.xaml
    /// </summary>
    public partial class ucEditEquipment : UserControl
    {
        private EquipmentService service = new EquipmentService();
        private MainWindow MainWindow;
        private Equipment currentEquipment;

        public ucEditEquipment(MainWindow mainWindow)
        {
            InitializeComponent();
            MainWindow = mainWindow;
        }

        private void btnSave_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                currentEquipment.Name = txtName.Text;
                currentEquipment.Amount = int.Parse(txtAmount.Text);
                currentEquipment.Description = txtDescription.Text;

                service.UpdateEquipment(currentEquipment);

                MainWindow.controlPanel.Content = new ucSuppliesAdministrating(MainWindow);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.controlPanel.Content = new ucSuppliesAdministrating(MainWindow);
        }

        public void SetEquipmentData(Equipment equipment)
        {
            currentEquipment = equipment;
            txtName.Text = currentEquipment.Name;
            txtAmount.Text = currentEquipment.Amount.ToString();
            txtDescription.Text = currentEquipment.Description;
        }
    }
}
