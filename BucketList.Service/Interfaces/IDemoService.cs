using BucketList.ViewModel.DemoViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BucketList.Service.Interfaces
{
    public interface IDemoService
    {
        Task<List<DemoVM>> GetAll();
        Task<DemoVM> GetById(long id);
    }
}
