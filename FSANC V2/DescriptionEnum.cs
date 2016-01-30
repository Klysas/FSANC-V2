using System;
using System.ComponentModel;
using System.Linq;

namespace FSANC_V2
{
	/// <summary>
	/// Works with enumerators with 'Description' attributes.
	/// </summary>
	public static class DescriptionEnum
	{
		//=============================================================
		//	Public static methods
		//=============================================================

		/// <summary>
		/// NOTE: Returns one Description value for each enumerator value.
		/// </summary>
		/// <param name="type">Type of enum.</param>
		/// <returns>Array of descriptions.</returns>
		/// <exception cref="ArgumentNullException">Thrown when type is null.</exception>
		/// <exception cref="ArgumentException">Thrown when type is not enumerator.</exception>
		public static string[] GetDescriptionValues(Type type)
		{
			if (type == null) throw new ArgumentNullException("type");
			if (!type.IsEnum) throw new ArgumentException(@"Type is not enumerator.", "type");

			return (from object enumValue in type.GetEnumValues() select GetEnumDescription((Enum)enumValue)).ToArray();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="value"></param>
		/// <param name="type">Type of enum.</param>
		/// <returns>Enum value which contains given description value.</returns>
		/// <exception cref="ArgumentNullException">Thrown when type or value is null.</exception>
		/// <exception cref="ArgumentException">Thrown when type is not enumerator or value is empty.</exception>
		public static Enum GetEnumByDescription(string value, Type type)
		{
			if (value == null) throw new ArgumentNullException("value");
			if (value.Equals("")) throw new ArgumentException(@"String is empty.", "value");
			if (type == null) throw new ArgumentNullException("type");
			if (!type.IsEnum) throw new ArgumentException(@"Type is not enumerator.", "type");

			return Enum.GetValues(type).Cast<object>().Where(enumerator => value.Equals(GetEnumDescription((Enum)enumerator))).Cast<Enum>().FirstOrDefault();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="enumValue"></param>
		/// <returns>Description value of given enum value.</returns>
		/// <exception cref="ArgumentNullException">Thrown when enumValue is null.</exception>
		public static string GetEnumDescription(Enum enumValue)
		{
			if (enumValue == null) throw new ArgumentNullException("enumValue");

			var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
			var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

			return attributes.Length > 0 ? attributes[0].Description : enumValue.ToString();
		}
	}
}
