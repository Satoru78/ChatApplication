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
    /// Логика взаимодействия для AdminUserPage.xaml
    /// </summary>
    public partial class AdminUserPage : Page
    {
        public UserLog UserLog { get;set; }
        public List<UserLog> UserLogs { get; set; }
        public AdminUserPage( UserLog userLog)
        {
            InitializeComponent();
            UserLog = userLog;
            this.DataContext = this;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UserLogs = DataApp.db.UserLog.ToList();
            UserListView.ItemsSource = UserLogs;
        }
    }
}
