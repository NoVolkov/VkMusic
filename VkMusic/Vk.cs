using System;
using System.Collections.Generic;
using System.Text;
using VkNet;
using VkNet.AudioBypassService.Extensions;
using VkNet.Model;
using VkNet.Enums.Filters;
using Microsoft.Extensions.DependencyInjection;
using VkNet.Model.RequestParams;

namespace VkMusic
{
    public class Vk
    {
        public VkApi vk = new VkApi(new ServiceCollection().AddAudioBypass());
        
        //public void()
        public bool Auth(string l,string pw)
        {
            try
            {
                vk.Authorize(new ApiAuthParams()
                {
                    Login = l,//+79518852022
                    Password = pw,//"Wsufy2001Kbylf"
                    ApplicationId = 7658887,
                    Settings = Settings.All
                });
                /*Console.WriteLine(vk.Audio.Get(new AudioGetParams
                {
                    OwnerId = 238254422
                }
                )[1].Title.ToString());*/
                
                return true;
            }
            catch
            {
                Console.WriteLine(l);
                return false;
            }
        }
        //Audio.Get(new AudioGetParams{OwnerId}).TotalCount----кол-во аудио
        public long getIdThisUser()
        {
            return vk.UserId.Value;
        }
        public VkNet.Utils.VkCollection<VkNet.Model.Attachments.Audio> GetAudio(long Id)
        {
             return vk.Audio.Get(
                    new AudioGetParams
                    {
                        OwnerId = Id

                    }
                    );
        }

        //возвращает List всех аудио
        public List<AudioUnit> GetAudiosList(VkNet.Utils.VkCollection<VkNet.Model.Attachments.Audio> audios)
        {
            List<AudioUnit> res = new List<AudioUnit>();
            foreach (VkNet.Model.Attachments.Audio a in audios)
            {
                res.Add(
                    new AudioUnit(a.Id, a.Duration, a.Artist, a.Title)
                    );
            }
            return res;
        }

    }
}
