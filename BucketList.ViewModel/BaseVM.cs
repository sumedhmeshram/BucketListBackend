using System;
using System.Collections.Generic;
using System.Text;

namespace BucketList.ViewModel
{
    public class BaseVM
    {
        public long Id { get; set; }

        public DateTimeOffset? DateCreated { get; set; }

        public DateTimeOffset? DateModified { get; set; }
    }
}
