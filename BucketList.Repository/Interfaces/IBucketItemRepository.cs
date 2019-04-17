using BucketList.Entity.Model.BucketListModel;
using BucketList.Repository.UnitOfWorkAndBaseRepo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BucketList.Repository.Interfaces
{
    public interface IBucketItemRepository : IRepository<BucketItem>
    {
    }
}
