using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AanwezighedenBL.DTO
{
    public class EvenementDTO
    {
        //Id,Datum,Plaats,Naam
        public int Id; 
        public string Naam; 
        public string Datum;
        public string Plaats;

        public EvenementDTO(int id, string naam, string datum, string plaats)
        {
            Id = id;
            Naam = naam;
            Datum = datum;
            Plaats = plaats;
        }

        public override string ToString()
        {
            return $"Evenement: {Naam} - Datum: {Datum} - Plaats: {Plaats}";
        }
    }
}
