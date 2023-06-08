using ChatApplication.Context;
using ChatApplication.Model;
using ChatApplication.Views.Pages;
using ChatApplication.Views.Windows;
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

namespace ChatApplication
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public UserLog UserLog { get; set; }
		public MainWindow(UserLog userLog)
		{
			InitializeComponent();
			UserLog = userLog;
			this.DataContext = this;
			UserFrame.Navigate(new UsersList(new UserLog()));
            //FrameMessage.Navigate(new MessagePage(new UserLog()));

            imgUser.ImageSource = new BitmapImage(new Uri(userLog.GetPhoto));
            tlbUserName.Content = $"{userLog.UserName}";
			tlbUserStatus.Content = $"{userLog.UserStatus}";
		}

		private void btnGoProfile_Click(object sender, RoutedEventArgs e)
		{
			var userProf = DataApp.db.UserLog.FirstOrDefault(x => x.UserName == tlbUserName.Content.ToString());
			
			if (userProf != null)
			{
               
				ProfileFrame.Navigate(new YourProfilePage(userProf));
				ProfileFrame.Visibility = Visibility.Visible;
                FrameMessage.Visibility = Visibility.Collapsed;
            }
		
		}

		private void btnBackAuth_Click(object sender, RoutedEventArgs e)
		{
			var autWin = new Authorization();
			autWin.Show();
			Close();
		}

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
			SettingFrame.Navigate(new SettingsPage());
        }



		private void btnSett_Click(object sender, RoutedEventArgs e)
		{
			SettingFrame.Navigate(new SettingsPage());
			SettingFrame.Visibility = Visibility.Visible;
			ProfileFrame.Visibility = Visibility.Collapsed;
			FrameMessage.Visibility = Visibility.Collapsed;
		}
	}
}
