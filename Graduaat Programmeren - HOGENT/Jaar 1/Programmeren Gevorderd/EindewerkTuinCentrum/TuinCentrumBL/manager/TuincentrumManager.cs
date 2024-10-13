using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TuinCentrumBL.Exceptions;
using TuinCentrumBL.Interfaces;
using TuinCentrumBL.Model;

namespace TuinCentrumBL.manager
{
    public class TuincentrumManager
    {
        private IFileProcessor fileProcessor;
        private ITuincentrumRepository tuincentrumRepository;

        public TuincentrumManager(IFileProcessor processor, ITuincentrumRepository tuincentrumRepository)
        {
            this.fileProcessor = processor;
            this.tuincentrumRepository = tuincentrumRepository;
        }

        public List<Product> GeefProducten()
        {
            try
            {
                return tuincentrumRepository.GeefProducten(); ;
            }
            catch (Exception ex) { throw new ManagerException("GeefProducten", ex); }
        }

        public List<Klant> GeefKlanten()
        {
            List<Klant> klanten = tuincentrumRepository.GeefKlanten();
            return klanten;
        }
        public Klant HeeftInfoKlantID(int id)
        {
            Klant klant = tuincentrumRepository.LeesKlantViaID(id);
            return klant;
        }
        public void UploadKlanten(string fileName)
        {
            List<Klant> klanten = fileProcessor.LeesKlant(fileName);
            
            foreach (Klant klant in klanten)
            {   
                    tuincentrumRepository.SchrijfKlant(klant);   
            }
        }
        public void UploadProducten(string fileName)
        {
            List<Product> producten = fileProcessor.LeesProduct(fileName);

            foreach (Product product in producten)
            {
                if (!tuincentrumRepository.HeeftProduct(product))
                {
                    tuincentrumRepository.SchrijfProduct(product);
                }
            }
        }
        public void uploadOfferte(string fileName, string filename2)
        {
            List<Offerte> offertes = fileProcessor.LeesOfferte(fileName, filename2);

            foreach (Offerte offerte in offertes)
            {
                tuincentrumRepository.schrijfOfferte(offerte);
            }
        }
        public void UpdateOfferte(Offerte offerte, Dictionary<Product, int> NieuweProducten, Dictionary<Product, int> VerwijderdProducten)
        {
            tuincentrumRepository.UpdateOfferte(offerte,NieuweProducten, VerwijderdProducten);
        } 
        public int BerekenOfferteID()
        {
            return tuincentrumRepository.geefMaxOfferteID() + 1;
        }
    
    }
}
