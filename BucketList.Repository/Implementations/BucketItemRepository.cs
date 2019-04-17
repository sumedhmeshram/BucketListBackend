using BucketList.Entity.DataAccess;
using BucketList.Entity.Model.BucketListModel;
using BucketList.Repository.Interfaces;
using BucketList.Repository.UnitOfWorkAndBaseRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace BucketList.Repository.Implementations
{
    public class BucketItemRepository : BaseRepository<BucketItem>, IBucketItemRepository
    {
        public BucketItemRepository(BLDbContext context) : base(context)
        {

        }

        public BLDbContext BLDbContext
        {
            get { return Context as BLDbContext; }
        }
    }
}
