using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Property4Rent.API.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
