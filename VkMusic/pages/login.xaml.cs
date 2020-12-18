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
namespace VkMusic.pages
{
    /// <summary>
    /// Логика взаимодействия для login.xaml
    /// </summary>
    public partial class login : Page
    {
        public MainWindow mainW;
        
        public login(MainWindow _mainW)
        {
            InitializeComponent();
            mainW = _mainW;
            
        }
      
        private void enter_Click(object sender, RoutedEventArgs e)
        {
            if (Tlogin.Text != "")
            {
                if (Tpassword.Password != "")
                {

                    MainWindow.vk1.Auth(new string(Tlogin.Text), new string(Tpassword.Password));//
                    //MainWindow.vk1.getAud();

                }
            }
        }
        
        
    }
}
