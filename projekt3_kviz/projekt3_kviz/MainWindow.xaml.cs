using System;
using System.Collections.Generic;
using System.IO;
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
        List<RadioButton> radioGombok = new List<RadioButton>();
        public List<Tantargy> tantargyak = new List<Tantargy>();
        Tantargy valasztottTantargy = null;
        Tema valasztottTema = null;
        public Dictionary<string, Tantargy> tantargyNyilvantarto = new Dictionary<string, Tantargy>();
        public List<Kerdes> kerdesek = new List<Kerdes>();
        int oldalSzama = 0;
        Kerdes valasztottKerdes = null;

        bool kiertekelve = false;
        List<Button> oldalGombok = new List<Button>();
        public MainWindow()
        {
            InitializeComponent();
            oldalGombok.Add(oldal1);
            oldalGombok.Add(oldal2);
            oldalGombok.Add(oldal3);
            oldalGombok.Add(oldal4); 
            oldalGombok.Add(oldal5);
            oldalGombok.Add(oldal6);
            oldalGombok.Add(oldal7);
            oldalGombok.Add(oldal8);
            oldalGombok.Add(oldal9);
            oldalGombok.Add(oldal10);

            radioGombok.Add(valasz1);
            radioGombok.Add(valasz2);
            radioGombok.Add(valasz3);
            radioGombok.Add(valasz4);

            
            Tantargy tori = new Tantargy("tori.txt");
            tantargyNyilvantarto.Add(tori.targyNeve, tori);
            tantargyCombo.Items.Add(tori.targyNeve);

            
        }
        public class Tantargy
        {
            public Dictionary<string, Tema> temaNyilvantarto = new Dictionary<string, Tema>();
            public List<Tema> tema = new List<Tema>();
            public string targyNeve;
            public Tantargy(string fajl)
            {
               
                string[] kerdesek = File.ReadAllLines(fajl);
                targyNeve = kerdesek[0].Split(';')[0];

                List<string> temak = new List<string>();
                foreach (string sor in kerdesek )
                {
                    string temaNeve = sor.Split(';')[1];
                    if (!temak.Contains(temaNeve))

                    {
                        temak.Add(temaNeve);
                        Tema ujTema = new Tema(temaNeve,kerdesek);
                        temaNyilvantarto.Add(ujTema.temaNeve, ujTema);
                        tema.Add(ujTema);
                    }
                }
            }
        }
        public class Tema
        {
            public List<Kerdes> kerdesek = new List<Kerdes>();
            public string temaNeve;

            public Tema(string neve, string[] fajl)
            {
                this.temaNeve = neve;
                foreach ( string s in fajl)
                {
                    if(s.Split(';')[1] == neve)
                    {
                        Kerdes kerdes = new Kerdes(s);
                        kerdesek.Add(kerdes);
                    }
                }
            }
        }
        public class Kerdes
        {
            public string kerdes;
            public string helyesValasz;
            public string valasz2;
            public string valasz3;
            public string valasz4;

            public string valasztott = null;
            public List<string> sorrend = new List<string>();
            public List<string> valaszok = new List<string>();

            public Kerdes(string s)
            {
                string[] sorElemei = s.Split(';');
                kerdes = sorElemei[2];
                helyesValasz = sorElemei[3];
                valasz2=sorElemei[4];
                valasz3=sorElemei[5];
                valasz4=sorElemei[6];

                valaszokFeltoltese();
            }

            private void valaszokFeltoltese()
            {
                valaszok.Add(helyesValasz);
                valaszok.Add(valasz2);
                valaszok.Add(valasz3);
                valaszok.Add(valasz4);
            }
        }

        private void tantargyCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            temaCombo.IsEnabled = false;
            tantargyCombo.Items.Clear();
            temaCombo.Items.Clear ();
            valasztottTantargy = null;
            valasztottTema = null;

            Tantargy tantargy = null;
            string valasztottTargy = tantargyCombo.SelectedItem.ToString();
            tantargyNyilvantarto.TryGetValue(valasztottTargy, out tantargy);

            if (tantargy == null) return;
            temaCombo.IsEnabled = true;

            valasztottTantargy = tantargy;
            foreach (Tema x in tantargy.tema)
            {
                temaCombo.Items.Add(x.temaNeve);
            }

            
        }

        private void temaCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (temaCombo.SelectedItem == null || temaCombo.Items.Count <= 0) { return; }
            Tema tema = null;
            string kivalasztottTema = temaCombo.SelectedItem.ToString();
            valasztottTantargy.temaNyilvantarto.TryGetValue(kivalasztottTema, out tema);

            if(tema == null) return;
            valasztottTema = tema;

        }
    }
}
