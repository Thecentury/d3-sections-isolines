﻿namespace DynamicDataDisplay.Markers.DataSources
{
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Linq;

	internal sealed class CompositeEnumerator : IEnumerator<DynamicItem>
	{
		private readonly DataSourcePartCollection parts;
		private IEnumerator[] enumerators;

		public CompositeEnumerator(DataSourcePartCollection parts)
		{
			this.parts = parts;
			enumerators = new IEnumerator[parts.Count];
			int index = 0;
			foreach (var part in parts)
			{
				enumerators[index] = part.Collection.GetEnumerator();
				index++;
			}
		}

		public static PropertyDescriptorCollection CreatePropertyDescriptors(DataSourcePartCollection parts)
		{
			IEnumerator[] enumerators = new IEnumerator[parts.Count];

			return CreatePropertyDescriptors(parts, enumerators);
		}

		public static PropertyDescriptorCollection CreatePropertyDescriptors(DataSourcePartCollection parts, IEnumerator[] enumerators)
		{
			PropertyDescriptor[] descriptors = new PropertyDescriptor[parts.Count];

			int index = 0;
			foreach (var part in parts)
			{
				IEnumerator enumerator = enumerators[index];

				CompositeDataSourcePropertyDescriptor descriptor =
					new CompositeDataSourcePropertyDescriptor(part.PropertyName, enumerator, part.PropertyType);

				descriptors[index] = descriptor;
				index++;
			}

			// todo is there true?
			PropertyDescriptorCollection result = new PropertyDescriptorCollection(descriptors, true);
			return result;
		}

		#region IEnumerator<DynamicItem> Members

		private DynamicItem current;
		public DynamicItem Current => current;

		#endregion

		#region IDisposable Members

		public void Dispose()
		{
		}

		#endregion

		#region IEnumerator Members

		object IEnumerator.Current => Current;

		public bool MoveNext()
		{
			bool allMoveNext = enumerators.All(en => en.MoveNext());
			if (allMoveNext)
			{
				var descriptors = CreatePropertyDescriptors(parts, enumerators);
				current = new DynamicItem(descriptors);
			}
			return allMoveNext;
		}

		public void Reset()
		{
		}

		#endregion
	}
}
