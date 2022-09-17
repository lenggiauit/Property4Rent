﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Property4Rent.API.Domain.Helpers;
using Property4Rent.API.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Property4Rent.API.Controllers
{
    public class HomeController : PMBaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppSettings _appSettings;
        private IMapper _mapper;
        public HomeController(
            ILogger<HomeController> logger,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _mapper = mapper;
            _appSettings = appSettings.Value;

        }


    }
}