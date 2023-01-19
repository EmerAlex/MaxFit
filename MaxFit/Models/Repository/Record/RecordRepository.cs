using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace MaxFit.Models.Repository.Record
{
    public class RecordRepository : IRecordRepository
    {
        public IEnumerable<MaxFit.Models.Entities.Record> AllRecords()
        {
            var connection = new Conecction();

            using (MySqlConnection conecctionSQL = new MySqlConnection(connection.getStringConexion()))
            {
                conecctionSQL.Open();

                MySqlCommand commandSql = new MySqlCommand();
                commandSql.CommandText = "SELECT * FROM `maxfit`.`records`;";
                commandSql.Connection = conecctionSQL;

                using (var reader = commandSql.ExecuteReader())
                {
                    List<Entities.Record> records = new List<Entities.Record>();


                    while (reader.Read())
                    {
                        Entities.Record record = new Entities.Record();
                        record.Docuemnt = (string)reader["document"];                       
                        record.Price = (Int32)reader["price"];
                        record.Date = (DateTime)reader["date"];

                        records.Add(record);
                    }


                    return records;
                }
            }
        }

        public IEnumerable<Entities.Record> FindRecords(DateTime initialDate, DateTime finalDate)
        {
            var connection = new Conecction();

            using (MySqlConnection conecctionSQL = new MySqlConnection(connection.getStringConexion()))
            {
                conecctionSQL.Open();

                MySqlCommand commandSql = new MySqlCommand();
                commandSql.CommandText = "SELECT * FROM `maxfit`.`records` WHERE date BETWEEN ?InitialDate AND ?FinalDate;";
                commandSql.Parameters.Add("?InitialDate", MySqlDbType.DateTime).Value = initialDate;
                commandSql.Parameters.Add("?FinalDate", MySqlDbType.DateTime).Value = finalDate;
                commandSql.Connection = conecctionSQL;

                using (var reader = commandSql.ExecuteReader())
                {
                    List<Entities.Record> records = new List<Entities.Record>();


                    while (reader.Read())
                    {
                        Entities.Record record = new Entities.Record();
                        record.Docuemnt = (string)reader["document"];
                        record.Price = (Int32)reader["price"];
                        record.Date = (DateTime)reader["date"];

                        records.Add(record);
                    }


                    return records;
                }
            }
        }

        public bool SaveRecord(Entities.Record record)
        {
            var connection = new Conecction();

            using (MySqlConnection conecctionSQL = new MySqlConnection(connection.getStringConexion()))
            {
                try
                {
                    conecctionSQL.Open();

                    MySqlCommand commandSql = new MySqlCommand();
                    commandSql.CommandText = "INSERT INTO `maxfit`.`records` ( `document`, `date`, `price`)  VALUES (?Document, ?Date, ?Price);";
                    commandSql.Parameters.Add("?Document", MySqlDbType.VarChar).Value = record.Docuemnt;
                    commandSql.Parameters.Add("?Date", MySqlDbType.DateTime).Value = record.Date;
                    commandSql.Parameters.Add("?Price", MySqlDbType.Int32).Value = record.Price;
                    
                    commandSql.Connection = conecctionSQL;

                    commandSql.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }

            }
        }
    }
}
