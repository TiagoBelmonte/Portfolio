using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//We schrijven dit op zodat we niet voor elk object of methode dat we gebruiken van de BussinessLayer of vanuit MySql bussinessLayer. of MySql. moeten noteren.
//We schrijven dit ervoor om gemmakelijker te kunnen programeren. Ook werk je dan sneller.
using MySql.Data;
using BusinessLayer;
using Dapper;
using MySql.Data.MySqlClient;

namespace DataAccessLayer
{
   public class WerknemerDA
    {
        //klasseveld aanmaken om connectie te maken met MySql.
        MySqlConnection _connection;

        //constructor
        public WerknemerDA()
        {
            //Hiermee maken we de connectie met de juiste database.
            _connection = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=probleemmelden;password=Leerling123");
        }

        //Met deze methode halen we alle gegevens uit ons databank en gaan we ze in een lijst zetten.
        public List<Werknemer> OphalenWerknemers()
        {
            //Hieronder maken we de sql statement aan en laten we hem uitvoeren door connectie te maken met ons databank.
            String sql = "SELECT * FROM tblwerknemers";
            return _connection.Query<Werknemer>(sql).ToList();
        }

    }
}
