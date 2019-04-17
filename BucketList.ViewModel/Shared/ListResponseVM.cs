using System;
using System.Collections.Generic;
using System.Text;

namespace BucketList.ViewModel.Shared
{
    public class ListResponseVM
    {
        public int Page { get; set; }

        public int Count { get; set; }

        public int TotalCount { get; set; }

        public object Items { get; set; }
    }
}
