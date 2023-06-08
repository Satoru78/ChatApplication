using ChatApplication.Context;
using ChatApplication.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для Reqistration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void btnRegAcc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txbMail.Text == "" && txbLogin.Text == "" && txbPhone.Text == "" && txbPassword.Text == "")
                {
                    throw new Exception("Заполните все поля!");
                }
                else
                {
                    UserLog userLog = new UserLog();
                    if (userLog.ID == 0)
                    {
                        userLog.IDRole = 2;
                        userLog.Mail = txbMail.Text;
                        userLog.UserName = txbLogin.Text;
                        userLog.Phone = txbPhone.Text;
                        userLog.Password = txbPassword.Text;
                        userLog.GetPhoto = "\\images\\" + System.IO.Path.GetFileName(opeFile.FileName);
                        DataApp.db.UserLog.Add(userLog);
                    }
                    File.Copy(opeFile.FileName, $"images\\{System.IO.Path.GetFileName(opeFile.FileName).Trim()}", true);
                    userLog.GetPhoto = "\\images\\" + System.IO.Path.GetFileName(opeFile.FileName);
                    DataApp.db.SaveChanges();
                    MessageBox.Show("Регистрация прошла успешно!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    var autWin = new Authorization();
                    autWin.Show();
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Неизвестная ошибка");
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

		private void Hyperlink_Click(object sender, RoutedEventArgs e)
		{
            var autWin = new Authorization();
            autWin.Show();
            Close();
        }

        OpenFileDialog opeFile = new OpenFileDialog();

        private void btnAddUserPhoto_Click(object sender, RoutedEventArgs e)
        {
            opeFile.Filter = "Image (*.jpg;*.jpeg;*.png;) |  *.jpg; *.jpeg; *.png";
            if (opeFile.ShowDialog() == true)
            {
                BitmapImage image = new BitmapImage(new Uri(opeFile.FileName));
                imgUser.Source = image;
            }
        }
    }
}
