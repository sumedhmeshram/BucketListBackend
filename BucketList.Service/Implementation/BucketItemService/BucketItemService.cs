using AutoMapper;
using BucketList.Common.CustomExpectations;
using BucketList.Common.StaticConstants;
using BucketList.Entity.DataAccess;
using BucketList.Entity.Model.BucketListModel;
using BucketList.Repository.UnitOfWorkAndBaseRepo;
using BucketList.Service.Interfaces.BucketItemInterface;
using BucketList.ViewModel.Bucket;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BucketList.Service.Implementation.BucketItemService
{
    public class BucketItemService : IBucketItemService
    {
        IUnitOfWork _unitOfWork;

        public BucketItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BucketItemVM> AddBucketItem(string currentUserId, CreateBucketItemVM createBucketItemVM)
        {
            var bucketItem = Mapper.Map<BucketItem>(createBucketItemVM);
            bucketItem.OwnerId = currentUserId;
            await _unitOfWork.BucketItem.AddAsync(bucketItem);
            _unitOfWork.Complete();

            var bucketItemVM = Mapper.Map<BucketItemVM>(bucketItem);
            return bucketItemVM;
        }
        public async Task<BucketItemVM> GetBucketItem(string currentUserId, long id)
        {
            var bucketItem = await _unitOfWork.BucketItem.FirstOrDefaultAsync(p => p.Id == id);

            if(bucketItem == null)
            {
                throw new BLException(BLMessages.RecordNotFound);
            }

            var bucketItemVM = Mapper.Map<BucketItemVM>(bucketItem);

            return bucketItemVM;
        }

        public async Task<ICollection<BucketItemVM>> GetBucketItemsList(string currentUserId)
        {
            var bucketItemsList = await _unitOfWork.BucketItem.GetListAsync(b => b.OwnerId == currentUserId);

            var bucketItemsListVM = Mapper.Map<ICollection<BucketItemVM>>(bucketItemsList);

            return bucketItemsListVM;
        }

        public async Task DeleteBucketItem(string currentUserId, long id)
        {
            var bucketItem = await _unitOfWork.BucketItem.FirstOrDefaultAsync(p => p.Id == id);

            if (bucketItem == null)
            {
                throw new BLException(BLMessages.RecordNotFound);
            }

            if (bucketItem.OwnerId != currentUserId)
            {
                throw new BLException(BLMessages.AccessDenied);
            }

            _unitOfWork.BucketItem.Remove(bucketItem);
            _unitOfWork.Complete();
        }
    }
}
