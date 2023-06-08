using ChatApplication.Context;
using ChatApplication.Model;
using System;
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

namespace ChatApplication.Views.Pages
{
	/// <summary>
	/// Логика взаимодействия для YourProfilePage.xaml
	/// </summary>
	public partial class YourProfilePage : Page
	{
		public UserLog UserLog { get; set; }
		public YourProfilePage(UserLog userLog)
		{
			InitializeComponent();
			UserLog = userLog;
			this.DataContext = this;
			tlbUserName.Text = $"Имя пользователя: {userLog.UserName}";
			tlbMail.Text = $"Почта: {userLog.Mail}";
			tlbPhone.Text = $"Номер телефона: {userLog.Phone}";


		}

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{

		}

		private void btnBack_Click(object sender, RoutedEventArgs e)
		{

		}

		public void btnSave_Click(object sender, RoutedEventArgs e)
		{
			
			try
			{

				if (txbStatus.Text == "")
				{
					throw new Exception("Нельзя отправить пустое сообщение");
				}
				else
				{
					UserLog.UserStatus = txbStatus.Text;
				
				}
				DataApp.db.SaveChanges();
				Page_Loaded(null, null);
				MessageBox.Show("Статус успешно сохранен", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			txbStatus.Clear();



		}

		private void txbStatus_SelectionChanged(object sender, RoutedEventArgs e)
		{
		

		}

		private void AddStatus(UserLog selectedItem)
		{ 
	
			try
			{ 

				if (txbStatus.Text == "")
				{
					throw new Exception("Нельзя отправить пустое сообщение");
				}
				else 
				{
				 selectedItem.UserStatus = txbStatus.Text;
					DataApp.db.UserLog.Add(selectedItem);
				}



				DataApp.db.SaveChanges();
				Page_Loaded(null, null);
				MessageBox.Show("Статус успешно сохранен", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			txbStatus.Clear();
		}

		private void txbStatus_KeyDown(object sender, KeyEventArgs e)
		{
			var selectedItem = (sender as TextBox).DataContext as UserLog;
			if (selectedItem != null)
			{
				AddStatus(selectedItem);
			}
			//if (e.Key == Key.Enter)
			//{
			//	//var userLog = DataApp.db.UserLog.Fi(x => x.StatusUser.Contains(txbStatus.Text));
			//	//var userLog = (sender as TextBox).DataContext as UserLog;

			//	try
			//	{
			//		if (txbStatus.Text == "")
			//		{
			//			throw new Exception("Нельзя отправить пустое сообщение");
			//		}
			//		else 
			//		{
			//			userLog.StatusUser = txbStatus.Text;
			//			DataApp.db.UserLog.Add(userLog);
			//		}

			//			//var status1 = (sender as TextBox).DataContext as UserLog;



			//		DataApp.db.SaveChanges();
			//		Page_Loaded(null, null);
			//		MessageBox.Show("Статус успешно сохранен", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);	

			//	}
			//	catch (Exception ex)
			//	{
			//		MessageBox.Show(ex.Message);
			//	}
			//	txbStatus.Clear();

		}			
			
		
	}
}
