﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace me.cqp.luohuaming.SteamHeyboxQuery.Tool.IniConfig.Utilities
{
	internal class ReflectionUtils
	{
		internal static bool IsNullableType (Type t)
		{
			if (t == null)
			{
				throw new ArgumentNullException ("t");
			}

			return t.IsGenericType && t.GetGenericTypeDefinition () == typeof (Nullable<>);
		}
	}
}
