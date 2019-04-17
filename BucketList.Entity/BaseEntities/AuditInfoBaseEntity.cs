using System;
using System.Collections.Generic;
using System.Text;

namespace BucketList.Entity.BaseEntities
{
    public class AuditInfoBaseEntity
    {
        public long? CreatedBy { get; set; }
        public DateTimeOffset? DateCreated { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTimeOffset? DateModified { get; set; }
        public bool IsDeleted { get; set; }
        public long? DeletedBy { get; set; }
        public DateTimeOffset? DateDeleted { get; set; }
        public string IPAddress { get; set; }
    }
}
