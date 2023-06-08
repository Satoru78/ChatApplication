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
	/// Логика взаимодействия для UsersList.xaml
	/// </summary>
	public partial class UsersList : Page
	{
		
		public MessAge MessAge { get; set; }
		public UserLog UserLog { get; set; }
		public List<UserLog> UserLogs { get; set; }
	
		public UsersList(UserLog userLog  )
		{
			InitializeComponent();
			UserLog = userLog;
	
			this.DataContext = this;
		
		}

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			UserLogs = DataApp.db.UserLog.ToList();
			UserListData.ItemsSource = UserLogs;
		
		}



		private void txbSeacrh_SelectionChanged(object sender, RoutedEventArgs e)
		{
			UserListData.ItemsSource = DataApp.db.UserLog.Where(item => item.UserName.Contains(txbSeacrh.Text)).ToList();

		}
		private void btnGoMessage_Click(object sender, RoutedEventArgs e)
		{
            var currentUser = UserListData.SelectedItem as UserLog;
            if (currentUser != null)
            {


               

                // Получаем родительское окно
                MainWindow mainWindow = Window.GetWindow(this) as MainWindow;

				// Передаем выбранного пользователя в метод родительского окна для отображения информации


				mainWindow.FrameMessage.Navigate(new MessagePage(currentUser));
				mainWindow.FrameMessage.Visibility = Visibility.Visible;
                mainWindow.ProfileFrame.Visibility = Visibility.Collapsed;





                //}


            }
        }

		private void UserListData_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			var currentUser = UserListData.SelectedItem as UserLog;
			if (currentUser != null)
			{




				// Получаем родительское окно
				MainWindow mainWindow = Window.GetWindow(this) as MainWindow;

				// Передаем выбранного пользователя в метод родительского окна для отображения информации


				mainWindow.FrameMessage.Navigate(new MessagePage(currentUser));
				mainWindow.FrameMessage.Visibility = Visibility.Visible;
				mainWindow.ProfileFrame.Visibility = Visibility.Collapsed;
				mainWindow.SettingFrame.Visibility = Visibility.Collapsed;





				//}


			}
		}
	}
}
