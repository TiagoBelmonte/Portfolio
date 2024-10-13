using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TuinCentrumBL.Exceptions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TuinCentrumBL.Model
{
    public class Offerte
    {
        private int id;
        public int ID
        {
            get { return id; }
            set
            {
                if (value <= 0)
                    throw new DomeinException($"Product.Id - {value}");
                id = value;
            }
        }

        private DateTime datum;
        public DateTime Datum
        {
            get { return datum; }
            set
            {
                if (value > DateTime.Now)
                    throw new DomeinException($"Offerte.Datum - {value}");
                datum = value;
            }
        }

        private Klant klant;
        public Klant Klant
        {
            get { return klant; }
            set
            {
                if (value == null)
                    throw new DomeinException($"Offerte.Klant - {value}");
                klant = value;
            }
        }

        public bool leveren { get; set; }
        //Aanleg(true wil zeggen dat de leverancier niet enkel de bestelling komt brengen, maar ook de aanleg van de tuin zal doen)
        public bool Aanleg { get; set; }
        //Aantal producten in de bestelling
        private int aantal;
        public int Aantal
        {
            get { return aantal; }
            set
            {
                if (value < 0)
                    throw new DomeinException($"Offerte.AantalProducten - {value}");
                aantal = value;
            }
        }

        private double prijs;
        public double Prijs
        {
            get { return prijs; }
            set { prijs = value; }
        }
        public Dictionary<Product, int> Producten { get; set; }

        public Offerte(int Id, DateTime date, Klant klant, bool af, bool aan, int aantal, double prijs)
        {
            ID = Id;
            Datum = date;
            Klant = klant;
            leveren = af;
            Aanleg = aan;
            Aantal = aantal;
            Prijs = prijs;
            Producten = new Dictionary<Product, int>();
        }

        public Offerte(int Id, DateTime date, Klant klant, bool af, bool aan, int aantal)
        {
            ID = Id;
            Datum = date;
            Klant = klant;
            leveren = af;
            Aanleg = aan;
            Aantal = aantal;
            Producten = new Dictionary<Product, int>();
        }

        public Offerte(int Id, DateTime date, Klant klant, bool af, bool aan, int aantal, double prijs, Dictionary<Product, int> producten)
        {
            ID = Id;
            Datum = date;
            Klant = klant;
            leveren = af;
            Aanleg = aan;
            Aantal = aantal;
            Prijs = prijs;
            Producten = producten;
        }
        public Offerte()
        {
            Producten = new Dictionary<Product, int>();
        }
        public void voegProductToe(Product product, int aantal)
        {
            if (aantal == 0 || product == null)
            {
                throw new DomeinException($"Offerte.VoegProductToe");
            }
            else
            {
                if (Producten.ContainsKey(product))
                {
                    Producten[product] += aantal;
                }
                else
                {
                    Producten.Add(product, aantal);
                }
            }
        }

        
        public void verwijderProduct(int aantal, Product product)
        {

            if (aantal == 0 || product == null)
            {
                throw new DomeinException($"Offerte.VoegProductToe");
            }
            else
            {
                if (!Producten.ContainsKey(product))
                {
                    throw new DomeinException("het product is niet aanwezig in de offerte");
                }
                else
                {
                    Producten.Remove(product);
                }
            }
        }

        public double BerekenPrijs()
        {
            double totalePrijs = 0;


            foreach (Product product in Producten.Keys)
            {

                totalePrijs += product.Prijs * Producten[product];
            }

            double korting = 0;
            if (totalePrijs > 5000)
            {
                korting = 0.10;
                totalePrijs -= totalePrijs * korting;
            }
            else if (totalePrijs > 2000)
            {
                korting = 0.05;
                totalePrijs -= totalePrijs * korting;
            }


            // Bereken leveringskosten
            if (leveren)
            {
                if (totalePrijs < 500)
                {
                    totalePrijs += 100;
                }
                else if (totalePrijs < 1000)
                {
                    totalePrijs += 50;
                }
            }

            // Bereken aanlegkosten
            if (Aanleg)
            {
                double aanlegKost = 0;
                if (totalePrijs > 5000)
                {
                    aanlegKost = 0.05;
                }
                else if (totalePrijs > 2000)
                {
                    aanlegKost = 0.10;
                }
                else
                {
                    aanlegKost = 0.15;
                }
                totalePrijs += totalePrijs * aanlegKost;
            }

            return totalePrijs;
        }
        public override string ToString()
        {
            return $"OfferteID: {ID}, prijs: {prijs}EUR";
        }
    }
}

    
