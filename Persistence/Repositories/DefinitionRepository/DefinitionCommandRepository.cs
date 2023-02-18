using Application.Repositories.DefinitionRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.DefinitionRepository
{
    public class DefinitionCommandRepository : CommandRepository<Definition>, IDefinitionCommandRepository
    {
        public DefinitionCommandRepository(KelimeDefteriAPIContext context) : base(context) { }
    }
}
