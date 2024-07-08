using BusinessLogicLayer;
using EntityLayer;
using System.Windows;
using System;
using System.Windows.Controls;

namespace PresentationLayer.UserControls
{
    /// <summary>
    /// Interaction logic for ucEditResource.xaml
    /// </summary>
    public partial class ucEditResource : UserControl
    {
        private ResourceService service = new ResourceService();
        private MainWindow MainWindow;
        private Resource currentResource;
        public ucEditResource(MainWindow mainWindow)
        {
            InitializeComponent();
            MainWindow = mainWindow;
        }

        private void btnSave_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                var uc = new ucSuppliesAdministrating(MainWindow);
                uc.tabControl.SelectedIndex = 1;

                currentResource.Name = txtName.Text;
                currentResource.Amount = int.Parse(txtAmount.Text);
                currentResource.Description = txtDescription.Text;

                service.UpdateResource(currentResource);
                
                MainWindow.controlPanel.Content = uc;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var uc = new ucSuppliesAdministrating(MainWindow);
            uc.tabControl.SelectedIndex = 1;
            MainWindow.controlPanel.Content = uc;
        }

        public void SetResourceData(Resource resource)
        {
            currentResource = resource;
            txtName.Text = currentResource.Name;
            txtAmount.Text = currentResource.Amount.ToString();
            txtDescription.Text = currentResource.Description;
        }
    }
}
