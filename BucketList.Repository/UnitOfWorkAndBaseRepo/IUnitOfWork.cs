using BucketList.Entity.Model.DemoModel;
using BucketList.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BucketList.Repository.UnitOfWorkAndBaseRepo
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<DemoModel> DemoModel { get; }

        IBucketItemRepository BucketItem { get; }

        int Complete();
    }
}
