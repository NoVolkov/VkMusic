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

namespace VkMusic.pages
{
    /// <summary>
    /// Логика взаимодействия для listFriends.xaml
    /// </summary>
    public partial class listFriends : Page
    {
        public listFriends()
        {
            InitializeComponent();
        }

        public class friends
        {
            public string FIO { get; set; }
            private long? id { get; set; }//не знаю зачем, но надо
            public friends(long? i, string f)
            {
                id = i;
                FIO = f;
            }
        }
        //отображает список друзей
        public void LoadFriendsList()
        {
            listFriendsShow.Items.Clear();
            List<FriendUnit> list = MainWindow.vk1.GetFriendsList();
            for (int i = 0; i < list.Count; i++)
            {
                friends a1 = new friends(list[i].getIdFriend(),list[i].getFIOFriend());
                listFriendsShow.Items.Add(a1);
            }
        }
        //возвращает со страницы друзей обратно к вашей музыке
        public void return_Click(object sender, RoutedEventArgs e)
        {
            NavigationService service = NavigationService.GetNavigationService(this);
            service.Navigate(App.l1);
            App.l1.LoadAudioList(MainWindow.vk1.getIdThisUser());
        }

        //отображает музыку выбранного друга
        public void showListFriendAudios(object sender, RoutedEventArgs e)
        {
            NavigationService service = NavigationService.GetNavigationService(this);
            service.Navigate(App.l1);
            try
            {
                App.l1.LoadAudioList(MainWindow.vk1.GetFriendsList()[listFriendsShow.SelectedIndex].getIdFriend());//
            }
            catch
            {
                MessageBox.Show("Выделите строку с именем друга, или если вы увидели это сообщение снова, значит ваш друг заблокировал доступ к своей музыке, либо это ещё из-за чего-то.");
            }
        }
    }
}
