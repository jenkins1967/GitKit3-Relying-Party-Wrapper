using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace GitKitClient.Extensions
{
    public static class StringExtensions
    {
        public static string SplitAtCapsAndUpperCase(this string data, char splitChar)
        {
            var builder = new StringBuilder();
            data.ToList().ForEach(c =>
            {
                var chr = c.ToString(CultureInfo.InvariantCulture);
                if (builder.Length > 0 && chr.IsUpper())
                {
                    builder.Append(splitChar);
                }
                builder.Append(chr.ToUpper(CultureInfo.InvariantCulture));                
            });
            return builder.ToString();
        }

        public static bool IsUpper(this string data)
        {
            return data.Equals(data.ToUpper(CultureInfo.InvariantCulture), StringComparison.CurrentCulture);
        }
    }
}
