using AanwezighedenBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace AanwezighedenBL.Model
{
    public class Groep
    {

        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                if (value < 0)
                    throw new DomeinException("Exception Groep Id");
                id = value;
            }
        }

        private string naam;
        public string Naam
        {
            get { return naam; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new DomeinException("Exception Groep Naam");
                naam = value;
            }
        }

        public Dictionary<int, Gebruiker> Leden = new Dictionary<int, Gebruiker>();

        public Groep(int id, string naam)
        {
            Id = id;
            Naam = naam;
        }

        public void VoegLidToe(Gebruiker gebruiker)
        {
            Leden.Add(gebruiker.Id,gebruiker);
            gebruiker.HuidigeGroep = this;
        }

        public void VerwijderLid(Gebruiker gebruiker)
        {
            Leden.Remove(gebruiker.Id);
            gebruiker.HuidigeGroep = null;
        }

        public override bool Equals(object? obj)
        {
            return obj is Groep groep &&
                   Id == groep.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            return $"{Naam} - aantal ledel: {Leden.Count()}";
        }
    }


}
