﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCSharp
{
	public static class ExtensionMethodsTest
	{
		// TODO extend an already existing .NET class
		public static string NewToStringUpper(this string str)
		{
			return str.ToUpper();
		}
	}
}
