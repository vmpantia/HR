using HR.Common.Constants;

namespace HR.Common.Utilities
{
    public static class Parser
    {
        public static string ParseStatus(int status)
        {
            switch(status)
            {
                case Status.STATUS_INVALID_INT:
                    return Status.STATUS_INVALID_STR;
                case Status.STATUS_ENABLED_INT:
                    return Status.STATUS_ENABLED_STR;
                case Status.STATUS_DISABLED_INT:
                    return Status.STATUS_DISABLED_STR;
                case Status.STATUS_FOR_DELETION_INT:
                    return Status.STATUS_FOR_DELETION_STR;
                default:
                    return string.Empty;
            }
        }
    }
}
