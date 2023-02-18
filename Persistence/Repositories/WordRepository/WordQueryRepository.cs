using Application.Repositories.WordRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.WordRepository
{
    public class 
        WordQueryRepository : QueryRepository<Word>, IWordQueryRepository
    {
        public WordQueryRepository(KelimeDefteriAPIContext context) : base(context) { }
    }
}
