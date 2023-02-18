using Application.Repositories.RecordRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.RecordRepository
{
    public class RecordCommandRepository : CommandRepository<Record>, IRecordCommandRepository
    {
        public RecordCommandRepository(KelimeDefteriAPIContext context) : base(context) { }
    }
}
