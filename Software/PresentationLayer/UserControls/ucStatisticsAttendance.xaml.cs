using BusinessLogicLayer;
using System;
using System.Windows.Controls;
using LiveCharts.Wpf;
using LiveCharts;
using System.Threading.Tasks;
using System.Linq;
using ModelsLayer.Models;
using System.Collections.Generic;
using static SkiaSharp.HarfBuzz.SKShaper;

namespace PresentationLayer.UserControls
{
    /// <summary>
    /// Interaction logic for ucStatistics.xaml
    /// </summary>
    public partial class ucStatistics : UserControl
    {
        private StatisticsService service = new StatisticsService();
        private MainWindow MainWindow;
        public SeriesCollection SeriesCollection { get; set; } = new SeriesCollection();
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public ucStatistics(MainWindow mainWindow)
        {
            InitializeComponent();
            MainWindow = mainWindow;
            DataContext = this;
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            cmbYear.Items.Add(2023);
            cmbYear.Items.Add(2024);
            SetAxis();
        }

        private async void cmbYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearChart();
            await LoadData();
        }

        private void ClearChart()
        {
            SeriesCollection.Clear();
            DataContext = this;
        }

        private async Task LoadData()
        {
            if (cmbYear.SelectedItem == null) {
                SetAxis();
                return;
            }

            var year = (int)cmbYear.SelectedItem;       
            var result = await service.AttendanceByMonths(year);

            var columns = new ChartValues<double>();
            foreach (var item in result)
            {
                columns.Add(item.Value);
            }

            SeriesCollection.Add(new StackedColumnSeries
            {
                Title = "Children",
                Values = columns,
                DataLabels = true,
                StackMode = StackMode.Values
            });

            var months = result.Select(x => x.Key.ToString()).ToArray();
            Labels = months;
            Formatter = value => value + " Child";

            DataContext = this;
        }

        private void SetAxis()
        {
            var defaultDictionary = service.Default();
            var columns = new ChartValues<double>();

            foreach (var item in defaultDictionary)
            {
                columns.Add(item.Value);
            }

            SeriesCollection.Add(new StackedColumnSeries
            {
                Title = "Children",
                Values = columns,
                DataLabels = true,
                StackMode = StackMode.Values
            });

            var months = defaultDictionary.Select(x => x.Key.ToString()).ToArray();
            Labels = months;

            DataContext = this;
        }
    }
}
