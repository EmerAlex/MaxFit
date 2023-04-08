using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace MaxFit.Models.Repository.Drink
{
    public class DrinkRepository : IDrinkRepository
    {
        public IEnumerable<Entities.Drink> AllDrinks()
        {
            var connection = new Conecction();

            using (MySqlConnection conecctionSQL = new MySqlConnection(connection.getStringConexion()))
            {
                conecctionSQL.Open();

                MySqlCommand commandSql = new MySqlCommand();
                commandSql.CommandText = "SELECT * FROM `maxfit`.`drinks`;";
                commandSql.Connection = conecctionSQL;

                using (var reader = commandSql.ExecuteReader())
                {
                    List<Entities.Drink> drinks = new List<Entities.Drink>();


                    while (reader.Read())
                    {
                        Entities.Drink drink = new Entities.Drink();
                        drink.Price = (Int32)reader["price"];
                        drink.Date = (DateTime)reader["date"];

                        drinks.Add(drink);
                    }


                    return drinks;
                }
            }
        }

        public IEnumerable<Entities.Drink> FindDrinks(DateTime initialDate, DateTime finalDate)
        {
            var connection = new Conecction();

            using (MySqlConnection conecctionSQL = new MySqlConnection(connection.getStringConexion()))
            {
                conecctionSQL.Open();

                MySqlCommand commandSql = new MySqlCommand();
                commandSql.CommandText = "SELECT * FROM `maxfit`.`drinks` WHERE date BETWEEN ?InitialDate AND ?FinalDate;";
                commandSql.Parameters.Add("?InitialDate", MySqlDbType.DateTime).Value = initialDate;
                commandSql.Parameters.Add("?FinalDate", MySqlDbType.DateTime).Value = finalDate;
                commandSql.Connection = conecctionSQL;

                using (var reader = commandSql.ExecuteReader())
                {
                    List<Entities.Drink> drinks = new List<Entities.Drink>();


                    while (reader.Read())
                    {
                        Entities.Drink drink = new Entities.Drink();
                        drink.Price = (Int32)reader["price"];
                        drink.Date = (DateTime)reader["date"];

                        drinks.Add(drink);
                    }


                    return drinks;
                }
            }
        }

        public bool SaveDrink(Entities.Drink drink)
        {
            var connection = new Conecction();

            using (MySqlConnection conecctionSQL = new MySqlConnection(connection.getStringConexion()))
            {
                try
                {
                    conecctionSQL.Open();

                    MySqlCommand commandSql = new MySqlCommand();
                    commandSql.CommandText = "INSERT INTO `maxfit`.`drinks` (`date`, `price`)  VALUES (?Date, ?Price);";
                    commandSql.Parameters.Add("?Date", MySqlDbType.DateTime).Value = drink.Date;
                    commandSql.Parameters.Add("?Price", MySqlDbType.Int32).Value = drink.Price;

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