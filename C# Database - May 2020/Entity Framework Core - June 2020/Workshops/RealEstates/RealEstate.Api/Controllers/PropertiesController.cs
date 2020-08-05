﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Contracts;
using Services.DataTransferObject;

namespace RealEstate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertiesService propertiesService;

        public PropertiesController(IPropertiesService propertiesService)
        {
            this.propertiesService = propertiesService;
        }

        [HttpGet]
        public IActionResult Get(int count  = 5)
        {
            var result = this.propertiesService.GetAll(count);

            return Ok(result);
        }

        [HttpGet("ByPrice")]
        public IActionResult Get(int minPrice, int maxPrice, int count)
        {
            var result = this.propertiesService.SearchByPrice(minPrice, maxPrice).Take(count);

            return Ok(result);
        }

        [HttpPost]
        public ActionResult<RealEstateProperty> Create(PropertyCreateDto model)
        {
            return Ok(this.propertiesService.Create(model));
        }
    }
}
