using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.Helper
{
    public static class SystemMessages 
    {
        public static string DuplicateRecord = "Duplicate Record.";
        public static string UsernameInvalid = "Invalid email address.";
        public static string UserAlreadyExists = "Account Already Exists";
        public static string UserNameAlreadyExists = "UserName Already Exists";
        public static string RecordsNotFound = "Records not Found.";
        public static string UserLoginFailed = "Username and/or Password incorrect.";
        public static string AccountNotActivated = "You don't have sufficient permission(s) to access this panel.";
        public static string UserLoginSuccessfully = "User Login Successfully.";
        public static string EmailAlreadyExists = "Email already exists.";
        public static string UpdatedSuccessfully = "Updated Successfully";
        public static string NotUpdated = "Updation Failed";
        public static string NotDeleted = "Deletion Failed";
        public static string RecordNotFound = "Record Not Found";
        public static string PatientRecordFetched = "Patient Record Fetched";
        public static string AccountLocked = "Account Locked";
        public static string AccessGranted = "Access Granted";
        public static string DoctorInMultiTenants = "You have been registered in this Tenant as well.";
        public static string LinkExpired = "Link Expired";
        public static string AccountNotActive = "Your Account is Temporarily Out Of Service, Kindly Contact Your Admin";
        public static string SamePassword = "Current Password and New Password are same, Please Set different Password!";
        public static string ExceptionError = "An error occured. Please contact to admin";
        public static string RoleNotExists = "This Role does not Exists.";
        public static string InvalidUser = "User is not valid";
        public static string LinkResend = "Link resent successfully";
        public static string PhoneAlreadyExist = "Phone number already exists";
        public static string CancelledSuccessfully = "Cancelled Successfully";
        public static string NotCancelled = "This Record is Not Cancelled";

        #region Common

        public static string Success = "Success.";
        public static string RecordNotSaved = "Record Not Saved";

        public static string CreatedSuccessfully = "Created Successfully";

        public static string DeletedSuccessfully = "Deleted Successfully.";

        public static string InvalidParameter = "Invalid Parameter";

        public static string RecordsSaved = "Record Saved Successfully.";

        public static string RecordsDeleted = "Record Deleted Successfully.";

        public static string RecordsReturnedSuccessfully = "Records Returned Successfully.";
        public static string RecordFetched = "Record Fetched Successfully";

        public static string InvalidModel = "There is an Error with this request, Please Try Again and Enter Correct Values.";
        public static string RecordNotUpdate = "Record Not Updated";

        #endregion
    }
}
