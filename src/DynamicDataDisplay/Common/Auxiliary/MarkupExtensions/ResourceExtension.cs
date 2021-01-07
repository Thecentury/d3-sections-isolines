﻿
namespace Microsoft.Research.DynamicDataDisplay.MarkupExtensions
{
	using System;
	using System.Windows.Markup;
	using Microsoft.Research.DynamicDataDisplay.Strings;

	/// <summary>
	/// Represents a markup extension, which allows to get an access to application resource files.
	/// </summary>
	[MarkupExtensionReturnType(typeof(string))]
	public class ResourceExtension : MarkupExtension
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ResourceExtension"/> class.
		/// </summary>
		public ResourceExtension() { }

		private string resourceKey;
		//[ConstructorArgument("resourceKey")]
		public string ResourceKey
		{
			get => resourceKey;
			set
			{
				if (resourceKey == null)
					throw new ArgumentNullException("resourceKey");

				resourceKey = value;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ResourceExtension"/> class.
		/// </summary>
		/// <param name="resourceKey">The resource key.</param>
		public ResourceExtension(string resourceKey)
		{
			if (resourceKey == null)
				throw new ArgumentNullException("resourceKey");

			this.resourceKey = resourceKey;
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return UIResources.ResourceManager.GetString(resourceKey);
		}
	}
}
