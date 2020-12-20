using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VkNet;
using VkNet.AudioBypassService.Extensions;
using VkNet.Model;
using VkNet.Enums.Filters;
using Microsoft.Extensions.DependencyInjection;
using VkNet.Model.RequestParams;
using VkMusic;
using VkMusic.pages;
namespace VkMusic.pages
{
    /// <summary>
    /// Логика взаимодействия для login.xaml
    /// </summary>
    public partial class login : Page
    {
        public MainWindow mainW;
        
        public login()//MainWindow _mainW
        {
            InitializeComponent();
            /*mainW = _mainW;*/
        }
        //авто вход
        public void AutoEnter()
        {
            if (LoginFile.ReadAuto())
            {
                Tlogin.Text = LoginFile.ReadLog()[0];
                Tpassword.Password = LoginFile.ReadLog()[1];
                enter_Click(new Object(),new RoutedEventArgs());
            }
        }
        //вход по кнопке и переход на страницу вашей музыки
        private void enter_Click(object sender, RoutedEventArgs e)
        {
            if (Tlogin.Text != "")
            {
                if (Tpassword.Password != "")
                {
                    //в main объект статический (иначе не работает, не понял по чему), обращаться из вне main
                    //т.к. метод возвращает true/false, надо придумать, как сделать переход с login на list
                    if(MainWindow.vk1.Auth(new string(Tlogin.Text), new string(Tpassword.Password))!=true)
                    {
                        MessageBox.Show("Неправильный логин или пароль.");
                        return;
                    }
                    //
                    /*MessageBox.Show(LoginFile.ReadAuto());*/
                    //MainWindow.vk1.getAud();
                    /*if (LoginFile.ReadAuto() == true)
                    {
                        MessageBox.Show("$$$");
                        LoginFile.RecLog(new string(Tlogin.Text), new string(Tpassword.Password));
                    }*/
                }
            }

            NavigationService service = NavigationService.GetNavigationService(this);
            service.Navigate(App.l1);
            App.l1.MesAutUser();
            App.l1.LoadAudioList(MainWindow.vk1.getIdThisUser());
        }
        //Запомнить данные для входа
        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            LoginFile.RecAuto(true);
        }
        //Раззпомнить данные для входа
        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            LoginFile.RecAuto(false);
        }



    }
}
