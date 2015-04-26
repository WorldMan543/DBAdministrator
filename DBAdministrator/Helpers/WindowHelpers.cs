using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DBAdministrator.Helpers
{
	public static class WindowHelpers
	{
		public static bool IsValid(this DependencyObject node)
		{
			if (node != null)
			{
				var isValid = !Validation.GetHasError(node);
				if (!isValid)
				{
					var element = node as IInputElement;
					if (element != null) Keyboard.Focus(element);
					return false;
				}
				return LogicalTreeHelper.GetChildren(node).OfType<DependencyObject>().All(IsValid);
			}
			return true;
			
		}
	}
}