using EntityLayer;
using PresentationLayer.UserControls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        internal void RefreshData() {
            ucAdministeringEmployees ucAdministeringEmployees = new ucAdministeringEmployees(this);

            controlPanel.Content = ucAdministeringEmployees;
        }

        private void TreeViewItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            List<Group> groups = new List<Group>();
            controlPanel.Content = new UserControls.addPreschoolYear(this, groups);
        }

        private void TreeViewItem_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            controlPanel.Content = new ucPreschoolYearView();
        }

        private void TreeViewItem_MouseLeftButtonUp_2(object sender, MouseButtonEventArgs e)
        {
            var list = new List<Day>();
            controlPanel.Content = new ucWeeklyScheduleEmployee(1, list, this);
        }


        private void TreeViewItem_MouseLeftButtonUp_3(object sender, MouseButtonEventArgs e)
        {
            controlPanel.Content = new ucChildrenTracking(this);
        }

        private void TreeViewItem_MouseLeftButtonUp_4(object sender, MouseButtonEventArgs e)
        {
            var lista = new List<Day>();
            controlPanel.Content = new ucWeeklySchedule(1, lista);
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Login();
            window.Show();
            this.Close();
        }

        private void TreeViewItem_MouseLeftButtonUp_5(object sender, MouseButtonEventArgs e)
        {
            controlPanel.Content = new ucMailForm();
        }

        private void TreeViewItem_MouseLeftButtonUp_6(object sender, MouseButtonEventArgs e)
        {
            ucAdministeringChildren ucAdministeringChildren = new ucAdministeringChildren(this);
            controlPanel.Content = ucAdministeringChildren;
        }

        private void TreeViewItem_MouseLeftButtonUp_7(object sender, MouseButtonEventArgs e)
        {
            ucAdministeringEmployees ucAdministeringEmployees = new ucAdministeringEmployees(this);
            controlPanel.Content = ucAdministeringEmployees;
        }

        private void TreeViewItem_MouseLeftButtonUp_8(object sender, MouseButtonEventArgs e)
        {
            ucSuppliesAdministrating ucSuppliesAdministrating = new ucSuppliesAdministrating(this);
            controlPanel.Content = ucSuppliesAdministrating;
        }

        private void TreeViewItem_MouseLeftButtonUp_9(object sender, MouseButtonEventArgs e)
        {

            ucStatistics ucStatistics = new ucStatistics(this);
            controlPanel.Content = ucStatistics;
        }

        private void TreeViewItem_MouseLeftButtonUp_10(object sender, MouseButtonEventArgs e)
        {
            ucStatisticsGender ucStatisticsGender = new ucStatisticsGender(this);
            controlPanel.Content = ucStatisticsGender;
        }
        
        private void TreeViewItem_MouseLeftButtonUp_11 (object sender, MouseButtonEventArgs e)
        {
            ucStatisticsGroups ucStatisticsGroups = new ucStatisticsGroups(this);
            controlPanel.Content = ucStatisticsGroups;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var ucWelcome = new UcWelcome();
            ucWelcome.FullName = $"{LoggedInUser.User.FirstName} {LoggedInUser.User.LastName}";
            controlPanel.Content = ucWelcome;
            if (LoggedInUser.User.Id_role != 4)
            {
                treeViewItemScheduleaAddNewPreschoolYear.Visibility = Visibility.Collapsed;
                treeViewItemScheduleManager.Visibility = Visibility.Collapsed;
                treeViewNavigationAdministrating.Visibility= Visibility.Collapsed;
                           
               
            }
        }
        
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                
                string pdfFileName = "Korisnicka dokumentacija.pdf";
                string pdfPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pdfFileName);
                Process.Start(pdfPath);

                e.Handled = true;
            }
        }
    }
}
