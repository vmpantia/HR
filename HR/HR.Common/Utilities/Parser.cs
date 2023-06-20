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

        public static string ParseContactType(int type)
        {
            switch (type)
            {
                case ContactType.TYPE_MOBILE_INT:
                    return ContactType.TYPE_MOBILE_STR;
                case ContactType.TYPE_EMAIL_INT:
                    return ContactType.TYPE_EMAIL_STR;
                case ContactType.TYPE_TELEPHONE_INT:
                    return ContactType.TYPE_TELEPHONE_STR;
                default:
                    return string.Empty;
            }
        }

        public static string ParseAddressType(int type)
        {
            switch (type)
            {
                case AddressType.TYPE_PERMANENT_INT:
                    return AddressType.TYPE_PERMANENT_STR;
                case AddressType.TYPE_PRESENT_INT:
                    return AddressType.TYPE_PRESENT_STR;
                case AddressType.TYPE_PROVINCIAL_INT:
                    return AddressType.TYPE_PROVINCIAL_STR;
                default:
                    return string.Empty;
            }
        }
    }
}
