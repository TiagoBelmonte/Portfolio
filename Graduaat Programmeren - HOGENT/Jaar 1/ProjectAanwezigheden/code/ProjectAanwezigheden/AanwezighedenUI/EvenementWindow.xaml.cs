using AanwezighedenBL.DTO;
using AanwezighedenBL.Manager;
using AanwezighedenBL.Model;
using AanwezighedenDL_SQL;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AanwezighedenUI {
    /// <summary>
    /// Interaction logic for EvenementWindow.xaml
    /// </summary>
    public partial class EvenementWindow : Window {
        string CSgertjan = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=Aanwezigheden;Integrated Security=True;Trust Server Certificate=True";
        string CStiago = @"Data Source=LAPTOP-I33SVT0O\SQLEXPRESS;Initial Catalog=Aanwezigheden;Integrated Security=True;Trust Server Certificate=True";
        string CSsteve = @"Data Source=LAPTOP-LE0HU5AN\sqlexpress;Initial Catalog=Aanwezigheden;Integrated Security=True;Trust Server Certificate=True";
        string CSrune = @"Data Source=RUNE\sqlexpress;Initial Catalog=Aanwezigheden;Integrated Security=True;Trust Server Certificate=True";
        AanwezighedenRepo repo;
        AanwezighedenManager manager;
        Evenement evenement;
        List<Groep> nietGaandeGroepen;

        public EvenementWindow(int evenementId) {
            InitializeComponent();
            string connectionString = CStiago;
            repo = new AanwezighedenRepo(connectionString);
            manager = new AanwezighedenManager(repo);
            evenement = manager.GetEvenement(evenementId);  
            TextBoxEvenementNaam.Text = evenement.Naam;
            TextBoxDatum.Text = evenement.Datum.ToString("yyyy-MM-dd");
            TextBoxPlaats.Text = evenement.Plaats;
            TextBoxStarttijd.Text = evenement.Starttijd.ToString();
            TextBoxEindtijd.Text = evenement.Eindtijd.ToString();
            ListBoxIngeschrevenGroepen.ItemsSource = evenement.AanwezigeGroepen.Values.ToList();
            nietGaandeGroepen = manager.NietIngeschrevenGroepen(evenementId);
            ComboBoxGroepen.ItemsSource = nietGaandeGroepen;
        }

        private void ListBoxIngeschrevenGroepen_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListBoxIngeschrevenGroepen.SelectedItem is Groep geselecteerdeGroep)
            {
                List<GebruikerDTO> gebruikers = manager.GetGebruikerDetailsVoorGroep(evenement.Id, geselecteerdeGroep.Id);

                // Pass the necessary parameters including the evenementId, groepId, and the manager
                GroepWindow groepWindow = new GroepWindow(geselecteerdeGroep.Naam, evenement.Id, geselecteerdeGroep.Id, gebruikers, manager);
                groepWindow.Show();
            }
        }

        private void Button_Click_VoegGroepToe(object sender, RoutedEventArgs e)
        {
            Groep nieuweGroep = (Groep)ComboBoxGroepen.SelectedItem;
            if (nieuweGroep == null)
            {
                MessageBox.Show("Je moet eerst een groep selecteren.", "Geen groep geselecteerd!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            evenement.VoegGroepToe(nieuweGroep);
            ListBoxIngeschrevenGroepen.ItemsSource = evenement.AanwezigeGroepen.Values.ToList();
            nietGaandeGroepen.Remove(nieuweGroep);
            ComboBoxGroepen.ItemsSource = null;
            ComboBoxGroepen.ItemsSource = nietGaandeGroepen;
            manager.VoegGroepToe(nieuweGroep, evenement);
        }

        private void Button_Click_VerwijderGroep(object sender, RoutedEventArgs e)
        {            
            Groep teVerwijderenGroep = (Groep)ListBoxIngeschrevenGroepen.SelectedItem;
            if (teVerwijderenGroep == null )
            {
                MessageBox.Show("Je moet eerst een groep selecteren.","Geen groep geselecteerd!",MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            evenement.VerwijderGroep(teVerwijderenGroep);
            ListBoxIngeschrevenGroepen.ItemsSource = evenement.AanwezigeGroepen.Values.ToList();
            nietGaandeGroepen.Add(teVerwijderenGroep);
            ComboBoxGroepen.ItemsSource = null;
            ComboBoxGroepen.ItemsSource = nietGaandeGroepen;
            manager.VerwijderGroep(teVerwijderenGroep, evenement);
        }
    }
}
