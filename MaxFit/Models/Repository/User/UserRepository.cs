using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace MaxFit.Models.Repository
{
    public class UserRepository : IUserRepository
    {
        
        public bool AddUser(User user)
        {
            var connection = new Conecction();

            using (MySqlConnection conecctionSQL = new MySqlConnection(connection.getStringConexion()))
            {
                try { 
                    conecctionSQL.Open();

                    MySqlCommand commandSql = new MySqlCommand();
                    commandSql.CommandText = "INSERT INTO `maxfit`.`users` (`identity`, `identity_type`, `name`,`subscription`,`date_inscription`) VALUES (?Identity, ?IdentityType, ?Name, ?Subscription, ?DateInscription);";
                    commandSql.Parameters.Add("?Identity", MySqlDbType.VarChar).Value = user.Identity;
                    commandSql.Parameters.Add("?IdentityType", MySqlDbType.VarChar).Value = user.IdentityType;
                    commandSql.Parameters.Add("?Name", MySqlDbType.VarChar).Value = user.Name;
                    commandSql.Parameters.Add("?Subscription", MySqlDbType.VarChar).Value = user.Subscription;
                    commandSql.Parameters.Add("?DateInscription", MySqlDbType.DateTime).Value = user.DateInscription;
                    commandSql.Connection = conecctionSQL;

                    commandSql.ExecuteNonQuery();
                    return true;
                }catch(Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
                
            }
        }

        public bool ExistUser(string identity)
        {
            var connection = new Conecction();

            using (MySqlConnection conecctionSQL = new MySqlConnection(connection.getStringConexion()))
            {

                try
                {
                   

                    conecctionSQL.Open();

                    MySqlCommand commandSql = new MySqlCommand();
                    commandSql.CommandText = "SELECT EXISTS(SELECT * FROM `maxfit`.`users` WHERE identity = ?identity) as RESULT; ";
                    commandSql.Parameters.Add("?identity", MySqlDbType.VarChar).Value = identity;
                    commandSql.Connection = conecctionSQL;

                    using (var reader = commandSql.ExecuteReader())
                    {
                        reader.Read();


                        return Convert.ToInt32(reader["RESULT"]) == 1;
                    }
               
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }



                
            }

        }

        public IEnumerable<User> FindAll()
        {
            var connection = new Conecction();

            using (MySqlConnection conecctionSQL = new MySqlConnection(connection.getStringConexion()))
            {
                conecctionSQL.Open();

                MySqlCommand commandSql = new MySqlCommand();
                commandSql.CommandText = "SELECT * FROM `maxfit`.`users`;";
                commandSql.Connection = conecctionSQL;

                using (var reader = commandSql.ExecuteReader())
                {
                    List<User> users = new List<User>();
                   

                    while (reader.Read())
                    {
                        User user = new User();
                        user.Identity = (string)reader["identity"];
                        user.IdentityType = (string)reader["identity_type"];
                        user.Name = (string)reader["name"];
                        user.DateInscription = (DateTime)reader["date_inscription"];

                        users.Add(user);
                    }

                    
                    return users;
                }
            }
        }

        public User FindUser(string identity)
        {
            var connection = new Conecction();

            using (MySqlConnection conecctionSQL = new MySqlConnection(connection.getStringConexion()))
            {
                conecctionSQL.Open();

                MySqlCommand commandSql = new MySqlCommand();
                commandSql.CommandText = "SELECT * FROM `maxfit`.`users` WHERE(identity = ?identity);";
                commandSql.Parameters.Add("?identity", MySqlDbType.VarChar).Value = identity;
                commandSql.Connection = conecctionSQL;

                using (var reader = commandSql.ExecuteReader())
                {
                    User user = new User();

                    while (reader.Read())
                    {
                        user.Identity = (string)reader["identity"];
                        user.IdentityType = (string)reader["identity_type"];
                        user.Name = (string)reader["name"];                       
                        user.DateInscription = (DateTime)reader["date_inscription"];
                    }
             
                    return user;
                }
            }
            
        }

        public bool UpdateUser(User user)
        {
            var connection = new Conecction();

            using (MySqlConnection conecctionSQL = new MySqlConnection(connection.getStringConexion()))
            {
                try
                {
                    conecctionSQL.Open();

                    MySqlCommand commandSql = new MySqlCommand();
                    commandSql.CommandText = "UPDATE `maxfit`.`users` SET `subscription` = ?Subscription,`date_inscription` = ?DateInscription WHERE (`identity` = ?Identity );";
                    commandSql.Parameters.Add("?Identity", MySqlDbType.VarChar).Value = user.Identity;
                    commandSql.Parameters.Add("?Subscription", MySqlDbType.VarChar).Value = user.Subscription;
                    commandSql.Parameters.Add("?DateInscription", MySqlDbType.DateTime).Value = user.DateInscription;
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
