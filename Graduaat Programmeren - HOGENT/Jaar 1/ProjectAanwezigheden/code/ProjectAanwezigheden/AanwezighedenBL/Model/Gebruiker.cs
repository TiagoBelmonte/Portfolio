using AanwezighedenBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace AanwezighedenBL.Model
{
    public class Gebruiker
    {
        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                if (value < 0)
                    throw new DomeinException("Exception Gebruiker Id");
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
                    throw new DomeinException("Exception Gebruiker Naam");
                naam = value;
            }
        }

        private string familienaam;

        public string Familienaam
        {
            get { return familienaam; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new DomeinException("Exception Gebruiker familienaam");
                naam = value;
            }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new DomeinException("Exception Gebruiker Email");
                email = value;
            }
        }

        private Groep? huidigeGroep;

        public Groep? HuidigeGroep
        {
            get { return huidigeGroep; }
            set
            {
                if (value == null)
                    throw new DomeinException("Exception Gebruiker HuidigeGroep");
                huidigeGroep = value;
            }
        }

        public Gebruiker(int id, string naam, string familienaam, string email)
        {
            Id = id;
            Naam = naam;
            Familienaam = familienaam;
            Email = email;
        }

        public override bool Equals(object? obj)
        {
            return obj is Gebruiker gebruiker &&
                   Id == gebruiker.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
