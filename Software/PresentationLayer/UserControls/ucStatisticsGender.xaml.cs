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
    /// Interaction logic for ucStatisticsGender.xaml
    /// </summary>
    public partial class ucStatisticsGender : UserControl
    {
        private StatisticsService service = new StatisticsService();
        private MainWindow MainWindow;
        public SeriesCollection SeriesCollection { get; set; } = new SeriesCollection();
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        public ucStatisticsGender(MainWindow mainWindow)
        {
            InitializeComponent();
            MainWindow = mainWindow;
            DataContext = this;
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var result = service.Gender();
            var columns = new ChartValues<int>();
            foreach(var item in result)
            {
                columns.Add(item);
            }

            SeriesCollection.Add(new StackedColumnSeries
            {
                Title = "Children",
                Values = columns,
                DataLabels = true,
                StackMode = StackMode.Values
            });

            var gender = new List<string>
            {
                "M",
                "Ž"
            };
            Labels = gender.Select(x => x).ToArray();
            Formatter = value => value + " Children";

            DataContext = this;
        }
    }
}
