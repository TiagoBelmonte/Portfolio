
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LinqBL.Model
{
    public class Training
    {
        //Datum + uur
        public DateTime DatumUur { get; set; }
        //•Tijdsduur (in minuten)
        public int Tijdsduur { get; set; }
        //•Gemiddelde wattage
        public int GemWat { get; set; }
        //•Maximum wattage
        public int MaxWat { get; set; }
        //•Gemiddelde cadans
        public int GemCad {  get; set; }
        //•Maximum cadans
        public int MaxCad {  get; set; }
        //•Trainingstype (fun, recovery, endurance of interval)
        public string TrainingType { get; set; }
        //•Commentaar
        public string Commentaar { get; set; }
        //•Klantnummer
        public int Klantnummer { get; set; }

        public Training(DateTime datumUur, int tijdsduur, int gemWat, int maxWat, int gemCad, int maxCad, string trainingType, string commentaar, int klantennummer)
        { 
            DatumUur = datumUur;
            Tijdsduur = tijdsduur;
            GemWat = gemWat;
            MaxWat = maxWat;
            GemCad = gemCad;
            MaxCad = maxCad;
            TrainingType = trainingType;
            Commentaar = commentaar;
            Klantnummer = klantennummer;
        }


        public override string ToString()
        {
            return $"{DatumUur} {Tijdsduur} {GemWat} {MaxWat} {GemCad} {MaxCad} {TrainingType} {Commentaar} {Klantnummer}";
        }
    }
}
