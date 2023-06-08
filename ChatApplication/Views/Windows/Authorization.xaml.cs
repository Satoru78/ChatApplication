using ChatApplication.Context;
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
using System.Windows.Shapes;

namespace ChatApplication.Views.Windows
{
	/// <summary>
	/// Логика взаимодействия для Authorization.xaml
	/// </summary>
	public partial class Authorization : Window
	{
		public Authorization()
		{
			InitializeComponent();
		}

		private void btnLogin_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (txbLog.Text == "" && txbPass.Text == "")
				{
					throw new Exception("Заполните все поля!");
				}
				else
				{
					var currentUser = DataApp.db.UserLog.FirstOrDefault(item => item.UserName == txbLog.Text && item.Password == txbPass.Text);
					if (currentUser != null)
					{
						if (currentUser.IsBanned == true)
						{
							throw new Exception("Вы были заблокированы. Повторите попытку позже или обратитесь к администрации.");
						}
						else
						{
							switch (currentUser.IDRole)
							{
								case 1:
									var adminWindow = new AdminWindow(currentUser);
									adminWindow.ShowDialog();
									Close();
									break;
								case 2:
									var mainWindow = new MainWindow(currentUser);
									mainWindow.Show();
									Close();
									break;

							}

						}

					}
					else
					{
						throw new Exception("Пользователя не существует");
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Неизвестная ошибка");
			}
		}

		private void Hyperlink_Click(object sender, RoutedEventArgs e)
		{
			var regWin = new Registration();
			regWin.Show();
			Close();
		}

		private void btnClose_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private void Border_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				DragMove();
			}
		}
	}
}
