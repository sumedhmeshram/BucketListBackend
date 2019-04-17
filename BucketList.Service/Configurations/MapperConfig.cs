using AutoMapper;
using BucketList.Entity.Model.Auth;
using BucketList.Entity.Model.BucketListModel;
using BucketList.Entity.Model.DemoModel;
using BucketList.ViewModel.Bucket;
using BucketList.ViewModel.DemoViewModel;
using BucketList.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace BucketList.Service.Configurations
{
    public static class MapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(m =>
            {
                m.CreateMap<DemoModel, DemoVM>();

                m.CreateMap<AppUser, UserVM>();

                m.CreateMap<BucketItem, BucketItemVM>();

                m.CreateMap<CreateBucketItemVM, BucketItem>();
            });
        }
    }
}
