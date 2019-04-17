using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BucketList.API.Helpers;
using BucketList.Common.CustomExpectations;
using BucketList.Common.StaticConstants;
using BucketList.Entity.Model.Auth;
using BucketList.Entity.Model.BucketListModel;
using BucketList.Service.Implementation.BucketItemService;
using BucketList.Service.Interfaces.BucketItemInterface;
using BucketList.ViewModel.Bucket;
using BucketList.ViewModel.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BucketList.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize, ApiController]
    public class BucketItemsController : ControllerBase
    {
        private readonly IBucketItemService _bucketItemService;

        public BucketItemsController(IBucketItemService bucketItemService)
        {
            _bucketItemService = bucketItemService;
        }

        [HttpPost]
        public async Task<IActionResult> AddBucketListItem([FromBody] CreateBucketItemVM model)
        {
            var currentUserId = User.GetUserId();
            if (model == null)
            {
                return BadRequest();
            }
            var bucketListItem = await _bucketItemService.AddBucketItem(currentUserId, model);

            var response = new ResponseVM
            {
                Data = bucketListItem,
                Message = BLMessages.OperationSuccessful
            };
            return Ok(response);

        }


        [HttpGet]
        public async Task<IActionResult> GetBucketList()
        {
            var currentUserId = User.GetUserId();

            var bucketItemsList = await _bucketItemService.GetBucketItemsList(currentUserId);

            var response = new ResponseVM
            {
                Data = new ListResponseVM
                {
                    Items = bucketItemsList
                },
                Message = BLMessages.OperationSuccessful
            };
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBucketList(long id)
        {
            var currentUserId = User.GetUserId();

            var bucketItem = await _bucketItemService.GetBucketItem(currentUserId, id);

            var response = new ResponseVM
            {
                Data = bucketItem,
                Message = BLMessages.OperationSuccessful
            };
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBucketItem(long id)
        {
            var currentUserId = User.GetUserId();

            await _bucketItemService.DeleteBucketItem(currentUserId, id);

            var response = new ResponseVM
            {
                Message = BLMessages.OperationSuccessful
            };
            return Ok(response);
        }

    }
}
