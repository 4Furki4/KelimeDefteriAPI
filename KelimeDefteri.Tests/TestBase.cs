using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelimeDefteri.Tests
{
    public class TestBase
    {
        public KelimeDefteriAPIContext context { get; set; }
        public TestBase()
        {
            var options = new DbContextOptionsBuilder<KelimeDefteriAPIContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            context = new KelimeDefteriAPIContext(options);
        }
    }
}
