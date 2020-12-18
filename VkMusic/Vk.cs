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
        
        
        public bool Auth(string l,string pw)
        {
            try
            {
                vk.Authorize(new ApiAuthParams()
                {
                    Login = l,//
                    Password = pw,//
                    ApplicationId = 7658887,
                    Settings = Settings.All
                });
                return true;
            }
            catch
            {
                Console.WriteLine(l);
                return false;
            }
        }
        //Audio.Get(new AudioGetParams{OwnerId}).TotalCount----кол-во аудио

        //id текущего пользователя
        public long getIdThisUser()
        {
            return vk.UserId.Value;
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
                    new AudioUnit(a.Id, a.Duration, a.Artist, a.Title)
                    );
            }
            return res;
        }

    }
}
