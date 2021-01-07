namespace Microsoft.Research.DynamicDataDisplay.Charts.Isolines
{
	using System;
	using System.Runtime.Serialization;

	/// <summary>
	/// Exception that is thrown when error occurs while building isolines.
	/// </summary>
	[Serializable]
	public sealed class IsolineGenerationException : Exception
	{
		internal IsolineGenerationException() { }
		internal IsolineGenerationException(string message) : base(message) { }
		internal IsolineGenerationException(string message, Exception inner) : base(message, inner) { }
		internal IsolineGenerationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}
