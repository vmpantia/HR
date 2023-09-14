using System.ComponentModel;

namespace HR.Common.Models.enums
{
    public enum ContactType
    {
        [Description("Mobile Number")]
        MobileNumber = 1,
        [Description("Email Address")]
        EmailAddress,
        [Description("Telephone Number")]
        TelephoneNumber
    }
}
