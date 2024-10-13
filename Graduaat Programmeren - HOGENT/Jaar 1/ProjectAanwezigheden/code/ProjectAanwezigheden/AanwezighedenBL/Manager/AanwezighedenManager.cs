using AanwezighedenBL.DTO;
using AanwezighedenBL.Interfaces;
using AanwezighedenBL.Model;
using System.Collections.Generic;

namespace AanwezighedenBL.Manager {
    public class AanwezighedenManager {
        private IAanwezighedenRepo repo;

        public AanwezighedenManager(IAanwezighedenRepo repo) {
            this.repo = repo;
        }

        public List<EvenementDTO> GetEvenementen() {
            return repo.GetEvenementen();
        }

        public List<EvenementDTO> GetEvenementen(string input, bool IsOpNaam) {
            return repo.GetEvenementen(input, IsOpNaam);
        }

        public Evenement GetEvenement(int Id) {
            return repo.GetEvenement(Id);
        }

       

        public List<GebruikerDTO> GetGebruikerDetailsVoorGroep(int evenementId, int groepId) {
            return repo.GetGebruikerDetailsVoorGroep(evenementId, groepId);
        }

        public void UpdateAanwezigheid(int evenementId, int groepId, List<GebruikerDTO> gebruikers) {
            repo.UpdateAanwezigheid(evenementId, groepId, gebruikers);
        }

        public List<Groep> NietIngeschrevenGroepen(int eventId)
        {
            return repo.NietIngeschrevenGroepen(eventId);
        }

        public void VoegGroepToe(Groep groep, Evenement evenement)
        {
            repo.VoegGroepToe(groep, evenement);
        }

        public void VerwijderGroep(Groep groep, Evenement evenement)
        {
            repo.VerwijderGroep(groep, evenement);
        }
    }
}
