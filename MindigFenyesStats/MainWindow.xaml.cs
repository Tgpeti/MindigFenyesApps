using MindigFenyesDB.Data;
using MindigFenyesDB.Models;
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
                    //Listbox1.Items.Clear();
                    calendar1.Visibility = Visibility.Hidden;
                    Listbox1.Visibility = Visibility.Visible;
                    Listbox1.ItemsSource = _context.Workers.Select(w => w.Name).ToList();
                    break;
                case 1:
                    //Listbox1.Items.Clear();
                    Listbox1.Visibility = Visibility.Hidden;
                    calendar1.Visibility = Visibility.Visible;

                    break;

                case 2:
                    //Listbox1.Items.Clear();
                    calendar1.Visibility = Visibility.Hidden;
                    Listbox1.Visibility = Visibility.Visible;
                    Listbox1.ItemsSource = Enum.GetValues(typeof(Issue)).Cast<Issue>().ToList();
                    break;
                default:
                    break;
            }


        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Listbox1.ItemsSource = _context.Workers.Select(w => w.Name).ToList();
        }
    }
}
