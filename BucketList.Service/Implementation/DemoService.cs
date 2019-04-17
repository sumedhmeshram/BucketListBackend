using AutoMapper;
using BucketList.Entity.DataAccess;
using BucketList.Repository.UnitOfWorkAndBaseRepo;
using BucketList.Service.Interfaces;
using BucketList.ViewModel.DemoViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BucketList.Service.Implementation
{
    public class DemoService : IDemoService
    {
        IUnitOfWork _unitOfWork;
        public DemoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<DemoVM>> GetAll()
        {
            var values = await _unitOfWork.DemoModel.GetAllAsync();

            var valuesVM = Mapper.Map<List<DemoVM>>(values);

            return valuesVM;
        }

        public async Task<DemoVM> GetById(long id)
        {
            var value = await _unitOfWork.DemoModel.GetAsync(id);

            var valueVM = Mapper.Map<DemoVM>(value);

            return valueVM;
        }
    }
}
