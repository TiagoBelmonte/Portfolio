using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AanwezighedenBL;
using AanwezighedenBL.DTO;
using AanwezighedenBL.Interfaces;
using AanwezighedenBL.Model;
using Microsoft.Data.SqlClient;

namespace AanwezighedenDL_SQL
{
    public class AanwezighedenRepo : IAanwezighedenRepo
    {
        private string connectionString;

        public AanwezighedenRepo(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<EvenementDTO> GetEvenementen()
        {
            List<EvenementDTO> evenementen = new List<EvenementDTO>();

            string sql = "SELECT Id,Naam,Datum,Plaats FROM Evenement";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = sql;
                connection.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["Id"];
                        string naam = (string)reader["Naam"];
                        DateTime datum = (DateTime)reader["Datum"];
                        string datumString = datum.ToString("yyyy-MM-dd"); // Customize the format as needed
                        string plaats = (string)reader["Plaats"];
                        EvenementDTO evenement = new EvenementDTO(id, naam, datumString, plaats);
                        evenementen.Add(evenement);
                    }
                }
            }
            return evenementen;
        }

        public List<EvenementDTO> GetEvenementen(string input, bool IsOpNaam)
        {
            List<EvenementDTO> evenementen = new List<EvenementDTO>();

            string sql = "SELECT Id,Naam,Datum,Plaats FROM Evenement";
            if (IsOpNaam)
            {
                sql += " WHERE Naam LIKE @input";
            }
            else
            {
                sql += " WHERE Datum = @input";
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = sql;
                if (IsOpNaam)
                {
                    command.Parameters.AddWithValue("@input", "%" + input + "%");
                }
                else
                {
                    DateTime datum = DateTime.Parse(input); // Assuming the input is a valid date string
                    command.Parameters.AddWithValue("@input", datum);
                }
                connection.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["Id"];
                        string naam = (string)reader["Naam"];
                        string datum = Convert.ToString((DateTime)reader["Datum"]);
                        string plaats = (string)reader["Plaats"];
                        EvenementDTO evenement = new EvenementDTO(id, naam, datum, plaats);
                        evenementen.Add(evenement);
                    }
                }
            }
            return evenementen;
        }

        public Evenement GetEvenement(int Id)
        {
            Evenement evenement = null;

            string sql = "SELECT t1.Id EvenementId, t1.Naam EvenementNaam, t1.Datum, t1.StartTijd, t1.EindTijd, t1.Plaats, t2.GroepId,t2.IsAanwezig, t2.Reden, t3.Naam GroepNaam, t4.Id GebruikerId,t4.Naam GebruikerNaam, t4.Familienaam, t4.Email FROM Evenement t1 LEFT JOIN Aanwezigheden t2 ON t1.Id = t2.EvenementId LEFT JOIN Groep t3 ON t2.GroepId = t3.Id LEFT JOIN Gebruiker t4 ON t2.GebruikersId = t4.Id WHERE t1.Id = @input";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = sql;
                command.Parameters.AddWithValue("@input", Id);

                connection.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (evenement == null)
                        {
                            int evenementId = (int)reader["EvenementId"];
                            string evenementNaam = (string)reader["EvenementNaam"];
                            DateTime datum = (DateTime)reader["Datum"];
                            TimeSpan starttijd = (TimeSpan)reader["StartTijd"];
                            TimeSpan eindtijd = (TimeSpan)reader["EindTijd"];
                            string plaats = (string)reader["Plaats"];
                            evenement = new Evenement(evenementId, datum, starttijd, eindtijd, plaats, evenementNaam);

                        }

                        int groepId = (int)reader["GroepId"];
                        if (!evenement.AanwezigeGroepen.ContainsKey(groepId))
                        {
                            string groepNaam = (string)reader["GroepNaam"];
                            Groep groep = new Groep(groepId, groepNaam);
                            evenement.VoegGroepToe(groep);
                        }
                        int gebruikerId = (int)reader["GebruikerId"];
                        string gebruikerNaam = (string)reader["GebruikerNaam"];
                        string familienaam = (string)reader["Familienaam"];
                        string email = (string)reader["Email"];
                        Gebruiker gebruiker = new Gebruiker(gebruikerId, gebruikerNaam, familienaam, email);
                        evenement.AanwezigeGroepen[groepId].VoegLidToe(gebruiker);
                    }
                }
            }
            return evenement;
        }



        public List<GebruikerDTO> GetGebruikerDetailsVoorGroep(int evenementId, int groepId)
        {
            List<GebruikerDTO> gebruikers = new List<GebruikerDTO>();

            string sql = "SELECT t4.Id GebruikerId, t4.Naam GebruikerNaam, t4.Familienaam, t4.Email, t2.IsAanwezig, t2.Reden " +
                         "FROM Evenement t1 " +
                         "LEFT JOIN Aanwezigheden t2 ON t1.Id = t2.EvenementId " +
                         "LEFT JOIN Gebruiker t4 ON t2.GebruikersId = t4.Id " +
                         "WHERE t1.Id = @evenementId AND t2.GroepId = @groepId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = sql;
                command.Parameters.AddWithValue("@evenementId", evenementId);
                command.Parameters.AddWithValue("@groepId", groepId);

                connection.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int gebruikerId = (int)reader["GebruikerId"];
                        string gebruikerNaam = (string)reader["GebruikerNaam"];
                        string familienaam = reader["Familienaam"] != DBNull.Value ? (string)reader["Familienaam"] : string.Empty;
                        string email = (string)reader["Email"];
                        bool isAanwezig = reader["IsAanwezig"] != DBNull.Value && (bool)reader["IsAanwezig"];
                        string reden = reader["Reden"] != DBNull.Value ? (string)reader["Reden"] : string.Empty;

                        GebruikerDTO gebruikerDTO = new GebruikerDTO(gebruikerId, gebruikerNaam, familienaam, email, isAanwezig, reden);
                        gebruikers.Add(gebruikerDTO);
                    }
                }
            }

            return gebruikers;
        }

        public void UpdateAanwezigheid(int evenementId, int groepId, List<GebruikerDTO> gebruikers)
        {
            string sql = "UPDATE Aanwezigheden SET IsAanwezig = @isAanwezig, Reden = @reden WHERE EvenementId = @evenementId AND GroepId = @groepId AND GebruikersId = @gebruikerId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                foreach (var gebruiker in gebruikers)
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = sql;
                        command.Parameters.AddWithValue("@isAanwezig", gebruiker.IsAanwezig);
                        command.Parameters.AddWithValue("@reden", gebruiker.Reden ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@evenementId", evenementId);
                        command.Parameters.AddWithValue("@groepId", groepId);
                        command.Parameters.AddWithValue("@gebruikerId", gebruiker.Id);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public List<Groep> NietIngeschrevenGroepen(int eventId)
        {
            Dictionary<int, Groep> groepen = new();

            string sql = "SELECT g.Id AS GroepsId, g.Naam AS GroepsNaam, u.Id AS GebruikerId, u.Naam AS GebruikerNaam, u.Familienaam AS FNaam, u.Email FROM Groep g INNER JOIN Gebruiker u ON g.Id = u.GroepsId LEFT JOIN (SELECT DISTINCT GroepId FROM Aanwezigheden WHERE EvenementId = @input) a ON g.Id = a.GroepId WHERE a.GroepId IS NULL ORDER BY GroepsId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = sql;
                command.Parameters.AddWithValue("@input", eventId);

                connection.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int groepId = (int)reader["GroepsId"];
                        if (!groepen.ContainsKey(groepId))
                        {
                            string groepNaam = (string)reader["GroepsNaam"];
                            Groep groep = new Groep(groepId, groepNaam);
                            groepen.Add(groep.Id, groep);
                        }
                        int gebruikerId = (int)reader["GebruikerId"];
                        string gebruikerNaam = (string)reader["GebruikerNaam"];
                        string familienaam = (string)reader["FNaam"];
                        string email = (string)reader["Email"];
                        Gebruiker gebruiker = new Gebruiker(gebruikerId, gebruikerNaam, familienaam, email);
                        groepen[groepId].VoegLidToe(gebruiker);
                    }
                }
                return groepen.Values.ToList();
            }
        }

        public void VoegGroepToe(Groep groep, Evenement evenement)
        {
            string query = "INSERT INTO Aanwezigheden (EvenementId, GroepId, GebruikersId, IsAanwezig, Reden) VALUES (@EvenementId, @GroepId, @GebruikersId, @IsAanwezig, @Reden)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (Gebruiker gebruiker in groep.Leden.Values)
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EvenementId", evenement.Id);
                        command.Parameters.AddWithValue("@GroepId", groep.Id);
                        command.Parameters.AddWithValue("@GebruikersId", gebruiker.Id);
                        command.Parameters.AddWithValue("@IsAanwezig", true);
                        command.Parameters.AddWithValue("@Reden", DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void VerwijderGroep(Groep groep, Evenement evenement)
        {
            string query = "DELETE FROM Aanwezigheden WHERE GroepId = @GroepId AND EvenementId = @EvenementId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@GroepId", groep.Id);
                    command.Parameters.AddWithValue("@EvenementId", evenement.Id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
