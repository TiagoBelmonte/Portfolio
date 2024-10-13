using FitnessDL_File;
using LinqBL.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LinqDL_File.FileProcessor;
using static System.Net.Mime.MediaTypeNames;

namespace LinqDL_File
{
        public class FileProcessor : IFileProcessor
    {

        public List<Training> trainingen = new List<Training>();

        public void voegTrainingen(Training training)
        { 
            trainingen.Add(training);
        }

        public List<Training> getTrainingen() {  return trainingen; }

        public void LeesTraining(string fileName)
            {
                try
                {
                    String[] data = null;
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        string line;

                        while ((line = sr.ReadLine()) != null)
                        {
                            data = line.Split(",");

                        DateTime datum;
                        String datumTekst = data[0];
                        DateTime.TryParseExact(datumTekst.Substring(1, 19), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out datum);
                        int tijdsduur;
                        int.TryParse(data[1], out tijdsduur);
                        int gemWat;
                        int.TryParse(data[2], out gemWat);
                        int maxWat;
                        int.TryParse(data[3], out maxWat);
                        int gemCad;
                        int.TryParse(data[4], out gemCad);
                        int maxCad;
                        int.TryParse(data[5], out maxCad);
                        string traingtekst = data[6];
                        traingtekst = traingtekst.Substring(1, traingtekst.Length-2);
                        string trainingType;
                        trainingType = traingtekst;
                        string commentaar = data[7];
                        int klantNummer;
                        int.TryParse(data[8], out klantNummer);

                        Training training = new Training(datum,tijdsduur, gemWat, maxWat, gemCad,maxCad,trainingType,commentaar,klantNummer);
                        voegTrainingen(training);
                        

                    }
                }
                }
                catch (Exception ex) { throw new Exception($"FileProcessor.leesSoorten - {fileName}", ex); }
            }
    }
}
