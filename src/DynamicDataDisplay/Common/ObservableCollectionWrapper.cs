namespace Microsoft.Research.DynamicDataDisplay.Common
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Collections.Specialized;

	public class ObservableCollectionWrapper<T> : INotifyCollectionChanged, IList<T>
	{
		public ObservableCollectionWrapper() : this(new ObservableCollection<T>()) { }

		private readonly ObservableCollection<T> collection;
		public ObservableCollectionWrapper(ObservableCollection<T> collection)
		{
			if (collection == null)
				throw new ArgumentNullException("collection");

			this.collection = collection;
			collection.CollectionChanged += collection_CollectionChanged;
		}

		private int attemptsToRaiseChanged;
		private bool raiseEvents = true;

		public bool RaisingEvents => raiseEvents;

		private void collection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			attemptsToRaiseChanged++;
			if (raiseEvents)
			{
				CollectionChanged.Raise(this, e);
			}
		}

		#region Update methods

		public void BeginUpdate()
		{
			attemptsToRaiseChanged = 0;
			raiseEvents = false;
		}
		public void EndUpdate()
		{
			raiseEvents = true;
			if (attemptsToRaiseChanged > 0)
				CollectionChanged.Raise(this);
		}

		public IDisposable BlockEvents()
		{
			return new EventBlocker<T>(this);
		}

		private sealed class EventBlocker<TT> : IDisposable
		{
			private readonly ObservableCollectionWrapper<TT> collection;
			public EventBlocker(ObservableCollectionWrapper<TT> collection)
			{
				this.collection = collection;
				collection.BeginUpdate();
			}

			#region IDisposable Members

			public void Dispose()
			{
				collection.EndUpdate();
			}

			#endregion
		}

		#endregion // end of Update methods

		#region IList<T> Members

		public int IndexOf(T item)
		{
			return collection.IndexOf(item);
		}

		public void Insert(int index, T item)
		{
			collection.Insert(index, item);
		}

		public void RemoveAt(int index)
		{
			collection.RemoveAt(index);
		}

		public T this[int index]
		{
			get => collection[index];
			set => collection[index] = value;
		}

		#endregion

		#region ICollection<T> Members

		public void Add(T item)
		{
			collection.Add(item);
		}

		public void Clear()
		{
			collection.Clear();
		}

		public bool Contains(T item)
		{
			return collection.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			collection.CopyTo(array, arrayIndex);
		}

		public int Count => collection.Count;

		public bool IsReadOnly => throw new NotImplementedException();

		public bool Remove(T item)
		{
			return collection.Remove(item);
		}

		#endregion

		#region IEnumerable<T> Members

		public IEnumerator<T> GetEnumerator()
		{
			return collection.GetEnumerator();
		}

		#endregion

		#region IEnumerable Members

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#endregion

		#region INotifyCollectionChanged Members

		public event NotifyCollectionChangedEventHandler CollectionChanged;

		#endregion
	}
}
