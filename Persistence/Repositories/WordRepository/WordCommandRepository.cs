using Application.Repositories.WordRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.WordRepository
{
    public class WordCommandRepository : CommandRepository<Word>, IWordCommandRepository
    {
        public WordCommandRepository(KelimeDefteriAPIContext context) : base(context) { }
    }
}
