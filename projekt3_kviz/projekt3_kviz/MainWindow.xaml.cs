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

namespace projekt3_kviz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<RadioButton> gombok = new List<RadioButton>();
        public List<Tantargy> tantargyak = new List<Tantargy>();
        public MainWindow()
        {

            InitializeComponent();
        }
        public class Tantargy
        {

        }
    }
}
