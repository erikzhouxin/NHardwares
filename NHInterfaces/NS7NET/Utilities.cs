using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.NS7NET
{
    internal class Utilities
    {
		// Token: 0x06000079 RID: 121 RVA: 0x000067C0 File Offset: 0x000049C0
		internal static uint ComputeStringHash(string s)
		{
			uint num = 0;
			if (s != null)
			{
				num = 2166136261U;
				for (int i = 0; i < s.Length; i++)
				{
					num = ((uint)s[i] ^ num) * 16777619U;
				}
			}
			return num;
		}
	}
}
