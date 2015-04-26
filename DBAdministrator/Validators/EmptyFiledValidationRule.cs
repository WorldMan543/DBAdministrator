using System;
using System.Globalization;
using System.Windows.Controls;

namespace DBAdministrator.Validators
{
	public class EmptyFiledValidationRule : ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			var stringValue = Convert.ToString(value);
			return string.IsNullOrWhiteSpace(stringValue)
				? new ValidationResult(false, "Value can not be empty")
				: new ValidationResult(true, null);
		}
	}
}