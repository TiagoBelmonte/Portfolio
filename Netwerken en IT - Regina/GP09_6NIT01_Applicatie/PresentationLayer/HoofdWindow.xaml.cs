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

//We schrijven using businessLayer en using DataAccesLayer zodat we niet voor elke object of methode dat we gebruiken van één van de twee lagen de laagnaam ervoor moeten schrijven.
//We schrijven dit ervoor om gemmakelijker te kunnen programeren. Ook werk je dan sneller.
using BusinessLayer;
using DataAccessLayer;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for HoofdWindow.xaml
    /// </summary>
    public partial class HoofdWindow : Window
    {
        //klassevelden
        List<Probleem> _problemenlijst;
        ProbleemDA _probleemDA;
        Probleem _probleem;
        Werknemer _werknemer1;

        public HoofdWindow(Werknemer _Werknemer)
        {
            InitializeComponent();
            //we initialiseren een nieuwe instantie van de klasse probleemDA.
            _probleemDA = new ProbleemDA();
            _werknemer1 = _Werknemer;

            //we vullen de naam in waarmee de gebruiker heeft ingelogd
            labelGebruikersnaam.Content = _Werknemer.Naam;
            //als de ingelogde gebruiker een IT-coordinator is gaat er in de labelFunctie
            //IT-Coordinator verschijnen anders gaat er werknemer verschijnen.
            if (_Werknemer.ItCoordinator == 1)
            {
                labelFunctie.Content = "IT-Coordinator ID= " + _Werknemer.WerknemerID;
            }
            else
            {
                labelFunctie.Content = "Werknemer ID= " + _Werknemer.WerknemerID;
            }
            //We laten in labelDatum de datum van vaandag verschijnen.
            labelDatum.Content = DateTime.Now.ToShortDateString();

            //Alle problemen worden weergeven in de listbox.
            _problemenlijst = _probleemDA.Ophalenproblemen();
            foreach (Probleem x in _problemenlijst)
            {
                listBoxProblemen.Items.Add(x);
            }
        }

        //Als de gebruiker op dit knop drukt dan gaat hij afgemeld worden en terug naar deze inlogvenster verstuurd worden.
        private void ButtonAfmelden_Click(object sender, RoutedEventArgs e)
        {
            //Nieuwe instantie van de klasse MainWindow.
            MainWindow venster = new MainWindow();
            //Nieuwe venster openen.
            venster.Show();
            //Deze venster sluiten.
            this.Close();
        }
        
        
        //als de gebruiker op de knop Nieuw probleem drukt wordt hij gestuurd naar een nieuwe venster waar hij een nieuw probleem kan aanmaken.
        private void ButtonNieuwProbleem_Click(object sender, RoutedEventArgs e)
        {
            //Nieuwe instantie maken van de klasse NieuwProbleem.
            //De nieuwe probleem wordt aangemaakt in de venster NieuwProbleem.
            NieuwProbleem venster = new NieuwProbleem(_probleem);
            //De nieuwe venster openen.
            venster.Show();
        }

        //Als de gebruiker op de knop probleem verwijderen drukt zal het geselecteerde probleem vanuit de databank verwijderd worden.
        private void ButtonVerwijderProbleem_Click(object sender, RoutedEventArgs e)
        {
            //We gaan de methode probleemVerwijderen gebruiken om het geselecteerde probleem te verwijderen.  
            _probleemDA.ProbleemVerwijderen(_probleem);
            

        }
            
        //Als de gebruiker de knop probleem wijzigen drukt wordt hij verwezen naar de venster probleem aanmaken om de geselecteerde 
        //probleem te wijzigen.
        private void ButtonWijzigProbleem_Click(object sender, RoutedEventArgs e)
        {
            //we initialiseren de nieuwe instantie van de klasse probleem, we geven hem de waarde mee van de geselecteerde probleem in de listbox.
            _probleem = (Probleem)listBoxProblemen.SelectedItem;

            //Nieuwe instantie maken van de klasse NieuwProbleem.
            NieuwProbleem venster = new NieuwProbleem(_probleem);

            //De gegevens van de geselcteerde probleem aanvullen in de verschillende textboxen
            venster.TextBoxNaam.Text = _werknemer1.Naam;
            venster.TextBoxWerknemerId.Text = Convert.ToString(_werknemer1.WerknemerID);
            venster.TextBoxToestel.Text = _probleem.Toestel;
            venster.TextBoxPlaats.Text = _probleem.Plaats;
            venster.TextBoxOmschrijving.Text = _probleem.Omschrijving;
            venster.textboxProbleemId.Text = Convert.ToString(_probleem.ProbleemId);
            venster.textboxStatus.Text = _probleem.Status;
            venster.textboxItCoordinator.Text = _probleem.ItCoordinator;
            venster.textboxDatum.Text = Convert.ToString(_probleem.Datum.ToShortDateString());

            //alleen de velden dat de gebruiker mag aanpassen als hij een werknemer is gaan we niet op alleen leesbaar zetten, de rest van de velden wel.
            if (_werknemer1.ItCoordinator == 0)
            {
                venster.TextBoxNaam.IsReadOnly = true;
                venster.TextBoxWerknemerId.IsReadOnly = true;
                venster.textboxProbleemId.IsReadOnly = true;
                venster.textboxStatus.IsReadOnly = true;
                venster.textboxItCoordinator.IsReadOnly = true;
                venster.textboxDatum.IsReadOnly = true;
            }
            else
            {
                venster.TextBoxNaam.IsReadOnly = true;
                venster.TextBoxWerknemerId.IsReadOnly = true;
                venster.textboxProbleemId.IsReadOnly = true;
                venster.textboxDatum.IsReadOnly = true;
                venster.TextBoxOmschrijving.IsReadOnly = true;
                venster.TextBoxPlaats.IsReadOnly = true;
                venster.TextBoxToestel.IsReadOnly = true;

                venster.textboxStatus.IsReadOnly = false;
                venster.textboxItCoordinator.IsReadOnly = false;

            }

            //de knop aanmaken gaan we niet zichtbaar maken en de knop wijzigen wel
            venster.ButtonAanmaken.Visibility = Visibility.Hidden;
            venster.buttonWijzigen.Visibility = Visibility.Visible;

            //Het nieuwe venster openen.
            venster.Show();
        }
    }
}
