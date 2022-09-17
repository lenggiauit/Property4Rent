using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Property4Rent.API.Domain.Helpers;
using Property4Rent.API.Domain.Models;
using Property4Rent.API.Domain.Services;
using Property4Rent.API.Domain.Services.Communication.Request;
using Property4Rent.API.Domain.Services.Communication.Response;
using Property4Rent.API.Infrastructure;
using Property4Rent.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Property4Rent.API.Controllers
{
    [Authorize]
    [Route("Ref")]
    public class RefController : PMBaseController
    {
        private readonly IRefService _refServices;
        private readonly ILogger<RefController> _logger;
        private readonly AppSettings _appSettings;
        private IMapper _mapper;
        public RefController(
            ILogger<RefController> logger,
            IMapper mapper,
            IRefService refServices,
            IOptions<AppSettings> appSettings)
        {
            _refServices = refServices;
            _logger = logger;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
          
        [HttpPost("GetPriorities")]
        public async Task<RefResponseList> GetPriorities([FromBody] BaseRequest<RefRequest> request)
        {
            if (ModelState.IsValid)
            {
                var priorities = await _refServices.GetPriorities(GetCurrentUserId(), request.Payload);
                var resources = _mapper.Map<List<RefModel>, List<RefResource>>(priorities);
                return new RefResponseList(resources);
            }
            else
            {
                return new RefResponseList(Constants.InvalidMsg, ResultCode.Invalid);
            }
        }
  

    }
}
