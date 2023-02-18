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
            return configManager.GetConnectionString("KelimeDefteriAPIDB") ?? throw new Exception("Connection string is empty");
        }
    }
}
