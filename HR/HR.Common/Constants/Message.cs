namespace HR.Common.Constants
{
    public class Message
    {
        public const string ERROR_NO_RECORD_FOUND_BY_ID = "No record is found for ID: {0}";
        public const string ERROR_REQUEST_NULL = "Request cannot be empty or null, Please try again.";
        public const string ERROR_SAVING = "Error in saving your transaction, Please try again.";
        public const string ERROR_INTERNAL_ID_PROPERTY_NOT_FOUND = "InternalID property cannot be found in the entity.";

        public const string SUCCESS_SAVING = "{0} has been saved successfully.";
        public const string SUCCESS_DELETING = "{0} has been deleted successfully.";
    }
}
