namespace Microsoft.Research.DynamicDataDisplay
{
	using System;
	using System.Diagnostics;

	[Conditional("DEBUG")]
	[AttributeUsage(AttributeTargets.Property)]
	internal sealed class NotNullAttribute : Attribute
	{
	}
}
