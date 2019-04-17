using System;
using System.Collections.Generic;
using System.Text;

namespace BucketList.Entity.BaseEntities
{
    public class LongIdBaseEntity : AuditInfoBaseEntity
    {
        public long Id { get; set; }
    }
}
