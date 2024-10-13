using AanwezighedenBL.DTO;
using AanwezighedenBL.Manager;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace AanwezighedenUI {
    public partial class GroepWindow : Window {
        private int evenementId;
        private int groepId;
        private AanwezighedenManager manager;

        public ObservableCollection<GebruikerDTO> Leden { get; set; }
        public string Naam { get; set; }

        public GroepWindow(string groepNaam, int evenementId, int groepId, List<GebruikerDTO> gebruikers, AanwezighedenManager manager) {
            InitializeComponent();
            Naam = groepNaam;
            Leden = new ObservableCollection<GebruikerDTO>(gebruikers);
            this.evenementId = evenementId;
            this.groepId = groepId;
            this.manager = manager;
            DataContext = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            StringBuilder sb = new StringBuilder();
            foreach (var lid in Leden) {
                if (lid.IsAanwezig) {
                    lid.Reden = null; 
                }
                sb.AppendLine($"Naam: {lid.Naam}, Familienaam: {lid.Familienaam}, Email: {lid.Email}, " +
                              $"IsAanwezig: {lid.IsAanwezig}, Reden: {lid.Reden}");
            }

            

            
            manager.UpdateAanwezigheid(evenementId, groepId, Leden.ToList());

            
            MessageBox.Show("Gegevens opgeslagen!");

            EvenementWindow evenement = new EvenementWindow(evenementId);
            evenement.Show();
            this.Close();
        }

    }
}
