using Property4Rent.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Property4Rent.API.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly P4RContext _context;

        protected BaseRepository(P4RContext context)
        {
            _context = context;
        }
    }
}