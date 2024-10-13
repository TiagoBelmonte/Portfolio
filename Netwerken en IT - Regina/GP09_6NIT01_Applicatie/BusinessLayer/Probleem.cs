using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Probleem
    {
        //Initialiseren van de velden van de klasse Probleem.
        private int _probleemId;
        private int _werknemerId;
        private string _toestel;
        private string _omschrijving;
        private string _plaats;
        private string _status;
        private string _itCoordinator; // Hier bewaren we de naam van de itCoordinator dat aan het probleem heeft gewerkt.
        private DateTime _datum;
        private List<Probleem> _problemen;

        //Constructor van de klasse Probleem.
        public Probleem(int werknemerId, string toestel, string omschrijving, string plaats)
        {
            
            _werknemerId = werknemerId;
            _toestel = toestel;
            _omschrijving = omschrijving;
            _plaats = plaats;
            _status = "niet gestart";
            _itCoordinator = "";
            _datum = DateTime.Now;
            _problemen = new List<Probleem>();
        }
        //Tweede constructor van de klasse Probleem waarbij alle parameters aanwezig zijn.
        public Probleem(int probleemId, int Werknemer, string toestel, string omschrijving, string plaats, 
                        string status, string ITcoordinator, DateTime datum)

        {
            _probleemId = probleemId;
            _werknemerId = Werknemer;
            _toestel = toestel;
            _omschrijving = omschrijving;
            _plaats = plaats;
            _status = status;
            _itCoordinator = ITcoordinator;
            _datum = datum;
        }

        //Properties van de verschillende velden.

        public int ProbleemId
        {
            get { return _probleemId; }
        }

        public int WerknemerId
        {
            get { return _werknemerId; }
        }

        public String Toestel
        {
            get { return _toestel; }
            set { _toestel = value; }
        }

        public String Omschrijving
        {
            get { return _omschrijving; }
            set { _omschrijving = value; }
        }

        public String Plaats
        {
            get { return _plaats; }
            set { _plaats = value; }
        }
        public String Status
        {
            get { return _status; }
            set { _status = value; }
        }
        public String ItCoordinator
        {
            get { return _itCoordinator; }
        }
        public DateTime Datum
        {
            get { return _datum; }
        }

        //We scrijven hier de methode toString over zodat er op ons listbox de probleemId met de omschrijving komt te staan ipv de volledige variabele.
        public override string ToString()
        {
            return ProbleemId + " " + Omschrijving;
        }
    }
}
