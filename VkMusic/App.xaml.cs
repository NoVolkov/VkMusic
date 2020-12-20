using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace VkMusic
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    
    public partial class App : Application
    {
        //основные страницы
        public static pages.login log1 = new pages.login();//страница входа
        public static pages.list l1 = new pages.list();//страница музыки
        public static pages.listFriends lf1 = new pages.listFriends();//страница друзей
    }
}
