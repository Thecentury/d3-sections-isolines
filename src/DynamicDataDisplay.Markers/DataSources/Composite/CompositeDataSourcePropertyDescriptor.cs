namespace DynamicDataDisplay.Markers.DataSources
{
	using System;
	using System.Collections;
	using System.ComponentModel;

	internal sealed class CompositeDataSourcePropertyDescriptor : PropertyDescriptor
	{
		public CompositeDataSourcePropertyDescriptor(string name, IEnumerator enumerator, Type propertyType)
			: base(name, null)
		{
			if (propertyType == null)
				throw new ArgumentNullException("propertyType");

			this.enumerator = enumerator;
			this.propertyType = propertyType;
		}

		private IEnumerator enumerator;
		public IEnumerator Enumerator
		{
			get => enumerator;
			set => enumerator = value;
		}

		private readonly Type propertyType;

		public override bool CanResetValue(object component)
		{
			return false;
		}

		public override Type ComponentType => typeof(DynamicItem);

		public override object GetValue(object component)
		{
			return enumerator.Current;
		}

		public override bool IsReadOnly =>
			// todo
			true;

		public override Type PropertyType => propertyType;

		public override void ResetValue(object component)
		{
			throw new NotSupportedException();
		}

		public override void SetValue(object component, object value)
		{
			throw new NotSupportedException();
		}

		public override bool ShouldSerializeValue(object component)
		{
			// todo
			return false;
		}
	}
}
