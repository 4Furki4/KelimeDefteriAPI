using Application.Repositories.RecordRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.RecordRepository
{
    public class RecordQueryRepository : QueryRepository<Record>, IRecordQueryRepository
    {
        public RecordQueryRepository(KelimeDefteriAPIContext context) : base(context) { }
    }
}
