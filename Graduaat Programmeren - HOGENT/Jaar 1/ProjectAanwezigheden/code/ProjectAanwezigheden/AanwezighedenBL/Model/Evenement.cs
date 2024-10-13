using AanwezighedenBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AanwezighedenBL.Model
{
    public class Evenement
    {
        public int Id { get; set; }

        private DateTime datum;

        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }

        private TimeSpan starttijd;

        public TimeSpan Starttijd
        {
            get { return starttijd; }
            set { if (value == eindtijd) throw new DomeinException("starttijd is gelijk aan eindtijd"); starttijd = value; }
        }

        private TimeSpan eindtijd;
        public TimeSpan Eindtijd
        {
            get { return eindtijd; }
            set { if (starttijd == value) throw new DomeinException("eindtijd is gelijk aan starttijd"); eindtijd = value; }
        }

        private string plaats;
        public string Plaats
        {
            get { return plaats; }
            set { if (string.IsNullOrWhiteSpace(value)) throw new DomeinException("Plaatsnaam niet correct"); plaats = value; }
        }

        private string naam;
        public string Naam
        {
            get { return naam; }
            set { if (string.IsNullOrWhiteSpace(value)) throw new DomeinException("Evenement_naam niet correct"); naam = value; }
        }


        public Dictionary<int, Groep> AanwezigeGroepen = new Dictionary<int, Groep>();

        public Evenement(int id, DateTime datum, TimeSpan starttijd, TimeSpan eindtijd, string plaats, string naam)
        {
            Id = id;
            Datum = datum;
            Starttijd = starttijd;
            Eindtijd = eindtijd;
            Plaats = plaats;
            Naam = naam;
        }

        public void VoegGroepToe(Groep groep)
        {
            if (groep == null)
            {
                throw new DomeinException("Groep is null");
            }
            if (AanwezigeGroepen.ContainsKey(groep.Id))
            {
                throw new DomeinException("Groep zit al in de lijst");
            }
            else
            {
                AanwezigeGroepen.Add(groep.Id,groep);
            }
        }

        public void VerwijderGroep(Groep groep)
        {
            if (groep == null)
            {
                throw new DomeinException("Groep is null");
            }
            if (!AanwezigeGroepen.ContainsKey(groep.Id))
            {
                throw new DomeinException("Groep zit niet in de lijst");
            }
            else
            {
                AanwezigeGroepen.Remove(groep.Id);
            }
        }


    }
}
