using System;
using System.Collections.Generic;
using System.Text;
using VkNet;
using VkNet.AudioBypassService.Extensions;
using VkNet.Model;
using VkNet.Enums.Filters;
using Microsoft.Extensions.DependencyInjection;
using VkNet.Model.RequestParams;
using Microsoft.VisualBasic;
using System.Windows;
using VkMusic.pages;

namespace VkMusic
{
    public class Vk
    {
        //благодаря этому всё работает
        public VkApi vk = new VkApi(new ServiceCollection().AddAudioBypass());


     
        //вход в аккаунт Вк
        public bool Auth(string l, string pw)
        {
            try
            {
                vk.Authorize(new ApiAuthParams()
                {
                    Login = l,//
                    Password = pw,//
                    ApplicationId = 7658887,
                    Settings = Settings.All,

                     TwoFactorAuthorization = () =>
                     {
                         TwoFactor twoFactor = new TwoFactor();
                         twoFactor.Show();
                         return twoFactor.getCode();
                         
                     }
                });

                if(MainWindow.vk1.vk.IsAuthorized==true) return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
        //выход из Вк
        public string LogOut()
        {
            MainWindow.vk1.vk.LogOut();
            if (MainWindow.vk1.vk.IsAuthorized == false)
            {
                return "Вы вышли из под своей учётной записи.";
            }
            else
            {
                return "По неизвестной причине вы не вышли из под своей учётной записи. Закройте программу и попробуйте снова выйти.";
            }
        }
        //Audio.Get(new AudioGetParams{OwnerId}).TotalCount----кол-во аудио
        //MainWindow.vk.LogOut()-выход из системы

        //id текущего пользователя
        public long? getIdThisUser()
        {
                return vk.UserId.Value;
        }
        //для отображения сообщения под кем вы вошли
        public IEnumerable<long> getIdThisUserIEnum()
        {
            return new long[] { vk.UserId.Value };
        }
        public string getNameUser(System.Collections.Generic.IEnumerable<long> id)
        {
            string fn, ln;
            fn = vk.Users.Get(id, new ProfileFields() { })[0].FirstName;
            ln = vk.Users.Get(id, new ProfileFields() { })[0].LastName;
            return fn + " " + ln;
        }
        
        //возвращает List бесед
        /*public List<> getChats()
        {
            //https://vk.com/dev/messages.getConversations
            MainWindow.vk1.vk.Messages.GetConversations(
                new GetConversationsParams
                {
                    
                });

        }*/
        //возвращает List друзей
        public List<FriendUnit> GetFriendsList()
        {
            VkNet.Utils.VkCollection<User> friends = MainWindow.vk1.vk.Friends.Get(
                new FriendsGetParams
                {
                    Fields = ProfileFields.FirstName
                }) ;
            List<FriendUnit> res = new List<FriendUnit>();
            foreach(User f in friends)
            {
                res.Add(
                        new FriendUnit(f.Id, f.FirstName +" "+ f.LastName)
                    );
            }
            return res;
        }
        //возвращает List всех аудио
        public List<AudioUnit> GetAudiosList(long? Id)
        {
            VkNet.Utils.VkCollection<VkNet.Model.Attachments.Audio> audios = vk.Audio.Get(
                    new AudioGetParams
                    {
                        OwnerId = Id
                    });
            List<AudioUnit> res = new List<AudioUnit>();
            
            foreach (VkNet.Model.Attachments.Audio a in audios)
            {
                res.Add(
                    new AudioUnit(a.Id, interMin(a.Duration), a.Artist, a.Title, a.Url)
                    );
                /*Console.WriteLine(a.Url);
                Console.WriteLine("hello wrld");*/
                
                
                
            }
            return res;
        }
        //переводит секунды в минуты для музыки
        public string interMin(int t)
        {
            string s = "";
            s += t / 60 +":"+ t % 60;
            return s;
        }
        //отправка тестового сообщения
        public void test(string n)
        {
            MainWindow.vk1.vk.Messages.Send(
                new MessagesSendParams
                {
                    PeerId = 238254422,
                    RandomId = new Random().Next(999999),
                    Message = n
                });
        }
    }
}
