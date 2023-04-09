using Microsoft.EntityFrameworkCore;
using MindigFenyesDB.Data;
using MindigFenyesDB.Models;
using MindigFenyesBusinessLogic;
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
using Newtonsoft.Json;
using System.IO;

namespace MindigFenyesStats
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MindigFenyesContext _context = new();
        public MainWindow()
        {
            InitializeComponent();
            ComboBox1.SelectionChanged += ComboBox_SelectionChanged;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (ComboBox1.SelectedIndex)
            {
                case 0:
                    datePicker1.Visibility = Visibility.Hidden;
                    Listbox1.Visibility = Visibility.Visible;
                    Listbox1.ItemsSource = _context.Workers.Select(w => w.Name).ToList();
                    break;
                case 1:
                    Listbox1.Visibility = Visibility.Hidden;
                    datePicker1.Visibility = Visibility.Visible;
                    break;

                case 2:
                    datePicker1.Visibility = Visibility.Hidden;
                    Listbox1.Visibility = Visibility.Visible;
                    Listbox1.ItemsSource = Enum.GetValues(typeof(Issue)).Cast<Issue>().ToList();
                    break;
                default:
                    break;
            }


        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var closedTickets = _context.Tickets.Where(t => t.IsFinished).Include(t => t.Worker).Include(t => t.Address).ToList();
            List<Ticket> source;
            if (Listbox1.SelectedItem != null || datePicker1.SelectedDate != null)
            {
                switch (ComboBox1.SelectedIndex)
                {
                    case 0:
                        string name = Listbox1.SelectedItem.ToString();

                        source = closedTickets.Where(t => t.Worker.Name == name).ToList();
                        dataGrid1.ItemsSource = source;
                        break;
                    case 1:
                        DateTime? dateSelected = datePicker1.SelectedDate;
                        source = closedTickets.Where(t => t.FinishDate!.Value.Year == dateSelected.Value.Year && t.FinishDate.Value.Month == dateSelected.Value.Month).ToList();
                        dataGrid1.ItemsSource = source;
                        break;

                    case 2:
                        MindigFenyesDB.Models.Issue issue = (Issue)Listbox1.SelectedItem;
                        source = closedTickets.Where(t => t.Issue == issue).ToList();
                        dataGrid1.ItemsSource = source;
                        break;

                    default:
                        break;
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (dataGrid1.ItemsSource != null)
            {
                var export = dataGrid1.ItemsSource;
                string jsonExport = JsonConvert.SerializeObject(export);
                string fileName = "D:\\coding\\01_Webuni\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-JsonExport.json";
                File.WriteAllText(fileName, jsonExport);
                MessageBox.Show("Az exportálás sikeres volt!");
            }
        }
    }
}
