using AanwezighedenBL.DTO;
using AanwezighedenBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AanwezighedenBL.Interfaces
{
    public interface IAanwezighedenRepo
    {
        List<EvenementDTO> GetEvenementen();

        List<EvenementDTO> GetEvenementen(string input, bool IsOpNaam);

        Evenement GetEvenement(int Id);

        List<GebruikerDTO> GetGebruikerDetailsVoorGroep(int evenementId, int groepId);

        void UpdateAanwezigheid(int evenementId, int groepId, List<GebruikerDTO> gebruikers);

        List<Groep> NietIngeschrevenGroepen(int eventId);

        void VoegGroepToe(Groep groep, Evenement evenement);

        void VerwijderGroep(Groep groep, Evenement evenement);


    }
}
