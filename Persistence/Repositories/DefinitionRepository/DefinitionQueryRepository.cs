using Application.Repositories.DefinitionRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.DefinitionRepository
{
    public class DefinitionQueryRepository : QueryRepository<Definition>, IDefinitionQueryRepository
    {
        public DefinitionQueryRepository(KelimeDefteriAPIContext context) : base(context) { }
    }
}
