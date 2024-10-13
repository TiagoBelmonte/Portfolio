using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using TuinCentrumBL.Interfaces;
using TuinCentrumBL.manager;
using TuinCentrumBL.Model;
using TuinCentrumDL_File;
using TuinCentrumDL_SQL;
using TuinCentrumUI.OfferteAanmaken;

namespace TuinCentrumUI.Aanpassen
{
    /// <summary>
    /// Interaction logic for ProductenToevoegen.xaml
    /// </summary>
    public partial class ProductenToevoegen : Window
    {
        string connectionString = @"Data Source=LAPTOP-I33SVT0O\SQLEXPRESS;Initial Catalog=Tuincentrum;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        IFileProcessor processor;
        ITuincentrumRepository TuinRepository;
        TuincentrumManager TuinManager;
        ObservableCollection<Product> AlleProducten;
        ObservableCollection<Product> GeselecteerdeProducten;
        ObservableCollection<Product> GefilterdeProducten;
        Dictionary<Product, int> NieuweProducten = new Dictionary<Product, int>();
        Offerte offerte = new Offerte();
        Boolean offerteAanmaken = false;
        public ProductenToevoegen(Offerte offerte1)
        {
            InitializeComponent();
            processor = new FileProcessor();
            TuinRepository = new TuincentrumRepository(connectionString);
            TuinManager = new TuincentrumManager(processor, TuinRepository);

            offerte = offerte1;

            // Sorteer de productenlijst alfabetisch op de wetenschappelijke naam
            AlleProducten = new ObservableCollection<Product>(TuinManager.GeefProducten());
            GefilterdeProducten = new ObservableCollection<Product>(AlleProducten);

            AlleProductenListBox.ItemsSource = GefilterdeProducten;

            GeselecteerdeProducten = new ObservableCollection<Product>();
            GeselecteerdeProductenListBox.ItemsSource = GeselecteerdeProducten;


            foreach (Product p in offerte.Producten.Keys)
            {
                GeselecteerdeProducten.Add(p);
                AlleProducten.Remove(p);
            }
        }
        public ProductenToevoegen(Boolean offerteAanmaken1, Klant klant)
        {
            InitializeComponent();
            processor = new FileProcessor();
            TuinRepository = new TuincentrumRepository(connectionString);
            TuinManager = new TuincentrumManager(processor, TuinRepository);

            // Sorteer de productenlijst alfabetisch op de wetenschappelijke naam
            AlleProducten = new ObservableCollection<Product>(TuinManager.GeefProducten());
            GefilterdeProducten = new ObservableCollection<Product>(AlleProducten);

            AlleProductenListBox.ItemsSource = GefilterdeProducten;

            GeselecteerdeProducten = new ObservableCollection<Product>();
            GeselecteerdeProductenListBox.ItemsSource = GeselecteerdeProducten;
            offerteAanmaken = offerteAanmaken1;
            offerte.Klant = klant;

        }
        private void TextboxWetNaam_TextChanged(object sender, TextChangedEventArgs e)
        {

            string filter = TextboxWetNaam.Text.ToLower();

            var gefilterde = AlleProducten
                .Where(product => product.NederlandseNaam.ToLower().Contains(filter))
                .OrderBy(product => product.NederlandseNaam);

            GefilterdeProducten.Clear();
            foreach (var product in gefilterde)
            {
                GefilterdeProducten.Add(product);
            }
        }
        private void VoegAlleProductenToeButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Product p in AlleProducten)
            {
                GeselecteerdeProducten.Add(p);
            }
            GefilterdeProducten.Clear();
        }
        private void VoegProductToeButton_Click(object sender, RoutedEventArgs e)
        {
            List<Product> producten = new List<Product>();
            foreach (Product p in AlleProductenListBox.SelectedItems)
            {
                producten.Add(p);
            }

            foreach (Product p in producten)
            {
                GeselecteerdeProducten.Add(p);
                GefilterdeProducten.Remove(p);
            }
        }
        private void VerwijderAlleProductenButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Product p in GeselecteerdeProducten)
            {
                GefilterdeProducten.Add(p);
            }
            GeselecteerdeProducten.Clear();
        }
        private void VerwijderProduct_Click(object sender, RoutedEventArgs e)
        {
            List<Product> producten = new List<Product>();
            foreach (Product p in GeselecteerdeProductenListBox.SelectedItems)
            {
                producten.Add(p);
            }

            foreach (Product p in producten)
            {
                GeselecteerdeProducten.Remove(p);
                GefilterdeProducten.Add(p);
            }
        }
        private void VolgendeVensterButton_Click(object sender, RoutedEventArgs e)
        {
            if (offerteAanmaken)
            {
                if (GeselecteerdeProducten.Count > 0)
                {


                    foreach (Product product in GeselecteerdeProducten)
                    {
                        string input = Microsoft.VisualBasic.Interaction.InputBox($"Hoe veel {product.NederlandseNaam} Wil je kopen?", "Aantal", "0");
                        int aantal;
                        if (int.TryParse(input, out aantal) && aantal > 0)
                        {
                            offerte.Producten.Add(product, aantal);
                        }
                        else
                        {
                            MessageBox.Show("Fout, geef een getal groter dan 0 weer");
                        }
                    }

                    OfferteStap2 stap2 = new OfferteStap2(offerte);
                    stap2.Show();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Je kan geen bestelling plaatsen zonder minstens 1 product te selecteren");
                }
            }
            else
            {

                foreach (Product product in GeselecteerdeProducten)
                {
                    if (!offerte.Producten.ContainsKey(product))
                    {
                        string input = Microsoft.VisualBasic.Interaction.InputBox($"Hoe veel {product.NederlandseNaam} Wil je kopen?", "Aantal", "0");
                        int aantal;
                        if (int.TryParse(input, out aantal) && aantal > 0)
                        {
                            NieuweProducten.Add(product, aantal);
                            offerte.Producten.Add(product, aantal);
                            offerte.Prijs = offerte.BerekenPrijs();
                        }
                        else
                        {
                            MessageBox.Show("Fout, geef een getal groter dan 0 weer");
                        }
                    }
                }
                OfferteAanpassen offerteAanpassen = new OfferteAanpassen(NieuweProducten, offerte);
                offerteAanpassen.Show();
                this.Close();
            }

            
        }
    }
}

