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
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number for Amount.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}\n\n{ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
