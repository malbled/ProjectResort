using System.ComponentModel;

namespace ProjectResort.Context1.Enum
{
    public enum Post
    {
        [Description("Продавец")]
        Seller,

        [Description("Старший смены")]
        ShiftSupervisor,

        [Description("Администратор")]
        Administrator

    }
}
