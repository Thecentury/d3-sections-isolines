﻿namespace Microsoft.Research.DynamicDataDisplay.Maps
{
	using System;
	using System.Reflection;

	internal static class Global
	{
		public static Uri MakePackUri(string relativeFile)
		{
			string uriString = "pack://application:,,,/" + AssemblyShortName + ";component/" + relativeFile;
			return new Uri(uriString);
		}

		private static string AssemblyShortName
		{
			get
			{
				if (_assemblyShortName == null)
				{
					Assembly a = typeof(Global).Assembly;

					// Pull out the short name.
					_assemblyShortName = a.ToString().Split(',')[0];
				}

				return _assemblyShortName;
			}
		}

		private static string _assemblyShortName;
	}
}
