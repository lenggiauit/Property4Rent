using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Property4Rent.API.Domain.Entities;
using Property4Rent.API.Domain.Models;
using Property4Rent.API.Domain.Repositories;
using Property4Rent.API.Domain.Services.Communication.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Property4Rent.API.Persistence.Repositories
{
    public class RefRepository : BaseRepository, IRefRepository
    {
        private readonly ILogger<RefRepository> _logger;
        public RefRepository(P4RContext context, ILogger<RefRepository> logger) : base(context)
        {
            _logger = logger;
        }
         
        public async Task<List<RefModel>> GetPriorities(Guid guid, RefRequest payload)
        {
            return await _context.Priority.AsNoTracking().Where(s => s.IsActive == true)
                .Select(ps => new RefModel()
                {
                    Id = ps.Id,
                    Name = ps.Name, 
                    Color = ps.Color,
                    Order = ps.Order,
                    IsDefault = ps.IsDefault,
                })
                .ToListAsync();
        }
         

    }
}
