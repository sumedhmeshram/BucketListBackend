﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BucketList.Common.Utilities
{
    public static class Extensions
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue)
          where TAttribute : Attribute
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TAttribute>();
        }
    }
}
