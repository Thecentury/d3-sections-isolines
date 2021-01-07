namespace DynamicDataDisplay.Markers.DataSources
{
	using System;
	using System.Linq;

	internal sealed class IEnumerableHelper
	{
		public static Type[] GetGenericInterfaceArgumentTypes(object collection, Type interfaceType)
		{
			Type dataType = collection.GetType();
			var interfaces = dataType.GetInterfaces();

			var types = (from @interface in interfaces
						 where @interface.IsGenericType
						 where @interface.GetGenericTypeDefinition() == interfaceType
						 let genericArgs = @interface.GetGenericArguments()
						 where genericArgs.Length > 0
						 select genericArgs).FirstOrDefault();

			return types;
		}
	}
}
