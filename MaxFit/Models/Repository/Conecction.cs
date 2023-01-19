using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MaxFit.Models.Repository
{
    public class Conecction
    {
        private string ConnectionString = string.Empty;

        public Conecction()
        {
            ConnectionString = "Server=127.0.0.1;Port=3306;Database=maxfit;Uid=root;password=sasa";
        }

        public string getStringConexion()
        {
            return this.ConnectionString;
        }

    }
}
