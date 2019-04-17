using BucketList.Entity.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BucketList.Entity.Model.DemoModel
{
    public class DemoModel : LongIdBaseEntity
    {
        public string Name { get; set; }
    }
}
