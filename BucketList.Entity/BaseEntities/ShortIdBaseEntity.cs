using System;
using System.Collections.Generic;
using System.Text;

namespace BucketList.Entity.BaseEntities
{
    public class ShortIdBaseEntity : AuditInfoBaseEntity
    {
        public short Id { get; set; }
    }
}
