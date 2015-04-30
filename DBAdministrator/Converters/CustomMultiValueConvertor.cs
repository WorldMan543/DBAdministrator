using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Data;
using DBAdministrator.Models;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using DBAdministrator.Models.TreeView;

namespace DBAdministrator.Converters
{
	public class CustomMultiValueConvertor : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var results = new List<object>();
			foreach (object value in values)
			{
				if (value is ObservableCollection<DatabaseStructViewModel>)
				{
					results.Add((value as ObservableCollection<DatabaseStructViewModel>).ToArray());
				}
				else if (value is ObservableCollection<TableStructViewModel>)
				{
					results.Add((value as ObservableCollection<TableStructViewModel>).ToArray());
				}
				else if (value is ObservableCollection<RoleStructViewModel>)
				{
					results.Add((value as ObservableCollection<RoleStructViewModel>).ToArray());
				}
				else if (value is ObservableCollection<StoredProcedureStructViewModel>)
				{
					results.Add((value as ObservableCollection<StoredProcedureStructViewModel>).ToArray());
				}
				else if (value is ObservableCollection<UserStructViewModel>)
				{
					results.Add((value as ObservableCollection<UserStructViewModel>).ToArray());
				}
			}
			return results;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}