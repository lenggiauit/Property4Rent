using Property4Rent.API.Domain.Models;
using Property4Rent.API.Domain.Services.Communication.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Property4Rent.API.Domain.Repositories
{
    public interface IRefRepository
    {
        
        Task<List<RefModel>> GetPriorities(Guid guid, RefRequest payload); 
    }
}
