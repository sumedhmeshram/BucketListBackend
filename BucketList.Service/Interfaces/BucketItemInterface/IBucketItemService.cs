using BucketList.Entity.Model.BucketListModel;
using BucketList.ViewModel.Bucket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BucketList.Service.Interfaces.BucketItemInterface
{
    public interface IBucketItemService
    {
        Task<BucketItemVM> AddBucketItem(string currentUserId, CreateBucketItemVM bucketVM);

        Task<ICollection<BucketItemVM>> GetBucketItemsList(string currentUserId);
        Task<BucketItemVM> GetBucketItem(string currentUserId, long id);
        Task DeleteBucketItem(string currentUserId, long id);
    }
}
