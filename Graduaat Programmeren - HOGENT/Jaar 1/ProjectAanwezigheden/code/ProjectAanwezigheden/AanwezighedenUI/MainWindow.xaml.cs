using AanwezighedenBL.DTO;
using AanwezighedenBL.Manager;
using AanwezighedenDL_SQL;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AanwezighedenUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string CSgertjan = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=Aanwezigheden;Integrated Security=True;Trust Server Certificate=True";
        string CStiago = @"Data Source=LAPTOP-I33SVT0O\SQLEXPRESS;Initial Catalog=Aanwezigheden;Integrated Security=True;Trust Server Certificate=True";
        string CSsteve = @"Data Source=LAPTOP-LE0HU5AN\sqlexpress;Initial Catalog=Aanwezigheden;Integrated Security=True;Trust Server Certificate=True";
        string CSrune = @"Data Source=RUNE\sqlexpress;Initial Catalog=Aanwezigheden;Integrated Security=True;Trust Server Certificate=True";
        AanwezighedenRepo repo;
        AanwezighedenManager manager;
        public MainWindow()
        {
            InitializeComponent();
            string connectionString = CStiago;
            repo = new AanwezighedenRepo(connectionString);
            manager = new AanwezighedenManager(repo);
            List<EvenementDTO> evenementen = manager.GetEvenementen();
            ListBoxEvenementen.ItemsSource = evenementen;
        }

        private void Button_Click_Filter(object sender, RoutedEventArgs e)
        {
            string input = TextBoxInput.Text;
            bool IsOpNaam;
            if ((bool)RBNaam.IsChecked)
            {
                IsOpNaam = true;
            }
            else
            {
                IsOpNaam = false;
                if (!IsValidDateFormat(input))
                {
                    System.Windows.MessageBox.Show("Je moet een geldige datum invullen. (jjjj-mm-dd)", "Geen geldige invoer", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            List<EvenementDTO> evenementen = manager.GetEvenementen(input, IsOpNaam);
            ListBoxEvenementen.ItemsSource = evenementen;
        }



        static bool IsValidDateFormat(string date)
        {
            // Regex voor jjjj-mm-dd
            string pattern = @"^\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01])$";

            // Controleer of de string overeenkomt met het patroon
            if (Regex.IsMatch(date, pattern))
            {
                // Verdeel de string in jaar, maand en dag
                string[] parts = date.Split('-');
                int year = int.Parse(parts[0]);
                int month = int.Parse(parts[1]);
                int day = int.Parse(parts[2]);

                // Controleer of de maand tussen 1 en 12 is en de dag geldig is voor de maand
                if (month >= 1 && month <= 12)
                {
                    // Controleer het aantal dagen in de maand
                    int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

                    // Controleer op schrikkeljaar
                    if (DateTime.IsLeapYear(year))
                    {
                        daysInMonth[1] = 29; // Februari heeft 29 dagen in een schrikkeljaar
                    }

                    // Controleer of de dag geldig is voor de maand
                    if (day >= 1 && day <= daysInMonth[month - 1])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void ListBoxEvenementen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EvenementDTO selectedEvenement = (EvenementDTO)ListBoxEvenementen.SelectedItem;
            EvenementWindow window = new EvenementWindow(selectedEvenement.Id);
            window.Show();
        }
    }
}