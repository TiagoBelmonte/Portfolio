using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuinCentrumBL.Model;

namespace TuinCentrumBL.Interfaces
{
    public interface ITuincentrumRepository
    {
        bool HeeftKlant(string klant);
        bool HeeftKlantID(int id);
        bool HeeftProduct(Product product);
        Klant LeesKlantViaNaam(string naam);
        Klant LeesKlantViaID(int id);
        void SchrijfKlant(Klant klant);
        void SchrijfProduct(Product product);
        List<Product> GeefProducten();
        List<Klant> GeefKlanten();
        void schrijfOfferte(Offerte offerte);
        Product GeefProductViaID(int id);
        Offerte GeefOfferteViaID(int id);
        List<Offerte> GeefOffertes();
        void UpdateOfferteInDatabase(Offerte offerte);
        List<Offerte> GeefOfferteViaKlantID(int id);
        List<Offerte> GeefOffertesViaDatum(DateTime datum);
        void UpdateOfferte(Offerte offerte, Dictionary<Product, int> NieuweProducten, Dictionary<Product, int> VerwijderdProducten);

        int geefMaxOfferteID();
    }
}
