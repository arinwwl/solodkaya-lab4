using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace solodkaya_lab4
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
        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            
            string destination = destinationTextBox.Text;

            TRAIN<int>[] trains = new TRAIN<int>[6];

         
            for (int i = 0; i < trains.Length; i++)
            {
                trains[i] = new TRAIN<int>
                {
                    Destination = "Пункт назначения " + (i + 1),
                    TrainNumber = i + 1,
                    DepartureTime = DateTime.Now.AddHours(i)
                };
            }

            // Сортировка по времени отправления
            Array.Sort(trains);

            
            List<TRAIN<int>> foundTrains = new List<TRAIN<int>>();
            foreach (TRAIN<int> train in trains)
            {
                if (train.Destination == destination)
                {
                    foundTrains.Add(train);
                }
            }

            
            trainDataGrid.ItemsSource = foundTrains;

            
            if (foundTrains.Count == 0)
            {
                MessageBox.Show("Поездов, направляющихся в указанный пункт, не найдено.");
            }
        }
    }

    public class TRAIN<T> : ICloneable, IComparable<TRAIN<T>>
    {
        public string Destination { get; set; }
        public T TrainNumber { get; set; }
        public DateTime DepartureTime { get; set; }

        public object Clone()
        {
            return new TRAIN<T>
            {
                Destination = this.Destination,
                TrainNumber = this.TrainNumber,
                DepartureTime = this.DepartureTime
            };
        }

        public int CompareTo(TRAIN<T> other)
        {
            return this.DepartureTime.CompareTo(other.DepartureTime);
        }
    }

    public class DestinationComparer<T> : IComparer<TRAIN<T>>
    {
        public int Compare(TRAIN<T> x, TRAIN<T> y)
        {
            return x.Destination.CompareTo(y.Destination);
        }
    }
}
