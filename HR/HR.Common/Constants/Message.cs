namespace HR.Common.Constants
{
    public class Message
    {
        public const string ERROR_NO_RECORD_FOUND_BY_ID = "No record is found for ID: {0}";
        public const string ERROR_REQUEST_NULL = "Request cannot be empty or null, Please try again.";
        public const string ERROR_SAVING = "Error in saving your transaction, Please try again.";
        public const string ERROR_PROPERTY_NOT_FOUND = "{0} property cannot be found in the entity.";
        public const string ERROR_NAME_ALREADY_EXIST = "{0} Name is already exist in the system.";

        public const string DEFAULT_SUCCESS = "Your request has been processed successfully.";
        public const string SUCCESS_SAVING = "{0} has been saved successfully.";
        public const string SUCCESS_DELETING = "{0} has been deleted successfully.";
    }
}
