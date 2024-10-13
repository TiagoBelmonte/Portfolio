using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TuinCentrumBL.Exceptions;
using TuinCentrumBL.Model;
using Xunit;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TuinCentrumUnitTesten
{
    public class UnitTestOfferte
    {

        [Fact]
        public void TestOfferteAanmakenConstr1Valid()
        {
            Klant klant = new Klant(1, "Jan Janssen", "Aalterstraat 17");
            Product product = new Product(1, "Iris", "Iris Germanica", 10.99, "Een mooie bloem");

            Offerte offerte = new Offerte(1, DateTime.Now, klant, false, false, 1);
            offerte.voegProductToe(product, 1);
            offerte.Prijs = offerte.BerekenPrijs();

            Xunit.Assert.Equal(1, offerte.ID);
            Xunit.Assert.Equal(DateTime.Now.Date, offerte.Datum.Date);
            Xunit.Assert.Equal(klant, klant);
            Xunit.Assert.True(!offerte.leveren);
            Xunit.Assert.False(offerte.Aanleg);
            Xunit.Assert.Equal(1, offerte.Producten.Count);
            Xunit.Assert.Equal(10.99, offerte.Prijs);
        }

        [Fact]
        public void TestOfferteAanmakenConstr2Valid()
        {
            Klant klant = new Klant(1, "Jan Janssen", "Aalterstraat 17");
            Product product = new Product(1, "Iris", "Iris Germanica", 10.99, "Een mooie bloem");

            Offerte offerte = new Offerte(1, DateTime.Now, klant, false, false, 1);
            offerte.voegProductToe(product, 1);
            offerte.Prijs = offerte.BerekenPrijs();

            Xunit.Assert.Equal(1, offerte.ID);
            Xunit.Assert.Equal(DateTime.Now.Date, offerte.Datum.Date);
            Xunit.Assert.Equal(klant, klant);
            Xunit.Assert.True(!offerte.leveren);
            Xunit.Assert.False(offerte.Aanleg);
            Xunit.Assert.Equal(1, offerte.Producten.Count);
            Xunit.Assert.Equal(10.99, offerte.Prijs);
        }

        [Fact]
        public void TestOfferteAanmakenConstr3Valid()
        {
            Klant klant = new Klant(1, "Jan Janssen", "Aalterstraat 17");
            Product product = new Product(1, "Iris", "Iris Germanica", 10, "Een mooie bloem");
            Dictionary<Product, int> kvp = new Dictionary<Product, int>();
            kvp.Add(product, 5);
            Offerte offerte = new Offerte(1, DateTime.Now, klant, false, false, 1,0,kvp);

            offerte.Prijs = offerte.BerekenPrijs();

            Xunit.Assert.Equal(1, offerte.ID);
            Xunit.Assert.Equal(DateTime.Now.Date, offerte.Datum.Date);
            Xunit.Assert.Equal(klant, klant);
            Xunit.Assert.True(!offerte.leveren);
            Xunit.Assert.False(offerte.Aanleg);
            Xunit.Assert.Equal(1, offerte.Producten.Count);
            Xunit.Assert.Equal(50, offerte.Prijs);
            Xunit.Assert.Equal(1, offerte.Producten.Count);
            Xunit.Assert.Equal(5, offerte.Producten[product]);
        }

        [Fact]
        public void TestOfferteAanmakenInvalidId()
        {
            Klant klant = new Klant(1, "Jan Janssen", "Aalterstraat 17");
            Product product = new Product(1, "Iris", "Iris Germanica", 10.99, "Een mooie bloem");

            Xunit.Assert.Throws<DomeinException>(() => new Offerte(0, DateTime.Now, klant, true, false, 1));
            Xunit.Assert.Throws<DomeinException>(() => new Offerte(-1, DateTime.Now, klant, true, false, 1));
        }

        [Fact]
        public void TestOfferteAanmakenConstr2InvalidId()
        {
            Klant klant = new Klant(1, "Jan Janssen", "Aalterstraat 17");
            Product product = new Product(1, "Iris", "Iris Germanica", 10.99, "Een mooie bloem");

            Xunit.Assert.Throws<DomeinException>(() => new Offerte(0, DateTime.Now, klant, true, false, 1, product.Prijs));
            Xunit.Assert.Throws<DomeinException>(() => new Offerte(-1, DateTime.Now, klant, true, false, 1, product.Prijs));
        }

        [Fact]
        public void TestOfferteAanmakenConstr3InvalidId()
        {
            Klant klant = new Klant(1, "Jan Janssen", "Aalterstraat 17");
            Product product = new Product(1, "Iris", "Iris Germanica", 10, "Een mooie bloem");
            Dictionary<Product, int> kvp = new Dictionary<Product, int>();
            kvp.Add(product, 5);
            Xunit.Assert.Throws<DomeinException>(() => new Offerte(0, DateTime.Now, klant, true, false, 1,0,kvp));
            Xunit.Assert.Throws<DomeinException>(() => new Offerte(-1, DateTime.Now, klant, true, false, 1,0,kvp));
        }

        [Fact]
        public void TestOfferteAanmakenInvalidDatum()
        {
            Klant klant = new Klant(1, "Jan Janssen", "Aalterstraat 17");
            Product product = new Product(1, "Iris", "Iris Germanica", 10.99, "Een mooie bloem");

            Xunit.Assert.Throws<DomeinException>(() => new Offerte(1, DateTime.Now.AddDays(1), klant, true, false, 1));
        }

        [Fact]
        public void TestOfferteAanmakenInvalidKlant()
        {
            Xunit.Assert.Throws<DomeinException>(() => new Offerte(1, DateTime.Now,null, true, false, 1));
        }

        [Fact]
        public void TestOfferteAanmakenInvalidAantalProducten()
        {
            var klant = new Klant(1, "Jan Janssen", "Aalterstraat 17");

            Xunit.Assert.Throws<DomeinException>(() => new Offerte(1, DateTime.Now, klant, true, false, -1));
        }

        [Fact]
        public void TestSetDatumValid()
        {
            Klant klant = new Klant(1, "Jan Janssen", "Stationsstraat 1");
            Offerte offerte = new Offerte(1, DateTime.Now, klant, true, false, 1);
            DateTime nieuweDatum = DateTime.Parse("2023-12-12");
            offerte.Datum = nieuweDatum;
            Xunit.Assert.Equal(nieuweDatum.Date, offerte.Datum.Date);
        }

        [Fact]
        public void TestSetDatumInValid()
        {
            Klant klant = new Klant(1, "Jan Janssen", "Stationsstraat 1");
            Offerte offerte = new Offerte(1, DateTime.Now, klant, true, false, 1);
            DateTime nieuweDatum = DateTime.Now.AddDays(1);
            Xunit.Assert.Throws<DomeinException>(() => offerte.Datum = nieuweDatum);
        }

        [Fact]
        public void TestSetKlantValid()
        {
            Klant klant1 = new Klant(1, "Jan Janssen", "Stationsstraat 1");
            Klant klant2 = new Klant(1, "Piet Pietersen", "Kerkstraat 2");
            Offerte offerte = new Offerte(1, DateTime.Now, klant1, true, false, 1);
            offerte.Klant = klant2;
            Xunit.Assert.Equal(klant2, klant2);
        }

        [Fact]
        public void TestSetAfhaalValid()
        {
            Klant klant = new Klant(1, "Jan Janssen", "Stationsstraat 1");
            Offerte offerte = new Offerte(1, DateTime.Now, klant, true, false, 1);
            offerte.leveren = false;
            Xunit.Assert.False(offerte.leveren);
        }

        [Fact]
        public void TestSetAanlegValid()
        {
            Klant klant = new Klant(1, "Jan Janssen", "Stationsstraat 1");
            Offerte offerte = new Offerte(1, DateTime.Now, klant, true, false, 1);
            offerte.Aanleg = true;
            Xunit.Assert.True(offerte.Aanleg);
        }

        [Fact]
        public void TestVoegProductToeValid()
        {
            Klant klant = new Klant(1, "Jan Janssen", "Stationsstraat 1");
            Product product = new Product(1, "Iris", "Iris Germanica", 10.99, "Een mooie bloem");
            Product product2 = new Product(2, "Roos", "Rosa", 55, "Een mindere bloem");

            Offerte offerte = new Offerte(1, DateTime.Now, klant, true, false, 0);
            offerte.voegProductToe(product, 1);
            Xunit.Assert.Equal(1, offerte.Producten.Keys.Count());
            Xunit.Assert.Contains(product, offerte.Producten.Keys);


            offerte.voegProductToe(product, 2);

            Xunit.Assert.Equal(3, offerte.Producten[product]);
            Xunit.Assert.Equal(1, offerte.Producten.Keys.Count());

            offerte.voegProductToe(product2, 2);
            Xunit.Assert.Equal(2, offerte.Producten.Keys.Count());
            Xunit.Assert.Contains(product, offerte.Producten.Keys);
            Xunit.Assert.Contains(product2, offerte.Producten.Keys);
            Xunit.Assert.Equal(3, offerte.Producten[product]);
            Xunit.Assert.Equal(2, offerte.Producten[product2]);
            Xunit.Assert.Equal(2, offerte.Producten.Count);

        }

        [Fact]
        public void TestVoegProductToeInValid()
        {
            Klant klant = new Klant(1, "Jan Janssen", "Stationsstraat 1");
            Product product = new Product(1, "Iris", "Iris Germanica", 10.99, "Een mooie bloem");
            Offerte offerte = new Offerte(1, DateTime.Now, klant, true, false, 0);
            Xunit.Assert.Throws<DomeinException>(() => offerte.voegProductToe(product, 0));
            Xunit.Assert.Throws<DomeinException>(() => offerte.voegProductToe(null, 7));
            Xunit.Assert.Throws<DomeinException>(() => offerte.voegProductToe(null, -5));
        }

        [Fact]
        public void TestVerwijderProduct()
        {
            Klant klant = new Klant(1, "Jan Janssen", "Stationsstraat 1");
            Product product = new Product(1, "Iris", "Iris Germanica", 10.99, "Een mooie bloem");
            Offerte offerte = new Offerte(1, DateTime.Now, klant, true, false, 0);
            offerte.voegProductToe(product, 1);
            offerte.verwijderProduct(1, product);
            Xunit.Assert.Equal(0, offerte.Producten.Keys.Count());
        }

        [Fact]
        public void TestVerwijderProductInValid()
        {
            Klant klant = new Klant(1, "Jan Janssen", "Stationsstraat 1");
            Product product = new Product(1, "Iris", "Iris Germanica", 10.99, "Een mooie bloem");
            Product product2 = new Product(2, "Roos", "Rosa", 55, "Een mindere bloem");

            Offerte offerte = new Offerte(1, DateTime.Now, klant, true, false, 0);
            Xunit.Assert.Throws<DomeinException>(() => offerte.verwijderProduct(0, product));
            Xunit.Assert.Throws<DomeinException>(() => offerte.verwijderProduct(5, product));
            Xunit.Assert.Throws<DomeinException>(() => offerte.verwijderProduct(5, null));
            Xunit.Assert.Throws<DomeinException>(() => offerte.verwijderProduct(1, product2));
            Xunit.Assert.Throws<DomeinException>(() => offerte.verwijderProduct(0, null));
        }




        [Fact]
        public void TestBerekenPrijsKleinerDan2000()
        {

            Klant klant = new Klant(1, "Jan Janssen", "Stationsstraat 1");
            Product product = new Product(1, "Iris", "Iris Germanica", 10, "Een mooie bloem");
            var offerte = new Offerte(1, DateTime.Now, klant, false, false, 1);
            offerte.voegProductToe(product, 1);

            double prijs = offerte.BerekenPrijs();

            // Xunit.Assert
            Xunit.Assert.Equal(10, prijs);
        }

        [Fact]
        public void TestBerekenPrijsKleinerDan5000()
        {

            Klant klant = new Klant(1, "Jan Janssen", "Stationsstraat 1");
            Product product = new Product(1, "Iris", "Iris Germanica", 2500, "Een mooie bloem");
            var offerte = new Offerte(1, DateTime.Now, klant, true, false, 1);
            offerte.voegProductToe(product, 1);
            double prijs = offerte.BerekenPrijs();
            Xunit.Assert.Equal(2375, prijs);
        }

        [Fact]
        public void TestBerekenPrijsZonderAfhaalOnder500()
        {

            Klant klant = new Klant(1, "Jan Janssen", "Stationsstraat 1");
            Product product = new Product(1, "Iris", "Iris Germanica", 10, "Een mooie bloem");
            var offerte = new Offerte(1, DateTime.Now, klant, true, false, 1);
            offerte.voegProductToe(product, 1);
            double prijs = offerte.BerekenPrijs();
            Xunit.Assert.Equal(110, prijs);
        }

        [Fact]
        public void TestBerekenPrijsZonderAfhaalOnder1000()
        {

            Klant klant = new Klant(1, "Jan Janssen", "Stationsstraat 1");
            Product product = new Product(1, "Iris", "Iris Germanica", 500, "Een mooie bloem");
            var offerte = new Offerte(1, DateTime.Now, klant, true, false, 1);
            offerte.voegProductToe(product, 1);
            double prijs = offerte.BerekenPrijs();
            Xunit.Assert.Equal(550, prijs);
        }

        [Fact]
        public void TestBerekenPrijsZonderAfhaalBoven1000()
        {

            Klant klant = new Klant(1, "Jan Janssen", "Stationsstraat 1");
            Product product = new Product(1, "Iris", "Iris Germanica", 1100, "Een mooie bloem");
            var offerte = new Offerte(1, DateTime.Now, klant, false, false, 1);
            offerte.voegProductToe(product, 1);
            double prijs = offerte.BerekenPrijs();
            Xunit.Assert.Equal(1100, prijs);
        }
        [Fact]
        public void TestBerekenPrijsMetAanlegOnder2000()
        {

            Klant klant = new Klant(1, "Jan Janssen", "Stationsstraat 1");
            Product product = new Product(1, "Iris", "Iris Germanica", 10, "Een mooie bloem");
            var offerte = new Offerte(1, DateTime.Now, klant, true, true, 1);
            offerte.voegProductToe(product, 1);
            double prijs = offerte.BerekenPrijs();
            Xunit.Assert.Equal(126.5, prijs);
        }

        [Fact]
        public void TestBerekenPrijsMetAanlegOnder5000()
        {

            Klant klant = new Klant(1, "Jan Janssen", "Stationsstraat 1");
            Product product = new Product(1, "Iris", "Iris Germanica", 2500, "Een mooie bloem");
            var offerte = new Offerte(1, DateTime.Now, klant, true, true, 1);
            offerte.voegProductToe(product, 1);
            double prijs = offerte.BerekenPrijs();
            Xunit.Assert.Equal(2612.5, prijs);
        }

        [Fact]
        public void TestBerekenPrijsMetAanlegBoven5000()
        {

            Klant klant = new Klant(1, "Jan Janssen", "Stationsstraat 1");
            Product product = new Product(1, "Iris", "Iris Germanica", 5500, "Een mooie bloem");
            var offerte = new Offerte(1, DateTime.Now, klant, true, true, 1);
            offerte.voegProductToe(product, 1);
            double prijs = offerte.BerekenPrijs();
            Xunit.Assert.Equal(5445, prijs);
        }
    }
}
