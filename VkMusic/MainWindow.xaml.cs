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
using VkMusic.pages;
using VkNet;
using VkNet.AudioBypassService;
using VkNet.AudioBypassService.Extensions;
using VkNet.Model;
using VkNet.Enums.Filters;
using Microsoft.Extensions.DependencyInjection;
using VkNet.Model.RequestParams;

namespace VkMusic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        //благодаря этому всё работает ещё лучше
        public static Vk vk1 = new VkMusic.Vk();
        public static long? lastId { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            /* App.log1.AutoEnter();*/
            //MessageBox.Show(LoginFile.ReadAuto().ToString());
            OpenLoginPage();
            //Коммент
        }
        //запускается программа от сюда
        void OpenLoginPage()
        {
           App.log1.AutoEnter();
            frame.Navigate(App.log1);
        }
    }
}
