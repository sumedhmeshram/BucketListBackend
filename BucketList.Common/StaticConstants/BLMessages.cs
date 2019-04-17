using System;
using System.Collections.Generic;
using System.Text;

namespace BucketList.Common.StaticConstants
{
    public static class BLMessages
    {
        //##################################### Shared ####################################################
        public static string SupportEmail { get; set; }

        //##################################### Error Messages ############################################
        //General
        public static string GenralException { get; set; }
        public static string RecordNotFound { get; set; }
        public static string SavedSuccessfully { get; set; }
        public static string UpdatedSuccessfully { get; set; }
        public static string DeletedSuccessfully { get; set; }
        public static string VerificationRequired { get; set; }
        public static string RegistrationRequired { get; set; }
        public static string RecordAlreadyExists { get; set; }
        //Account
        public static string AccountNotExist { get; set; }
        public static string InvalidUserNamePassword { get; set; }
        public static string AccountAlreadyExist { get; set; }
        public static string InvalidToken { get; set; }
        public static string EmailAlreadyVerified { get; set; }
        public static string AccountBlocked { get; set; }
        public static string EmailAccountExist { get; set; }
        public static string DateGreaterThanNowError { get; set; }
        public static string InvalidPassword { get; set; }
        public static string OperationSuccessful { get; set; }


        //Access
        public static string AccessDenied { get; set; }

    }
}
