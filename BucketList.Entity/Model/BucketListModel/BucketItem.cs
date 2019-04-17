using BucketList.Entity.BaseEntities;
using BucketList.Entity.Model.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace BucketList.Entity.Model.BucketListModel
{
    public class BucketItem : LongIdBaseEntity
    {
        public string Text { get; set; }
        public string OwnerId { get; set; }
        public AppUser Owner { get; set; } 
    }
}
