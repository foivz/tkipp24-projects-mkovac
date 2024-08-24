using BusinessLogicLayer;
using EntityLayer;
using System;
using System.Windows;
using System.Windows.Controls;

namespace PresentationLayer.UserControls
{
    /// <summary>
    /// Interaction logic for ucAddEquipment.xaml
    /// </summary>
    public partial class ucAddEquipment : UserControl
    {
        private EquipmentService service = new EquipmentService();
        private MainWindow MainWindow;
        public ucAddEquipment(MainWindow mainWindow)
        {
            InitializeComponent();
            MainWindow = mainWindow;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(txtName.Text == "" || txtAmount.Text == "")
            {
                MessageBox.Show("Sva polja osim polja Description moraju imati unesenu vrijednost");
                return;
            }
            try
            {
                var equipment = new Equipment
                {
                    Name = txtName.Text,
                    Amount = int.Parse(txtAmount.Text),
                    Description = txtDescription.Text
                };

                service.AddEquipment(equipment);
                MainWindow.controlPanel.Content = new ucSuppliesAdministrating(MainWindow);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}\n\n{ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.controlPanel.Content = new ucSuppliesAdministrating(MainWindow);
        }
    }
}
