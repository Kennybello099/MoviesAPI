using System.ComponentModel;

namespace MoviesAPI.Enum
{
    public enum StatusCodes
    {
        [Description("Forbidden Access")]
        FORBIDDEN = -6,

        [Description("Server error occured, please try again.")]
        EXCEPTION = -5,

        [Description("Unauthorized Access")]
        UNAUTHORIZED = -4,

        [Description("Not Found")]
        NOT_FOUND = -3,

        [Description("Bad Request")]
        BAD_REQUEST = -2,

        [Description("Error")]
        ERROR = -1,

        [Description("Success")]
        OK = 1,
    }
}
