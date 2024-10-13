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
    public class ProbleemDA
    {
        //klasseveld aanmaken om connectie te maken met MySql.
        MySqlConnection _connection;

        //constructor
        public ProbleemDA()
        {
            //Hiermee maken we de connectie met de juiste database.
            _connection = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=probleemmelden;password=Leerling123");
        }

        //Methode om de gegevens van het nieuwe probleem weg te schrijven naar de databank.
        public void NieuwProbleem(Probleem nieuwProbleem)
        {
            //Nieuw sql statement maken
            string sql = "INSERT INTO tblprobleem(ProbleemID ,Werknemer, toestel, omschrijving, plaats, status, ITcoordinator, datum) VALUES(@ProbleemID ,@Werknemer, @toestel, @omschrijving, @plaats, @status, @ITcoordinator, @datum)";

            //We maken hier alle parameters aan dat moeten meegegeven worden met het sql statement.
            DynamicParameters param = new DynamicParameters();
            param.Add("ProbleemID", nieuwProbleem.ProbleemId);
            param.Add("Werknemer", nieuwProbleem.WerknemerId);
            param.Add("toestel", nieuwProbleem.Toestel);
            param.Add("omschrijving", nieuwProbleem.Omschrijving);
            param.Add("plaats", nieuwProbleem.Plaats);
            param.Add("status", nieuwProbleem.Status);
            param.Add("ITcoordinator", nieuwProbleem.ItCoordinator);
            param.Add("datum", nieuwProbleem.Datum);

            //SQL-statement uitvoeren
            _connection.Execute(sql, param);
        }

        //Deze methode gaan we gebruiken om alle problemen in de databank in een lijst te zetten.
        public List<Probleem> Ophalenproblemen()
        {
            String sql = "SELECT * FROM tblprobleem";
            return _connection.Query<Probleem>(sql).ToList();
        }

        //Methode om een probleem te wijzigen.
        public void ProbleemWijzigen(Probleem probleem)
        {
            //sql statement aanmaken
            string sql = "UPDATE tblprobleem SET toestel = @toestel, omschrijving = @omschrijving, plaats = @plaats, WHERE ProbleemID = @probleemId";
            //meegegeven parameters aanmaken
            DynamicParameters param = new DynamicParameters();
            param.Add("toestel", probleem.Toestel);
            param.Add("omschrijving", probleem.Omschrijving);
            param.Add("plaats", probleem.Plaats);
            param.Add("probleemId", probleem.ProbleemId);
            //sql laten uitvoeren met de meegegeven parameters
            _connection.Execute(sql, param);
        }

        //Met deze methode ga je een geselecteerde probleem verwijderen uit de databank.
        public void ProbleemVerwijderen(Probleem probleem)
        {
            //sql statement aanmaken
            string sql = "DELETE FROM tblprobleem WHERE ProbleemID = @probleemId";

            //meegegeven parameter aanmaken
            DynamicParameters param = new DynamicParameters();
            param.Add("probleemId", probleem.ProbleemId);

            //sql statement laten uitvoeren
            _connection.Execute(sql, param);
        }
        
    }
}

