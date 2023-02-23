using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;


namespace Persistence
{
    public static class Configuration
    {
        public static string GetConnectionString()
        {
            ConfigurationManager configManager= new();
            //todo: GET CONNECTION STRING RETURNS NULL !!!!
            return configManager.GetConnectionString("KelimeDefteriAPIDB") ?? "Data Source=localhost;Initial Catalog=KelimeDefteriAPIDB;User ID=sa;Password=Furki4_4; TrustServerCertificate=True; MultipleActiveResultSets=True";
        }
    }
}
