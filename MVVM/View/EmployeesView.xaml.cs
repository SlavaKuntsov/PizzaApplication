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

using Pizza.Manager;
using Pizza.MVVM.Model;

namespace Pizza.MVVM.View
{
	/// <summary>
	/// Логика взаимодействия для EmployeesView.xaml
	/// </summary>
	public partial class EmployeesView : UserControl
	{
		DataManager _dataManager;
		AuthManager _authManager;
		public EmployeesView()
		{
			InitializeComponent();

			_dataManager = DataManager.Instance;
			_authManager = AuthManager.Instance;
		}
		private void ListView_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
		{
			if (!e.Handled)
			{
				e.Handled = true;
				var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
				{
					RoutedEvent = UIElement.MouseWheelEvent,
					Source = sender
				};
				var parent = ((Control)sender).Parent as UIElement;
				parent?.RaiseEvent(eventArg);
			}
		}

		private async void Button_Click(object sender, RoutedEventArgs e)
		{
			Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!");

			Button clickedButton = sender as Button;
			AuthPermissionModel selectedItem = clickedButton?.DataContext as AuthPermissionModel;

			if (selectedItem != null)
			{
				Console.WriteLine("CancelOrder CLICK ---------------------");
				Console.WriteLine("selectedItem.Id: " + selectedItem.Id);

				_dataManager.DeauthorizeEmployee(selectedItem.Id);
			}
		}

		private async void Button_Click2(object sender, RoutedEventArgs e)
		{
			Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!");

			Button clickedButton = sender as Button;
			AuthPermissionModel selectedItem = clickedButton?.DataContext as AuthPermissionModel;

			if (selectedItem != null)
			{
				Console.WriteLine("CancelOrder CLICK ---------------------");
				Console.WriteLine("selectedItem.Id: " + selectedItem.Id);

				_dataManager.DeleteEmployee(selectedItem.Id);
			}
		}
	}
}
