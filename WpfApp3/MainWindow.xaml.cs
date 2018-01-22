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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using WpfApp3;
namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public bool IsClient(List<Client> users,string login,string password)
        {
           foreach(var user in users)
           {
                if(user.Login==login&&user.Password==password)
                {
                    return true;
                }

           }
            return false;
        }
        private void SignIn(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(login.Text) || string.IsNullOrWhiteSpace(password.Text))
            {
                MessageBox.Show("введите логин или пароль");
            }
            else
            {
                 if (File.Exists(@"C:\data\users.json"))
                 {
                    List<Client> users = JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(@"C:\data\users.json"));
                    if (IsClient(users,login.Text,password.Text))
                    {
                       
                        Profile page = new Profile();
                        page.text.Text = "Добро пожаловать, " + login.Text;
                        this.Content = page;
                    }
                    else
                    {
                        MessageBox.Show("Неправильный логин или пароль");
                    }
                 }
                 else
                 {
                    MessageBox.Show("нету такого юзера");
                 }
            }
        }
        private void RegisterIn(object sender,RoutedEventArgs e)
        {
            this.Content = new Register();
        }
      
    }
}
