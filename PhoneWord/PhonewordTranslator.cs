using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneWord
{
    public static class PhonewordTranslator
    {
        public static string ToNumber(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw)) return null;
            raw = raw.ToUpperInvariant();

            var newNum = new StringBuilder();
            foreach (var c in raw)
            {
                if ("-0123456789".Contains(c))
                    newNum.Append(c);
                else
                {
                    var result = TranslateToNumber(c);
                    if (result != null)
                        newNum.Append(result);
                    else
                        return null;
                }
            }
            return newNum.ToString();
        }

        static bool Contains(this string keyString, char c)
        {
            return keyString.IndexOf(c) >= 0;
        }
        static readonly string[] digits = {
        "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"
    };

        static int? TranslateToNumber(char c)
        {
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i].Contains(c))
                    return 2 + i;
            }
            return null;
        }
    }
}
