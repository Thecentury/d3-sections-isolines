namespace DynamicDataDisplay.Markers.DataSources
{
	using System.ComponentModel;

	internal sealed class DynamicItem : CustomTypeDescriptor
	{
		public DynamicItem(PropertyDescriptorCollection descriptors)
		{
			this.descriptors = descriptors;
		}

		private readonly PropertyDescriptorCollection descriptors;
		public override PropertyDescriptorCollection GetProperties()
		{
			return descriptors;
		}
	}
}
