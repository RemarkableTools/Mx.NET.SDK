namespace Mx.NET.SDK.Core.Domain.Helper
{
    public static class TokenHelper
    {
        public static string GetTicker(this string identifier)
        {
            if (identifier.Contains("-"))
                return identifier.Substring(0, identifier.IndexOf('-'));
            else
                return identifier;
        }
        public static string GetCollection(this string identifier)
        {
            if (identifier.Contains("-"))
                return identifier.Substring(0, identifier.LastIndexOf('-'));
            else
                return identifier;
        }
    }
}
