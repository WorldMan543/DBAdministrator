﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Business.Interfaces;
using DBAdministrator.Models;

namespace DBAdministrator.Pages
{
	/// <summary>
	/// Interaction logic for EditTablePage.xaml
	/// </summary>
	public partial class EditTablePage : Page
	{
		private readonly IDataBaseAccessService _dataBaseAccessService;

		public IList<TableInfoViewModel> ViewModel { get; set; } 

		public EditTablePage(IDataBaseAccessService dataBaseAccessService, string databaseName, string tableName)
		{
			_dataBaseAccessService = dataBaseAccessService;
			ViewModel = _dataBaseAccessService.GetTableInfo(databaseName, tableName);
			InitializeComponent();
		}

		private void OnChecked(object sender, RoutedEventArgs e)
		{

		}
	}
}