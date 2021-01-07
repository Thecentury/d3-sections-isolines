namespace Microsoft.Research.DynamicDataDisplay.Charts.Selectors
{
	using System.Collections.ObjectModel;
	using System.Collections.Specialized;

	public class SelectorObservableCollection<T> : ObservableCollection<T>
	{
		private bool changing;

		public bool Changing => changing;

		protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
		{
			changing = true;
			base.OnCollectionChanged(e);
			changing = false;
		}
	}
}
