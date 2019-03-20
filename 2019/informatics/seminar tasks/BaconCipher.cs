using System;
using System.Collections.Generic;
using System.Text;

namespace LDsem
{
    class BaconCipher
    {
        HashSet<string> set = new HashSet<string>();
        public int GetSubstringCount(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                var substring = new StringBuilder();
                for (int j = i; j < text.Length; j++)
                {
                    substring.Append(text[j]);
                    set.Add(substring.ToString());
                }
            }
            return set.Count;
        }
    }
}
