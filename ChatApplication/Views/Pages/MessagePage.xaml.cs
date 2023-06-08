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
    /// Логика взаимодействия для MessagePage.xaml
    /// </summary>
    public partial class MessagePage : Page
    {
        public List<MessAge> MessAges { get; set; }
        public List<UserLog> UserLogs { get; set; } 
        public UserLog UserLog { get; set; }
        public MessAge MessAge { get; set; }
        public MessagePage(UserLog userLog)
        {
            InitializeComponent();
            UserLog = userLog;
            this.DataContext = this;      
            tlbNameUser.Text = $"Чат с {userLog.UserName}";
        
            //im = new BitmapImage(new Uri(userLog.GetPhoto));
            



            //var query = from msg in MessAge
            //            join usr in UserLog on msg.UserID equals usr.UserID
            //            where usr.UserID == selectedUserID
            //            select new { msg.TextR };
            //var Query = DataApp.db.MessAge.Where(X => X.IDUser == UserLog.ID);
            //var filteredMessages = Query.ToList();

            //ListMessage.ItemsSource = selectedUserID;

        }
        public void Page_Loaded(object sender, RoutedEventArgs e)
        {

            //var messages = DataApp.db.UserLog.Where(x => x.ID == MessAge.IDUser);
            var selectedUserID = UserLog.MessAge; // Здесь выбранное значение ID пользователя
            MessAges = DataApp.db.MessAge.ToList();
            UserLogs = DataApp.db.UserLog.ToList(); 
            ListMessage.ItemsSource =  selectedUserID.ToList();
          


            //MessAges = DataApp.db.MessAge.Where(item => item.IDUser.ToString().Contains());
            //ListMessage.ItemsSource = DataApp.db.MessAge.Where(item => item.IDUser.ToString().Contains(UserLog.MessAge)).ToList();

        }

        //private void LoadMess()
        // {
        //     UserLog userLog = new UserLog();
        //     var selectedUserID = userLog.MessAge; // Здесь выбранное значение ID пользователя
        //     ListMessage.ItemsSource = selectedUserID;

        // }


        //Отправка сообщения на кнопку
        private void btnMessage_Click(object sender, RoutedEventArgs e)
        {
            MessAge mess = new MessAge();
            try
            {
                if (mess.ID == 0)
                {
                    mess.TextR = txbMess.Text;
                    DataApp.db.MessAge.Add(mess);

                }
                DataApp.db.SaveChanges();

                Page_Loaded(null, null);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }



        //Отправка сообщения на Enter
        private void txbMess_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                MessAge mess = new MessAge();
                try
                {
                    if (txbMess.Text == "")
                    {
                        throw new Exception("Нельзя отправить пустое сообщение");
                    }
                    else if (mess.ID == 0)
                    {
                   
                        mess.IDUser = UserLog.ID;
                        mess.TimePush = DateTime.Now.TimeOfDay;
                        mess.TextR = txbMess.Text;
                        DataApp.db.MessAge.Add(mess);
                    }
                    DataApp.db.SaveChanges();
                    Page_Loaded(null, null);
                   


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
                txbMess.Clear();
              
            }
        }

        private void btnDelMess_Click(object sender, RoutedEventArgs e)
        {
            var selectedMess = ListMessage.SelectedItem as MessAge;
            if (selectedMess != null)
            {
                DataApp.db.MessAge.Remove(selectedMess);
            }
            DataApp.db.SaveChanges();
            Page_Loaded(null, null);
        }

        private void txbClearChat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы действительно хотите очистить чат?", "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Information) == MessageBoxResult.OK)
                {
                    var mess = DataApp.db.MessAge.ToList();
                    var selectedUserID = UserLog.MessAge; // Здесь выбранное значение ID пользователя
                    DataApp.db.MessAge.RemoveRange(selectedUserID);
                    DataApp.db.SaveChanges();
                    Page_Loaded(null, null);

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //переменная принимающая вводмиое значение
        //public bool IsInactive => string.IsNullOrEmpty(MessAge.TextR);

        ///Заполенеие поле статичными данными
		private void txbMess_LostFocus(object sender, RoutedEventArgs e)
		{
          
            //if (txbMess.Text == null)
            //{             
            //    txbMess.Text = "Введите текст...";
            //}
        }
        /// Очистка поля при вводе
		private void txbMess_GotFocus(object sender, RoutedEventArgs e)
		{
            //if (txbMess.Text != null)
            //{
            //    txbMess.Foreground = Brushes.Black;
            //    txbMess.Text = string.Empty;
            //}
        }

		private void txbMess_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
            //if (txbMess.Text == null)
            //{
            //    txbMess.Text = "Введите текст...";
            //}
            //else if (txbMess.Text != null)
            //{
            //    txbMess.Foreground = Brushes.Black;
            //    txbMess.Text = string.Empty;
            //}
        }

        private void btnEditMess_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
