using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;
using Record = Domain.Entities.Record;

namespace KelimeDefteri.Tests.RepositoryTests
{
    public class RecordTests : RecordRepositoryTestsBase
    {
        [Fact]
        public async Task CanGetAllRecords()
        {
            List<Record> records = SeedRecords();
            await RecordCommand.AddRangeAsync(records);
            await RecordCommand.SaveAsync();
            var result = RecordQuery.GetAll();
            Assert.Equal(3, result.Count());
        }
        [Fact]
        public async Task CanGetRecordById()
        {
            List<Record> records = SeedRecords();
            await RecordCommand.AddRangeAsync(records);
            await RecordCommand.SaveAsync();
            var result = await RecordQuery.GetByIdAsync(1);
            Assert.Equal(1, result.Id);
        }

    }
}
