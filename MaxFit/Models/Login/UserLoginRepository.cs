using MaxFit.Models.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaxFit.Models.Login
{
    public class UserLoginRepository
    {
        public bool Login(UserLogin userLogin)
        {
            var connection = new Conecction();

            using (MySqlConnection conecctionSQL = new MySqlConnection(connection.getStringConexion()))
            {

                try
                {


                    conecctionSQL.Open();

                    MySqlCommand commandSql = new MySqlCommand();         
                    commandSql.CommandText = "SELECT EXISTS(SELECT * FROM `maxfit`.`login` WHERE user = ?user AND password= ?password) as RESULT;";
                    commandSql.Parameters.Add("?user", MySqlDbType.VarChar).Value = userLogin.User;
                    commandSql.Parameters.Add("?password", MySqlDbType.VarChar).Value = userLogin.Password;
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
    }
}
