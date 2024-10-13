using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace TuinCentrumUI.Aanpassen
{
    /// <summary>
    /// Interaction logic for OfferteAanpassen.xaml
    /// </summary>
    public partial class OfferteAanpassen : Window
    {
        Dictionary<Product, int> VerwijderdProducten = new Dictionary<Product, int>();
        Dictionary<Product, int> NieuweProducten = new Dictionary<Product, int>();
        TuincentrumManager Tuinmanager;
        IFileProcessor processor;
        List<String> productenLijst = new List<string>();
        Offerte offerte = new Offerte();
        double TotalePrijs = 0;


        ITuincentrumRepository tuincentrumRepository;
        string connectionString = @"Data Source=LAPTOP-I33SVT0O\SQLEXPRESS;Initial Catalog=Tuincentrum;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        public OfferteAanpassen(Offerte offerte1)
        {
            InitializeComponent();
            processor = new FileProcessor();
            tuincentrumRepository = new TuincentrumRepository(connectionString);
            Tuinmanager = new TuincentrumManager(processor, tuincentrumRepository);
            offerte = offerte1;

            //offerte.Producten = tuincentrumRepository.GeefProductenViaID(offerte.ID);


            if (!offerte.leveren)
            {
                CheckAanleg.Visibility = Visibility.Hidden;
            }

            foreach (Product product1 in offerte.Producten.Keys)
            {
                productenLijst.Add($"Naam: {product1.WetenschappelijkeNaam}, Prijs: {product1.Prijs}, Aantal: {offerte.Producten[product1]}");
            }
            ListProducten.ItemsSource = productenLijst;

            LabelOfferteIDInvull.Content = offerte.ID;
            TextDatum.Text = offerte.Datum.ToString();
            LabelNaam.Content = offerte.Klant.Naam;
            LabelPrijsAanvul.Content = offerte.Prijs;
            CheckLeveren.IsChecked = offerte.leveren;
            CheckAanleg.IsChecked = offerte.Aanleg;



        }

        public OfferteAanpassen( Dictionary<Product, int> nieuweProducten, Offerte offerte1)
        {
            InitializeComponent();
            processor = new FileProcessor();
            tuincentrumRepository = new TuincentrumRepository(connectionString);
            Tuinmanager = new TuincentrumManager(processor, tuincentrumRepository);
            offerte = offerte1;
            NieuweProducten = nieuweProducten;


            if (!offerte.leveren)
            {
                CheckAanleg.Visibility = Visibility.Hidden;
            }

            foreach (Product product1 in offerte.Producten.Keys)
            {
                productenLijst.Add($"Naam: {product1.WetenschappelijkeNaam}, Prijs: {product1.Prijs}, Aantal: {offerte.Producten[product1]}");
            }
            ListProducten.ItemsSource = productenLijst;

            LabelOfferteIDInvull.Content = offerte.ID;
            TextDatum.Text = offerte.Datum.ToString();
            LabelNaam.Content = offerte.Klant.Naam;
            LabelPrijsAanvul.Content = offerte.Prijs;
            CheckLeveren.IsChecked = offerte.leveren;
            CheckAanleg.IsChecked = offerte.Aanleg;

        }
        private void Afhalen_Checked(object sender, RoutedEventArgs e)
        {
            //Dit nog beter maken
            offerte.leveren = CheckLeveren.IsChecked.Value;
            offerte.Aanleg = CheckAanleg.IsChecked.Value;
            LabelPrijsAanvul.Content = offerte.BerekenPrijs();
            CheckAanleg.Visibility = Visibility.Visible;

        }
        private void Aanleggen_Checked(object sender, RoutedEventArgs e)
        {
            //Dit nog beter maken
            offerte.leveren = CheckLeveren.IsChecked.Value;
            offerte.Aanleg = CheckAanleg.IsChecked.Value;
            LabelPrijsAanvul.Content = offerte.BerekenPrijs();
            CheckAanleg.Visibility = Visibility.Visible;



        }
        private void Afhalen_UnChecked(object sender, RoutedEventArgs e)
        {
            //Dit nog beter maken
            offerte.leveren = CheckLeveren.IsChecked.Value;
            offerte.Aanleg = CheckAanleg.IsChecked.Value;
            LabelPrijsAanvul.Content = offerte.BerekenPrijs();
            CheckAanleg.Visibility = Visibility.Visible;

        }
        private void Aanleggen_UnChecked(object sender, RoutedEventArgs e)
        {

            //Dit nog beter maken
            offerte.leveren = CheckLeveren.IsChecked.Value;
            offerte.Aanleg = CheckAanleg.IsChecked.Value;
            LabelPrijsAanvul.Content = offerte.BerekenPrijs();
            CheckAanleg.Visibility = Visibility.Visible;

        }
        private void ButtonAantalAanpassen_Click(object sender, RoutedEventArgs e)
        {
            if (ListProducten.SelectedItem != null)
            {
                int selectedIndex = ListProducten.SelectedIndex;
                Product product = new Product();
                if (selectedIndex < offerte.Producten.Keys.Count)
                {
                    product = offerte.Producten.Keys.ElementAt(selectedIndex);
                }
                string input = Microsoft.VisualBasic.Interaction.InputBox($"Hoe veel {product.NederlandseNaam} wil je kopen?", "Aantal", "0");
                int aantal;
                if (int.TryParse(input, out aantal) && aantal > 0)
                {
                    if (offerte.Producten.ContainsKey(product))
                    {
                        offerte.Producten[product] = aantal;
                    }

                    // Maak een nieuwe lijst voor de bijgewerkte items
                    List<string> bijgewerkteProductenLijst = new List<string>();

                    foreach (Product product1 in offerte.Producten.Keys)
                    {
                        bijgewerkteProductenLijst.Add($"Naam: {product1.NederlandseNaam}, Prijs: {product1.Prijs}, Aantal: {offerte.Producten[product1]}");
                    }
                    // Wijs de nieuwe lijst opnieuw toe aan de ItemsSource van ListProducten
                    ListProducten.ItemsSource = bijgewerkteProductenLijst;

                    // Update de prijs
                    bool leveren = CheckLeveren.IsChecked.Value;
                    bool aanlegen = CheckAanleg.IsChecked.Value;
                    TotalePrijs = 0;
                    LabelPrijsAanvul.Content = offerte.BerekenPrijs();
                }
                else
                {
                    MessageBox.Show("Fout, geef een getal groter dan 0 weer");
                }
            }
            else
            {
                MessageBox.Show("Selecteer een product uit de lijst.");
            }
        }
        private void ButtonProductVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            if (ListProducten.Items.Count>0)
            {
                if (ListProducten.SelectedItem != null)
                {
                    int selectedIndex = ListProducten.SelectedIndex;
                    Product product = new Product();
                    if (selectedIndex < offerte.Producten.Keys.Count)
                    {
                        product = offerte.Producten.Keys.ElementAt(selectedIndex);
                        //Voeg het product toe aan nieuwe dictionary
                        VerwijderdProducten.Add(product, offerte.Producten[product]);
                        //Verwijder het product
                        offerte.Producten.Remove(product);
                    }                   

                    // Maak een nieuwe lijst voor de bijgewerkte items
                    List<string> bijgewerkteProductenLijst = new List<string>();

                    foreach (Product product1 in offerte.Producten.Keys)
                    {
                        bijgewerkteProductenLijst.Add($"Naam: {product1.NederlandseNaam}, Prijs: {product1.Prijs}, Aantal: {offerte.Producten[product1]}");
                    }
                    // Wijs de nieuwe lijst opnieuw toe aan de ItemsSource van ListProducten
                    ListProducten.ItemsSource = bijgewerkteProductenLijst;

                    // Update de prijs
                    bool leveren = CheckLeveren.IsChecked.Value;
                    bool aanlegen = CheckAanleg.IsChecked.Value;
                    TotalePrijs = 0;
                    LabelPrijsAanvul.Content = offerte.BerekenPrijs();
                }

                else
                {
                    MessageBox.Show("Selecteer een product uit de lijst.");
                }
            }
            else
            {
                MessageBox.Show("Je Moet minstens 1 product in je offerte over hebben");
            }
        }
        private void ButtonProductenToevoegen_Click(object sender, RoutedEventArgs e)
        {
            ProductenToevoegen productenToevoegen = new ProductenToevoegen(offerte);
            productenToevoegen.Show();
            this.Close();
        }
        private void ButtonOfferteAanpassen_Click(object sender, RoutedEventArgs e)
        {
            

            offerte.Aantal = offerte.Producten.Count;
            //offerte.klantnummer = int.Parse(TextKlantnummer.Text);
            offerte.Prijs = offerte.BerekenPrijs();
            offerte.Datum = DateTime.Parse(TextDatum.Text);
            offerte.leveren = CheckLeveren.IsChecked.Value;
            offerte.Aanleg = CheckAanleg.IsChecked.Value;

            Tuinmanager.UpdateOfferte(offerte, NieuweProducten, VerwijderdProducten);
            MessageBox.Show("Offerte Geupdate in je databank");
            this.Close();
        }

        private void ButtonKlantAanpassen_Click(object sender, RoutedEventArgs e)
        {
            Boolean offerteAanmaken = false;
            KlantenZoekenViaNaam klantenZoekenViaNaam = new KlantenZoekenViaNaam(offerte);
            klantenZoekenViaNaam.Show();
            this.Close();
        }
    }
}

