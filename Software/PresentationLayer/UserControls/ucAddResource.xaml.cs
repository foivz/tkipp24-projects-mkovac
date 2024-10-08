﻿using BusinessLogicLayer;
using EntityLayer;
using System;
using System.Windows;
using System.Windows.Controls;

namespace PresentationLayer.UserControls
{
    /// <summary>
    /// Interaction logic for ucAddResource.xaml
    /// </summary>
    public partial class ucAddResource : UserControl
    {
        private ResourceService service = new ResourceService();
        private MainWindow MainWindow;
        public ucAddResource(MainWindow mainWindow)
        {
            InitializeComponent();
            MainWindow = mainWindow;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var uc = new ucSuppliesAdministrating(MainWindow);
                uc.tabControl.SelectedIndex = 1;

                var resource = new Resource
                {
                    Name = txtName.Text,
                    Amount = int.Parse(txtAmount.Text),
                    Description = txtDescription.Text
                };

                service.AddResource(resource);

                MainWindow.controlPanel.Content = uc;
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

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            var uc = new ucSuppliesAdministrating(MainWindow);
            uc.tabControl.SelectedIndex = 1;
            MainWindow.controlPanel.Content = uc;
        }
    }
}
