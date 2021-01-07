namespace Microsoft.Research.DynamicDataDisplay.Common
{
	using System;

	public sealed class ValueChangedEventArgs<T> : EventArgs
	{
		public ValueChangedEventArgs(T prevValue, T currValue)
		{
			this.prevValue = prevValue;
			this.currValue = currValue;
		}

		private readonly T prevValue;
		public T PreviousValue => prevValue;

		private readonly T currValue;
		public T CurrentValue => currValue;
	}
}
