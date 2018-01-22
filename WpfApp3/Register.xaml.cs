using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public  partial class Register : Page
    {
        private List<Client> users;
        public Register()
        {
            InitializeComponent();
        
        }
        private void ButtonBack(object sender,RoutedEventArgs e)
        {
            MainWindow page = new MainWindow();
            page.Show();
        }
        private void DoneRegister(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(login.Text) && !string.IsNullOrWhiteSpace(password.Text) && !string.IsNullOrWhiteSpace(RepeatPassword.Text))
            {
             
                if (password.Text != RepeatPassword.Text)
                {
                    MessageBox.Show("проверьте пароль!");
                }
                else
                {
                    Client user = new Client();
                    user.Login = login.Text;
                    user.Password = password.Text;
                    if(!string.IsNullOrWhiteSpace(mail.Text))
                    {
                        user.Email = mail.Text;
                    }
                    if(!string.IsNullOrWhiteSpace(info.Text))
                    {
                        user.Info = info.Text;
                    }
                    if(File.Exists(@"C:\data\users.json"))
                    {
                        users = JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(@"C:\data\users.json"));
                    }
                    else
                    {
                        users = new List<Client>();
                    }
                    users.Add(user);
                    using (StreamWriter stream = new StreamWriter(@"C:\data\users.json"))
                    {
                        stream.Write(JsonConvert.SerializeObject(users));
                    }
                    MainWindow page = new MainWindow();
                    page.Show();
                }
                

            }
            else
            {
                MessageBox.Show("заполните все необходимые поля!");
            }
           
            
             

        }
    }
}
