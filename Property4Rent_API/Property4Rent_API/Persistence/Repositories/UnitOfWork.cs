using Property4Rent.API.Domain.Entities;
using Property4Rent.API.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Property4Rent.API.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly P4RContext _context;
        public UnitOfWork(P4RContext context)
        {
            _context = context;
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}