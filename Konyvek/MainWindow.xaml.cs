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
using static Konyvek.Konyv;

namespace Konyvek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Konyv> konyvek = new List<Konyv>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void betoltes(object sender, RoutedEventArgs e)
        {
            konyvek.Clear();

            konyvek.Add(new Konyv("1984", "George Orwell", 328, "Sci-fi", true));
            konyvek.Add(new Konyv("A szolgálólány meséje", "Margaret Atwood", 311, "Disztópia", false));
            konyvek.Add(new Konyv("Az ember tragédiája", "Madách Imre", 250, "Dráma", true));
            konyvek.Add(new Konyv("Dűne", "Frank Herbert", 604, "Sci-fi", true));
            konyvek.Add(new Konyv("Egri csillagok", "Gárdonyi Géza", 552, "Történelmi", false));

            dgKonyvek.ItemsSource = null;
            dgKonyvek.ItemsSource = konyvek;
        }

        private void mennyi(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Összesen " + konyvek.Count + " könyv van.");
        }

        private void atlagOldal(object sender, RoutedEventArgs e)
        {
            int osszeg = 0;

            foreach (Konyv k in konyvek)
            {
                osszeg += k.Oldalszam;
            }

            double atlag = (double)osszeg / konyvek.Count;

            MessageBox.Show("Átlagos oldalszám: " +
                Math.Round(atlag, 2));
        }

        private void elerhetoKonyv(object sender, RoutedEventArgs e)
        {
            dgKonyvek.ItemsSource = null;

            dgKonyvek.ItemsSource = konyvek
                .Where(k => k.Elerheto == true)
                .ToList();
        }

        private void csakCimek(object sender, RoutedEventArgs e)
        {
            List<KonyvCim> cimek = new List<KonyvCim>();

            foreach (Konyv k in konyvek)
            {
                cimek.Add(new KonyvCim(k.Cim));
            }

            dgKonyvek.ItemsSource = null;
            dgKonyvek.ItemsSource = cimek;
        }

        private void rendezes(object sender, RoutedEventArgs e)
        {
            dgKonyvek.ItemsSource = null;

            dgKonyvek.ItemsSource = konyvek
                .OrderBy(k => k.Szerzo)
                .ToList();
        }

        private void leghosszabbKonyv(object sender, RoutedEventArgs e)
        {
            Konyv leghosszabb = konyvek[0];

            foreach (Konyv k in konyvek)
            {
                if (k.Oldalszam > leghosszabb.Oldalszam)
                {
                    leghosszabb = k;
                }
            }

            MessageBox.Show("A leghosszabb könyv: " +
                leghosszabb.Cim + "Oldalszám: " +
                leghosszabb.Oldalszam);
        }
    }
}