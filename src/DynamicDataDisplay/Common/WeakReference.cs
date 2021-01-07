namespace Microsoft.Research.DynamicDataDisplay.Common
{
	using System;

	internal sealed class WeakReference<T>
	{
		private readonly WeakReference reference;

		public WeakReference(WeakReference reference)
		{
			this.reference = reference;
		}

		public WeakReference(T referencedObject)
		{
			this.reference = new WeakReference(referencedObject);
		}

		public bool IsAlive => reference.IsAlive;

		public T Target => (T)reference.Target;
	}
}
