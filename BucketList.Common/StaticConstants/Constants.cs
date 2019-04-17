using System;
using System.Collections.Generic;
using System.Text;

namespace BucketList.Common.StaticConstants
{
    public static class Constants
    {
        //######################### Compile time constants - Start ##################################
        //These constants are used as default values for function parameters. Cant be put in appsettings.json file. Required compile time constants
        public const int DefaultPageSize = 30;

        public static string LogFilePath { get; set; }

        public const int DefaultPageNo = 1;
        public const int MaxPageSize = 500;
        public const int CommentMaxLength = 300;
        public const int TextMaxLenght = 5000;
        //######################### Compile time constants - End ####################################


        public static string BLConnectionString { get; set; }
        public static string TokenSecretKey { get; set; }
        public static string TokenIssuer { get; set; }
        public static string TokenAudience { get; set; }
        public static int TokenExpiryDays { get; set; }

    }
}
