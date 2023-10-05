using System.ComponentModel;

namespace HR.Common.Models.enums
{
    public enum AddressType
    {
        [Description("Permanent Address")]
        PermanentAddress,
        [Description("Present Address")]
        PresentAddress,
        [Description("Provincial Address")]
        ProvincialAddress
    }
}
