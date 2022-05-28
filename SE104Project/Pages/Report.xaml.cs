using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;

namespace SE104Project.Pages
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Page
    {
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        public Report()
        {
            InitializeComponent();

            DataContext = this;

            SeriesCollection = new SeriesCollection()
            {
                new ColumnSeries
                {
                    Title = "Doanh thu",
                    Values = new ChartValues<double> {10,50,39,50}
                },

                new ColumnSeries
                {
                    Title = "Chi phí",
                    Values = new ChartValues<double> {5,40,30,40}
                }
            };

            Labels = new[] { "1", "2", "3", "4" };

            Formatter = value => string.Format("{0:N0}", value);

        }
    }
}
