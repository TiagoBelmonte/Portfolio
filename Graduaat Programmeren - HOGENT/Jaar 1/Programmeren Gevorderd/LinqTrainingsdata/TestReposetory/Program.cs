using LinqBL.Model;
using LinqDL_File;
using System;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace TestReposetory
{
    internal class Program
    {
        private FileProcessor processor;


        static void Main(string[] args)
        {
            FileProcessor processor = new FileProcessor();
            string fileName = @"C:\Users\tbelm\Downloads\CyclingData.txt";
            Console.WriteLine("Hello, World!");
            processor.LeesTraining(fileName);
            List<Training> trainingen = processor.getTrainingen();


            //vraag01(trainingen);
            //vraag02(trainingen);
            //vraag03(trainingen);
            //vraag04(trainingen);
            vraag05(trainingen);
            //vraag06(trainingen);
            //vraag07(trainingen);
            //vraag08(trainingen);


        }
        public static void vraag01(List<Training> trainingen)
        {
            //geef het aantal sessies weer waarbij de gemiddelde wattage kleiner is dan 125
            //en de maximum wattage groter dan 200
            int aantal = trainingen
                .Count(training => training.GemWat < 125 && training.MaxWat > 200);

            Console.WriteLine($"aantal keer dat de Gem Wat kleiner is dan 125 en de max Wat groter is dan 200 = {aantal}");
        }

        public static void vraag02(List<Training> trainingen)
        {
            //geef het aantal sessies weer waarbij de gemiddelde wattage kleiner is dan 125
            //en de maximum wattage groter dan 200
            //en die van het type interval of endurance is

            int aantal = trainingen
                .Count(training => training.GemWat < 125 && training.MaxWat > 200 &&
                                   (training.TrainingType.Equals("interval") || training.TrainingType.Equals("endurance")));

            Console.WriteLine($"aantal keer dat de Gem Wat kleiner is dan 125 en de max Wat groter is dan 200 en het type interval of endurance is = {aantal}");
        }

        public static void vraag03(List<Training> trainingen)
        {
            //geef de klanten weer die in het jaar 2021 en in de maand augustus meer dan 5 trainingsessies
            //hadden waarbij avg_watt groter was dan 350
            var gekwalificeerdeKlanten = trainingen
                .Where(training => training.DatumUur.Year == 2021 && training.DatumUur.Month == 8 && training.GemWat > 350)
                .GroupBy(t => t.Klantnummer)
                .Where(g => g.Count() > 5)
                .Select(g => g.Key);

            foreach (var klant in gekwalificeerdeKlanten)
            {
                Console.WriteLine(klant);
            }
        }

        public static void vraag04(List<Training> trainingen)
        {
            //geef het aantal trainingsessies uit het jaar 2021
            //waarbij de gemiddelde wattage kleiner is dan 100 of gemiddelde kadans kleiner dan 75
            int aantalTrainingsessies = trainingen
                .Count(training => training.DatumUur.Year == 2021 && (training.GemWat < 100 || training.GemCad < 75));

            Console.WriteLine("Aantal trainingsessies uit 2021 met gemiddelde wattage < 100 of gemiddelde kadans < 75: " + aantalTrainingsessies);
        }

        public static void vraag05(List<Training> trainingen)
        {
            //geef de drie klantennummers met de meeste trainingen op maandag (+ aantal trainingen)
            var topTrainingen = trainingen
                .Where(training => training.DatumUur.DayOfWeek == DayOfWeek.Monday)
                .GroupBy(training => training.Klantnummer)
                .OrderByDescending(g => g.Count())
                .Take(3)
                .Select(g => new { KlantNummer = g.Key, AantalTrainingen = g.Count() });

            foreach (var training1 in topTrainingen)
            {
                Console.WriteLine(training1);
            }
        }

        public static void vraag06(List<Training> trainingen)
        {
            //geef voor de verschillende zware trainingen het aantal trainingsessies weer.
            //•Een training is 'hard' als het van het type 'interval' is, meer dan 1 uur duurt en een max_watt waarde heeft > 300
            //•Een training is 'heavy' als het van het type 'endurance' is, meer dan 100 min duurt en een avg_watt groter dan 200 heeft
            //•Een training is 'short but heavy' als het van het type 'interval' is, minder dan 45 minuten duurt en een avg_watt > 250 heeft.

            int aantalHard = trainingen
                .Count(training => training.TrainingType.Equals("interval") && training.Tijdsduur > 60 && training.MaxWat > 300);
            int aantalHeavy = trainingen
                .Count(training => training.TrainingType.Equals("endurance") && training.Tijdsduur > 100 && training.MaxWat > 200);
            int aantalShort = trainingen
                .Count(training => training.TrainingType.Equals("interval") && training.Tijdsduur < 45 && training.MaxWat > 250);

            Console.WriteLine($"Aantal 'hard' trainingen: {aantalHard}");
            Console.WriteLine($"Aantal 'heavy' trainingen: {aantalHeavy}");
            Console.WriteLine($"Aantal 'short but heavy' trainingen: {aantalShort}");
        }

        public static void vraag07(List<Training> trainingen)
        {
            //Geef voor klantnummer 10 de totale trainingstijd, kortste en langse traingstijd en ook de gemiddelde trainingstijd
            //en het aantal sessies weer.
            //Rond steeds af zodat er geen cijfers na de komma zijn.

            var trainingen10 = trainingen
                .Where(training => training.Klantnummer == 10)
                .Select(training => training.Tijdsduur)
                .ToList();

            int totaleTrainingstijd = trainingen10.Sum();
            int kortsteTrainingstijd = trainingen10.Min();
            int langsteTrainingstijd = trainingen10.Max();
            int aantalSessies = trainingen10.Count();
            int gemiddeldeTrainingstijd = (int)Math.Round(trainingen10.Average());

            Console.WriteLine($"de totale trainingstijd is {totaleTrainingstijd}");
            Console.WriteLine($"de kortste trainingstijd is {kortsteTrainingstijd}");
            Console.WriteLine($"de langste trainingstijd is {langsteTrainingstijd}");
            Console.WriteLine($"de aantal sessies gelopen door klant nummer 10  is {aantalSessies}");
            Console.WriteLine($"de gemmiddelde trainingstijd is {gemiddeldeTrainingstijd}");
        }

        public static void vraag08(List<Training> trainingen)
        {
            //Geef de klant weer die een trainingssessies heeft met een gemiddelde wattage > 350 en die langer duurde dan 100 min
            //en waarbij het verschil tussen de max en gemiddelde cadans kleiner is dan 10.
            //Indien er meerdere zijn sorteer an op gemiddelde cadens, tijdsduur en gemiddeld wattage (van groot naar klein)

            var resultaten = trainingen
                .Where(training => training.GemWat > 350 && training.Tijdsduur > 100
                                   && Math.Abs(training.MaxCad - training.GemCad) < 10)
                .OrderByDescending(training => training.GemCad)
                .ThenByDescending(training => training.Tijdsduur)
                .ThenByDescending(training => training.GemWat)
                .Select(training => training.Klantnummer)
                .ToList();

            Console.WriteLine("Alle klanten die voldoen aan de voorwaarden op volgorde gesorteerd:");
            foreach (var klantnummer in resultaten)
            {
                Console.WriteLine(klantnummer);
            }
        }

    }
}   

