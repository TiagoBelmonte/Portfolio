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
using System.Windows.Shapes;
using TuinCentrumBL.Interfaces;
using TuinCentrumBL.manager;
using TuinCentrumBL.Model;
using TuinCentrumDL_File;
using TuinCentrumDL_SQL;

namespace TuinCentrumUI.OfferteAanmaken
{
   
    public partial class OfferteStap2 : Window
    {
        string connectionString = @"Data Source=LAPTOP-I33SVT0O\SQLEXPRESS;Initial Catalog=Tuincentrum;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        IFileProcessor processor;
        ITuincentrumRepository tuincentrumRepository;
        TuincentrumManager Tuinmanager;
        Klant klant = new Klant();
        double TotalePrijs = 0;
        Offerte offerte = new Offerte();
        public OfferteStap2(Offerte offerte1)
        {
            offerte = offerte1;
            InitializeComponent();

            if (!Leveren.IsChecked.Value)
            {
                Aanleggen.Visibility = Visibility.Hidden;
            }


            processor = new FileProcessor();
            tuincentrumRepository = new TuincentrumRepository(connectionString);
            Tuinmanager = new TuincentrumManager(processor, tuincentrumRepository);
            List<String> productenLijst = new List<string>();

            foreach (Product product1 in offerte.Producten.Keys)
            {
                productenLijst.Add($"Naam: {product1.NederlandseNaam}, Prijs: {product1.Prijs}, Aantal: {offerte.Producten[product1]}");
            }
            DataProducten.ItemsSource = productenLijst;
            //labels toevoegen voor info klant en die oproepen via de string naam

            LabelNaam.Content = $"Naam: {offerte.Klant.Naam}";
            LabelID.Content = $"ID: {offerte.Klant.ID}";
            LabelAdres.Content = $"Adres: {offerte.Klant.Adres}";
            LabelDatum.Content = DateTime.Now.ToString();

            TotalePrijs = offerte.BerekenPrijs();
            LabelPrijs.Content = $"Totale prijs: {TotalePrijs}";

            //Label totale prijs nog aanpassen eenmaal je prijs kan berekenen


            offerte.Datum = DateTime.Now;
            offerte.leveren = Leveren.IsChecked.Value;
            offerte.Aanleg = Aanleggen.IsChecked.Value;
            offerte.Aantal = offerte.Producten.Count;
            offerte.ID = Tuinmanager.BerekenOfferteID();

        }
        private void Afhalen_Checked(object sender, RoutedEventArgs e)
        {
            //Dit nog beter maken
            offerte.leveren = Leveren.IsChecked.Value;
            offerte.Aanleg = Aanleggen.IsChecked.Value;
            Aanleggen.Visibility = Visibility.Visible;
            LabelPrijs.Content = $"Totale prijs: {offerte.BerekenPrijs()}";

        }
        private void Aanleggen_Checked(object sender, RoutedEventArgs e)
        {
            //Dit nog beter maken
            offerte.leveren = Leveren.IsChecked.Value;
            offerte.Aanleg = Aanleggen.IsChecked.Value;
            Aanleggen.Visibility = Visibility.Visible;
            LabelPrijs.Content = $"Totale prijs: {offerte.BerekenPrijs()}";


        }
        private void Afhalen_UnChecked(object sender, RoutedEventArgs e)
        {
            //Dit nog beter maken
            offerte.leveren = Leveren.IsChecked.Value;
            offerte.Aanleg = Aanleggen.IsChecked.Value;
            Aanleggen.Visibility = Visibility.Visible;
            LabelPrijs.Content = $"Totale prijs: {offerte.BerekenPrijs()}";


        }
        private void Aanleggen_UnChecked(object sender, RoutedEventArgs e)
        {
            //Dit nog beter maken
            offerte.leveren = Leveren.IsChecked.Value;
            offerte.Aanleg = Aanleggen.IsChecked.Value;
            Aanleggen.Visibility = Visibility.Visible;
            LabelPrijs.Content = $"Totale prijs: {offerte.BerekenPrijs()}";


        }
        private void Button_Click_Anulleer(object sender, RoutedEventArgs e)
        {
            // Open het startScherm opnieuw
            MainWindow start = new MainWindow();
            start.Show();

            // Sluit dit venster
            this.Close();
        }
        private void Button_Click_OffertePlaatsen(object sender, RoutedEventArgs e)
        {
            offerte.Aanleg = Aanleggen.IsChecked.Value;
            offerte.leveren = Leveren.IsChecked.Value;
            offerte.Prijs = offerte.BerekenPrijs();

            




            tuincentrumRepository.schrijfOfferte(offerte);

            MessageBox.Show("Offerte is aangemaakt", "Tuincentrum");

            

            MainWindow start = new MainWindow();
            start.Show();

            this.Close();
        }
    }
}
