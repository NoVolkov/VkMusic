using System;
using System.Collections.Generic;
using System.IO;
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
                this.tUserName.Content = "Вы вошли как: " + MainWindow.vk1.getNameUser(MainWindow.vk1.getIdThisUserIEnum());
            }
        }
        //выход из под своей учётки
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            LoginFile.RecAuto(false);
            LoginFile.DelLog();
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
            public Download dload { get; set; }
            public Uri url { get; set; }
            
            public aud(string c, string d,string t,string a, Uri u)
            {
                url = u;
                count = new string(c);
                this.duration = new string(d);
                title = new string(t);
                artist = new string(a);
                
                Download dload = new Download(t, u);
                
            }
        }
        List<AudioUnit> dLoadList;
        //отображение музыки
        public void LoadAudioList(long? id)
        {
            listAudios.Items.Clear();
            List<AudioUnit> list = MainWindow.vk1.GetAudiosList(id);
            dLoadList = list;
            int t = 1;
            for(int i = 0; i < list.Count;i++)
            {
                aud a1 = new aud(t.ToString(),
                                 list[i].getDuration(),
                                 list[i].getTitle(),
                                 list[i].getArtist(),
                                 list[i].GetUrl());
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

        [Obsolete]
        private void btn_Click(object sender, RoutedEventArgs e)
        {

            var btn_id = int.Parse((string)(sender as Button).Tag);

            string title = dLoadList[btn_id - 1].getTitle(); // MainWindow.vk1.GetAudiosList(MainWindow.lastId)[btn_id - 1].getTitle();
            Uri url = dLoadList[(int)btn_id - 1].GetUrl(); //MainWindow.vk1.GetAudiosList(MainWindow.lastId)[btn_id - 1].GetUrl();
            new Download(title, url).download();


            
            MessageBox.Show("Готово.");
        }
    }
}
