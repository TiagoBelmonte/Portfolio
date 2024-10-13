using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Werknemer
    {
        //Initialiseren van velden.
        private int _werknemerID;
        private string _naam;
        private string _telefoonnummer;
        private string _email;
        private string _wachtwoord;
        //Hier zien we of de werknemer een itcoordinator is of niet. 1 = wel, 0 = niet.
        private int _itCoordinator; 

        //Constructor van de klasse Werknemer.
        public Werknemer(int werknemerID, string naam, string telefoonnummer, string email, string wachtwoord, int itCoordinator)
        {
            _werknemerID = werknemerID;
            _naam = naam;
            _telefoonnummer = telefoonnummer;
            _email = email;
            _wachtwoord = wachtwoord;
            //Hier bewaren we de id van de itCoordinator en niet zijn naam zoals bij probleem.cs.
            _itCoordinator = itCoordinator;
        }

        //Properties van de verschillende velden.
        //Met een get-statement krijg je de waarde van het veld terug.
        //Met een set-statement kan je de waarde van het veld veranderen door de meegegeven waarde.
        public int WerknemerID
        {
            get { return _werknemerID; }
        }

        public String Naam
        {
            get { return _naam; }
        }

        public String Telefoon
        {
            get { return _telefoonnummer; }
            set { _telefoonnummer = value; }
        }

        public String Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public String Wachtwoord
        {
            get { return _wachtwoord; }
            set { _wachtwoord = value; }
        }

        public int ItCoordinator
        {
            get { return _itCoordinator; }
        }

    }
}
