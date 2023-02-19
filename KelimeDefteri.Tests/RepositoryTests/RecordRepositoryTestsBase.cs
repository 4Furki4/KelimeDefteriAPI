using Persistence.Repositories.RecordRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Record = Domain.Entities.Record;
namespace KelimeDefteri.Tests.RepositoryTests
{
    public class RecordRepositoryTestsBase : TestBase
    {
        public RecordQueryRepository RecordQuery { get; set; }
        public RecordCommandRepository RecordCommand { get; set; }


        public RecordRepositoryTestsBase()
        {
            RecordQuery = new(context);
            RecordCommand = new(context);
        }
        protected List<Record> SeedRecords()
        {
            return new List<Record>()
            {
                new Record()
                {
                    Id = 1,
                    Created= DateTime.Now,
                    Modified= DateTime.Now.AddDays(1),
                },
                new Record()
                {
                    Id = 2,
                    Created = DateTime.Now,
                    Modified = DateTime.Now.AddDays(1),
                },
                new Record()
                {
                    Id = 3,
                    Created = DateTime.Now,
                    Modified = DateTime.Now.AddDays(1),
                }
            };
        }
    }
}
