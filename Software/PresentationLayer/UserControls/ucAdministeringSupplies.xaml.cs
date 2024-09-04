using BusinessLogicLayer;
using EntityLayer;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace PresentationLayer.UserControls
{
    /// <summary>
    /// Interaction logic for ucSuppliesAdministrating.xaml
    /// </summary>
    public partial class ucSuppliesAdministrating : UserControl
    {
        private EquipmentService equipmentService = new EquipmentService();
        private ResourceService resourceService = new ResourceService();
        private MainWindow MainWindow;
        public ucSuppliesAdministrating(MainWindow mainWindow)
        {
            InitializeComponent();
            MainWindow = mainWindow;
        }

        private void tiEquipment_Loaded(object sender, RoutedEventArgs e)
        {
            dgvEquipment.ItemsSource = equipmentService.GetAllEquipment();

            if(tabControl.SelectedIndex != 1)
            {
                setEquipmentDgv();
            }
        }

        private void tiEquipment_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            tabControl.SelectedIndex = 0;
            setEquipmentDgv();
        }

        private void btnEditEquipment_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Equipment selectedEquipment = dgvEquipment.SelectedItem as Equipment;
            if (selectedEquipment != null)
            {
                ucEditEquipment editEquipmentControl = new ucEditEquipment(MainWindow);
                editEquipmentControl.SetEquipmentData(selectedEquipment);
                MainWindow.controlPanel.Content = editEquipmentControl;
            }
            else
            {
                MessageBox.Show("Please select an equipment to edit.");
            }
        }

        private void btnRemoveEquipment_Click(object sender, RoutedEventArgs e)
        {
            Equipment equipment = dgvEquipment.SelectedItem as Equipment;

            if (equipment != null)
            {
                bool isDeleted = equipmentService.RemoveEquipment(equipment);
                if (isDeleted)
                {
                    MessageBox.Show("Equipment is successfully deleted.");

                    setEquipmentDgv();
                    dgvEquipment.ItemsSource = equipmentService.GetAllEquipment();
                }
                else
                {
                    MessageBox.Show("There was an error deleting the equipment.");
                }
            }
            else
            {
                MessageBox.Show("Please select an equipment row to delete.");
            }
        }

        private void btnAddEquipment_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.controlPanel.Content = new ucAddEquipment(MainWindow);
        }

        private async void setEquipmentDgv()
        {
            await Task.Delay(50);

            dgvEquipment.Columns[0].Header = "ID equipment";
            dgvEquipment.Columns[1].Header = "Equipment";

            dgvEquipment.Columns[0].MaxWidth = 100;
            dgvEquipment.Columns[1].MaxWidth = 100;
            dgvEquipment.Columns[2].MaxWidth = 100;
        }

        private void txtSearchEquipment_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filterText = txtSearchEquipment.Text.ToLower();
            ICollectionView cv = CollectionViewSource.GetDefaultView(dgvEquipment.ItemsSource);

            cv.Filter = item =>
            {
                if (item is Equipment equipment)
                {
                    return equipment.Name.ToLower().Contains(filterText) ||
                   equipment.Description.ToLower().Contains(filterText);
                }
                return false;
            };
        }

        // -----------------------------------------------------------------------------------------

        private void tiResources_Loaded(object sender, RoutedEventArgs e)
        {
            dgvResources.ItemsSource = resourceService.GetAllResources();

            if(tabControl.SelectedIndex == 1)
            {
                setResourcesDgv();
            }
        }

        private void tiResources_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            setResourcesDgv();
        }

        private void btnEditResource_Click(object sender, RoutedEventArgs e)
        {
            Resource selectedResource = dgvResources.SelectedItem as Resource;
            if (selectedResource != null)
            {
                ucEditResource editResoruceControl = new ucEditResource(MainWindow);
                editResoruceControl.SetResourceData(selectedResource);
                MainWindow.controlPanel.Content = editResoruceControl;
            }
            else
            {
                MessageBox.Show("Please select a resource to edit.");
            }
        }

        private void btnRemoveResource_Click(object sender, RoutedEventArgs e)
        {
            Resource resource = dgvResources.SelectedItem as Resource;

            if (resource != null)
            {
                bool isDeleted = resourceService.RemoveResource(resource);
                if (isDeleted)
                {
                    MessageBox.Show("Resource is successfully deleted.");
                    dgvResources.ItemsSource = resourceService.GetAllResources();

                    setResourcesDgv();
                    dgvResources.Columns[4].Visibility = Visibility.Collapsed;
                }
                else
                {
                    MessageBox.Show("There was an error deleting the resource.");
                }
            }
            else
            {
                MessageBox.Show("Please select an resource row to delete.");
            }
        }

        private void btnAddResource_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.controlPanel.Content = new ucAddResource(MainWindow);
        }

        private async void setResourcesDgv()
        {
            await Task.Delay(50);

            dgvResources.Columns[0].Header = "ID resource";
            dgvResources.Columns[1].Header = "Resource";
            dgvResources.Columns[2].Header = "Amount";
            dgvResources.Columns[3].Header = "Description";

            dgvResources.Columns[0].MaxWidth = 100;
            dgvResources.Columns[1].MaxWidth = 100;
            dgvResources.Columns[2].MaxWidth = 100;

            dgvResources.Columns[4].Visibility = Visibility.Collapsed;
        }

        private void txtSearchResources_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filterText = txtSearchResources.Text.ToLower();
            ICollectionView cv = CollectionViewSource.GetDefaultView(dgvResources.ItemsSource);

            cv.Filter = item =>
            {
                if (item is Resource resource)
                {
                    return resource.Name.ToLower().Contains(filterText) ||
                           resource.Description.ToLower().Contains(filterText);
                }
                return false;
            };
        }

        private void btnClearEquipmentSearch_Click(object sender, RoutedEventArgs e)
        {
            txtSearchEquipment.Text = string.Empty;
        }

        private void btnClearResourcesSearch_Click(object sender, RoutedEventArgs e)
        {
            txtSearchResources.Text = string.Empty;
        }
    }
}
