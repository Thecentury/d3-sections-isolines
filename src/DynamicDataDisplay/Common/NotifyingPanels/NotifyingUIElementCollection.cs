namespace Microsoft.Research.DynamicDataDisplay.Common
{
	using System;
	using System.Collections.Specialized;
	using System.Windows;
	using System.Windows.Controls;

	internal sealed class NotifyingUIElementCollection : UIElementCollection, INotifyCollectionChanged
	{
		public NotifyingUIElementCollection(UIElement visualParent, FrameworkElement logicalParent)
			: base(visualParent, logicalParent)
		{
			collection.CollectionChanged += OnCollectionChanged;
		}

		private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			CollectionChanged.Raise(this, e);
		}

		#region Overrides

		private readonly D3UIElementCollection collection = new D3UIElementCollection();

		public override int Add(UIElement element)
		{
			collection.Add(element);
			return base.Add(element);
		}

		public override void Clear()
		{
			collection.Clear();
			base.Clear();
		}

		public override void Insert(int index, UIElement element)
		{
			collection.Insert(index, element);
			base.Insert(index, element);
		}

		public override void Remove(UIElement element)
		{
			collection.Remove(element);
			base.Remove(element);
		}

		public override void RemoveAt(int index)
		{
			collection.RemoveAt(index);
			base.RemoveAt(index);
		}

		public override void RemoveRange(int index, int count)
		{
			for (int i = index; i < index + count; i++)
			{
				collection.RemoveAt(i);
			}
			base.RemoveRange(index, count);
		}

		public override UIElement this[int index]
		{
			get => base[index];
			set
			{
				collection[index] = value;
				base[index] = value;
			}
		}

		public override int Count => collection.Count;

		#endregion

		#region INotifyCollectionChanged Members

		public event NotifyCollectionChangedEventHandler CollectionChanged;

		#endregion
	}

	internal sealed class D3UIElementCollection : D3Collection<UIElement>
	{
		protected override void OnItemAdding(UIElement item)
		{
			if (item == null)
				throw new ArgumentNullException("item");
		}
	}
}
