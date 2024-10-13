using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using TuinCentrumBL.Interfaces;
using TuinCentrumBL.Model;

namespace TuinCentrumDL_File
{
    public class FileProcessor : IFileProcessor
    {
        public List<Klant> klanten = new List<Klant>();
        public List<Product> producten = new List<Product>();
        public List<Offerte> offertes = new List<Offerte>();


        List<Klant> IFileProcessor.LeesKlant(string fileName)
        {
            try
            {
                String[] data = null;
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        data = line.Split("|");

                        int id;
                        int.TryParse(data[0], out id);
                        string naam = data[1];
                        string adres = data[2];

                        Klant klant = new Klant(id, naam, adres);
                        klanten.Add(klant);

                    }
                }
                return klanten;
            }
            catch (Exception ex) { throw new Exception($"FileProcessor.leesKlanten - {fileName}", ex); }
        }
        List<Product> IFileProcessor.LeesProduct(string fileName)
        {
            try
            {
                String[] data = null;
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        data = line.Split("|");

                        int id;
                        int.TryParse(data[0], out id);
                        string nednaam = data[1];
                        string wetNaam = data[2];
                        double prijs;
                        double.TryParse(data[3], out prijs);
                        string beschrijving = data[4];

                        Product product = new Product(id, nednaam, wetNaam,prijs,beschrijving);
                        producten.Add(product);

                    }
                }
                return producten;
            }
            catch (Exception ex) { throw new Exception($"FileProcessor.leesProducten - {fileName}", ex); }
        }
        public List<Offerte> LeesOfferte(string fileName, string filename2)
        {
            Dictionary<int, List<Tuple<Product, int>>> offerteProducten = new Dictionary<int, List<Tuple<Product, int>>>();

            try
            {
                String[] data = null;
                String[] data2 = null;

                // Lees het tweede bestand in en sla de data op in een Dictionary
                using (StreamReader sr2 = new StreamReader(filename2))
                {
                    string line2;
                    while ((line2 = sr2.ReadLine()) != null)
                    {
                        data2 = line2.Split("|");
                        int offerteid;
                        int.TryParse(data2[0], out offerteid);
                        int productID;
                        int.TryParse(data2[1], out productID);
                        Product product = producten[productID];
                        int aantalP;
                        int.TryParse(data2[2], out aantalP);

                        if (!offerteProducten.ContainsKey(offerteid))
                        {
                            offerteProducten[offerteid] = new List<Tuple<Product, int>>();
                        }
                        offerteProducten[offerteid].Add(new Tuple<Product, int>(product, aantalP));
                    }
                }

                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        data = line.Split("|");

                        int id;
                        int.TryParse(data[0], out id);
                        string datumString = data[1];
                        DateTime datum = DateTime.Parse(datumString);
                        int klantnummer;
                        int.TryParse(data[2], out klantnummer);
                        Klant klant = klanten[klantnummer];
                        string afhaaltekst = data[3];
                        bool afhaal = !afhaaltekst.ToLower().Equals("false");
                        string aanlegtekst = data[4];
                        bool aanleg = !aanlegtekst.ToLower().Equals("false");
                        int aantal;
                        int.TryParse(data[5], out aantal);
                        double prijs = 0.0;

                        Offerte offerte = new Offerte(id, datum, klant, afhaal, aanleg, aantal, prijs);

                        // Voeg producten toe aan de offerte
                        if (offerteProducten.ContainsKey(offerte.ID))
                        {
                            foreach (Tuple<Product,int> productinfo in offerteProducten[id])
                            {
                              offerte.voegProductToe(productinfo.Item1,productinfo.Item2);
                            }
                        }

                        offertes.Add(offerte);
                    }
                    return offertes;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"FileProcessor.leesOfferte - {fileName}", ex);
            }
        }

    }
}