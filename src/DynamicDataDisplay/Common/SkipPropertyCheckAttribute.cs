namespace Microsoft.Research.DynamicDataDisplay.Common
{
	using System;
	using System.Diagnostics;

	[Conditional("DEBUG")]
	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	internal sealed class SkipPropertyCheckAttribute : Attribute
	{
	}
}
