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
    public partial class MainWindow : Window
    {
        
        public static Vk vk1 = new VkMusic.Vk();
        public static bool Tran1;
        public MainWindow()
        {
            InitializeComponent();
            
            OpenLoginPage();
            //Коммент

        }
        void OpenLoginPage()
        {
            frame.Navigate(new login(this));
            
        }

    }
}
