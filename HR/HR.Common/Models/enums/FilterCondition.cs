using System.ComponentModel;

namespace HR.Common.Models.enums
{
    public enum FilterCondition
    {
        [Description("eq")]
        Equal,
        [Description("ne")]
        NotEqual,
        [Description("c")]
        Contains,
        [Description("nc")]
        NotContains
    }
}
