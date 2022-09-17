using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Property4Rent.API.Domain.Helpers;
using Property4Rent.API.Domain.Models;
using Property4Rent.API.Domain.Repositories;
using Property4Rent.API.Domain.Services;
using Property4Rent.API.Domain.Services.Communication.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Property4Rent.API.Services
{
    public class RefService : IRefService
    {
        private readonly IRefRepository _iRefRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;
        private readonly ILogger<RefService> _logger;

        public RefService(IRefRepository iRefRepository, ILogger<RefService> logger, IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            _iRefRepository = iRefRepository;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;
        }

        public async Task<List<RefModel>> GetPriorities(Guid guid, RefRequest payload)
        {
            return await _iRefRepository.GetPriorities(guid, payload);
        }
         
    }
}
