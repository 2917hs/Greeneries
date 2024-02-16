using System;
namespace Green.Web.Utility
{
    public class StaticDetails
    {
        public static string CouponApiBase { get; set; } = string.Empty;

        public static string AuthApiBase { get; set; } = string.Empty;

        public enum ApiType
        {
            GET,
            PUT,
            POST,
            DELETE
        }
    }

    public struct Role
    {
        public const string Admin = "Admin";

        public const string Customer = "Customer";
    }

    public struct TokenKey
    {
        public const string Key = "JwtToken";
    }
}

