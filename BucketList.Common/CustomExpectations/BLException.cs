using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BucketList.Common.CustomExpectations
{
    /// <summary>
    /// This Exception to be thrown from service layer for all known exceptions
    /// </summary>
    [Serializable]
    public class BLException : Exception
    {
        protected BLException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        public BLException()
        {
        }

        public BLException(string message) : base(message)
        {
        }

        public BLException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
