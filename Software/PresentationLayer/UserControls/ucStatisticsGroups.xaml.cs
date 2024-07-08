using BusinessLogicLayer;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PresentationLayer.UserControls
{
    /// <summary>
    /// Interaction logic for ucStatisticsGroups.xaml
    /// </summary>
    public partial class ucStatisticsGroups : UserControl
    {
        private StatisticsService service = new StatisticsService();
        private MainWindow MainWindow;
        public SeriesCollection SeriesCollection { get; set; } = new SeriesCollection();
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        public ucStatisticsGroups(MainWindow mainWindow)
        {
            InitializeComponent();
            MainWindow = mainWindow;
            DataContext = this;
        }

        private async void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            var result = await service.Group();
            var columns = new ChartValues<int>();

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

            var groups = result.Select(x => x.Key.ToString()).ToArray();
            Labels = groups;
            Formatter = value => value + " Children";

            DataContext = this;
        }
    }
}
