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
    /// Interaction logic for NieuwProbleem.xaml
    /// </summary>
    public partial class NieuwProbleem : Window
    {
        //klassevelden aanmaken
        Probleem _nieuwProbleem;
        ProbleemDA _probleemDA;
        Probleem _probleem;
        
        public NieuwProbleem(Probleem probleem)
        {
            //Hieronder initialiseren we alle objecten dat zienbaar zijn op ons venster.
            InitializeComponent();
            
            //klassevelden initialiseren
            _probleemDA = new ProbleemDA();
            _probleem = probleem;
        }

        //als de gebruiker op de knop aanmaken drukt zal er een nieuwe probleem aangemaakt worden met de gegevens dat hij ingevuld heeft in de textboxen
        private void ButtonAanmaken_Click(object sender, RoutedEventArgs e)
        {
            _nieuwProbleem = new Probleem(Convert.ToInt32(textboxProbleemId.Text), Convert.ToInt32(TextBoxWerknemerId), TextBoxToestel.Text, TextBoxOmschrijving.Text, TextBoxPlaats.Text, textboxStatus.Text, textboxItCoordinator.Text, Convert.ToDateTime(textboxDatum.Text));

            _probleemDA.NieuwProbleem(_nieuwProbleem);
        }

        //Als de gebruiker op de knop annuleren drukt zal hij terug naar het vorige venster gaan.
        private void ButtonAnuleren_Click(object sender, RoutedEventArgs e)
        {
            //Dit venster afsluiten.
            this.Close();
        }

        //Als hij op de knop wijziggen druk zal hij de gegevens wijzigen van de geselecteerde probleem.
        private void ButtonWijzigen_Click(object sender, RoutedEventArgs e)
        {
            _probleemDA.ProbleemWijzigen(_probleem);
        }
    }
}
