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
    /// Логика взаимодействия для list.xaml
    /// </summary>
    public partial class list : Page
    {
        public MainWindow mainWL;
        public list()//MainWindow _mainW
        {
            InitializeComponent();
            /*mainWL = _mainW;*/
            
        }
        //сообщение под кем вы вошли
        public void MesAutUser()
        {
            if (MainWindow.vk1.vk.IsAuthorized == true)
            {
                MainWindow.vk1.test("2");
                this.tUserName.Content = "Вы вошли как: " + MainWindow.vk1.getNameUser(MainWindow.vk1.getIdThisUserIEnum());
            }
        }
        //выход из под своей учётки
        private void exit_Click(object sender, RoutedEventArgs e)
        {
           /* LoginFile.RecAuto(false);
            LoginFile.DelLog();*/
            NavigationService service = NavigationService.GetNavigationService(this);
            MessageBox.Show(MainWindow.vk1.LogOut());
            
            service.Navigate(App.log1);
        }
        public class aud
        {
            public string count { get; set; }
            public string duration { get; set; }
            public string title { get; set; }
            public string artist { get; set; }
            public aud(string c, string d,string t,string a)
            {
                count = new string(c);
                this.duration = new string(d);
                title = new string(t);
                artist = new string(a);
            }
        }
        //отображение музыки
        public void LoadAudioList(long? id)
        {
            listAudios.Items.Clear();
            List<AudioUnit> list = MainWindow.vk1.GetAudiosList(id);
            int t = 1;
            for(int i = 0; i < list.Count;i++)
            {
                aud a1 = new aud(t.ToString(),
                                 list[i].getDuration(),
                                 list[i].getTitle(),
                                 list[i].getArtist());
                listAudios.Items.Add(a1);
                t++;
            }
        }
        //переход с музыки на друзей
        private void tListFriends_Click(object sender, RoutedEventArgs e)
        {
            NavigationService service = NavigationService.GetNavigationService(this);
            service.Navigate(App.lf1);
            App.lf1.LoadFriendsList();
        }
    }
}
