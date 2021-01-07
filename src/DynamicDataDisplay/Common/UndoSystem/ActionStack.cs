namespace Microsoft.Research.DynamicDataDisplay.Common.UndoSystem
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;

	[DebuggerDisplay("Count = {Count}")]
	public sealed class ActionStack
	{
		private readonly Stack<UndoAction> stack = new Stack<UndoAction>();

		public void Push(UndoAction action)
		{
			stack.Push(action);

			if (stack.Count == 1)
				RaiseIsEmptyChanged();
		}

		public UndoAction Pop()
		{
			var action = stack.Pop();

			if (stack.Count == 0)
				RaiseIsEmptyChanged();

			return action;
		}

		public int Count => stack.Count;

		public void Clear()
		{
			stack.Clear();
			RaiseIsEmptyChanged();
		}

		public bool IsEmpty => stack.Count == 0;

		private void RaiseIsEmptyChanged()
		{
			IsEmptyChanged.Raise(this);
		}
		public event EventHandler IsEmptyChanged;
	}
}
