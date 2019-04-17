using BucketList.Entity.DataAccess;
using BucketList.Entity.Model.BucketListModel;
using BucketList.Entity.Model.DemoModel;
using BucketList.Repository.Implementations;
using BucketList.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BucketList.Repository.UnitOfWorkAndBaseRepo
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BLDbContext _context;

        public UnitOfWork(BLDbContext context)
        {
            _context = context;

            DemoModel = new BaseRepository<DemoModel>(_context);
            BucketItem = new BucketItemRepository(_context);

        }

        public IRepository<DemoModel> DemoModel { get; private set; }
        public IBucketItemRepository BucketItem { get; private set; }


        public int Complete()
        {
            return _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                _context.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
