using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace DBAdministrator.Models.Helpers
{
	public static class ReflectionHelpers
	{
		public static string GetCustomDescription<T>(T obj)
		{
			var field = typeof(T).GetField(obj.ToString());
			var description = GetCustomDescription(field);
			return description ?? obj.ToString();
		}

		public static string GetCustomDescription(FieldInfo info)
		{
			var attribute = (DescriptionAttribute)info.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();
			return attribute != null ? attribute.Description : null;
		}

		public static IList<KeyValuePair<int, string>> GetAllValuesAndDescriptions<TEnum>()
		{
			if (!typeof(TEnum).IsEnum)
				throw new ArgumentException("TEnum must be an Enumeration type");

			return Enum.GetValues(typeof(TEnum)).Cast<TEnum>()
				.Select((e) => new KeyValuePair<int, string>(Convert.ToInt32(e), GetCustomDescription(e)))
				.ToList();
		}
	}
}