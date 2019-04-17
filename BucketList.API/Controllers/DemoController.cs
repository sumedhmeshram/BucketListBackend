using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BucketList.Common.CustomExpectations;
using BucketList.Common.StaticConstants;
using BucketList.Service.Interfaces;
using BucketList.ViewModel.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BucketList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DemoController : ControllerBase
    {
        private readonly IDemoService _demoService;

        public DemoController(IDemoService demoService)
        {
            _demoService = demoService;
        }

        // GET api/demo
        [AllowAnonymous, HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _demoService.GetAll();
            var responseVM = new ResponseVM
            {
                Data = new ListResponseVM
                {
                    Items = result,
                    Count = result.Count()
                }
            };
            return Ok(responseVM);

        }

        // GET api/demo/2
        [AllowAnonymous, HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _demoService.GetById(id);
            var responseVM = new ResponseVM
            {
                Data = result
            };
            return Ok(responseVM);
        }
    }
}
