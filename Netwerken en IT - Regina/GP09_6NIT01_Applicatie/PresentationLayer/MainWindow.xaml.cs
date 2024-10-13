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

//We schrijven using businessLayer en using DataAccesLayer zodat we niet voor elke object of methode dat we gebruiken van één van de twee lagen de laagnaam ervoor moeten schrijven.
//We schrijven dit ervoor om gemmakelijker te kunnen programeren. Ook werk je dan sneller.
using BusinessLayer;
using DataAccessLayer;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //klasevelden initialiseren
        Werknemer _werknemer;
        WerknemerDA _werknemerDA;
        List<Werknemer> _werknemerslijst;

        public MainWindow()
        {
            //Hieronder initialiseren we alle objecten dat zienbaar zijn op ons venster.
            InitializeComponent();
            //initialisatie van een object van de klasse WerknemerDA
            _werknemerDA = new WerknemerDA();     
        }

        //Als de werknemer op deze knop drukt gaat hij aangemeld worden als hij de juiste inloggegevens correct invult.
        private void ButtonInlogen_Click(object sender, RoutedEventArgs e)
        {
            //lijst wordt geïnitialiseerd.
            _werknemerslijst = _werknemerDA.OphalenWerknemers();
            //lijst met alle werknemers wordt overlopen
            foreach(Werknemer _werknemer in _werknemerslijst)
            {
                //Als de ingegeven e-mailadres en wachtwoordt overeenkomen dan gaat de werknemer ingelogd worden anders gaat hij een foutmelding krijgen
                if(textboxGebruikersnaam.Text == _werknemer.Email & textboxWachtwoord.Password == _werknemer.Wachtwoord)
                {
                    //Nieuwe instantie maken van de klasse HoofdWindow
                    HoofdWindow venster = new HoofdWindow(_werknemer);
                    //Nieuwe aangemaakte venster openen
                    venster.Show();
                    //Deze venster afsluiten
                    this.Close();
                }
                else
                {
                    //Als de gegevens niet kloppen komt er een pop-up venster tevoorschijn waar de gebruiker kan lezen dat de inloggegevens fout zijn.
                    MessageBox.Show("Verkeerde gebruikersnaam en/of wachtwoord", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
           
        }
    }
}
