using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Net;
using VkNet;
using VkNet.AudioBypassService.Extensions;
namespace VkMusic
{
    public class Download
    {
        public VkApi _api;
        string title;
        Uri url;
        public Download(AudioUnit a1)
        {
            title = a1.getTitle();
            url = a1.GetUrl();
        }
        public Download(string title, Uri url)
        {
            this.title = title;
            this.url = url;
        }

        
        public void download()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddAudioBypass();
            _api = new VkApi(services);


             string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
             Directory.CreateDirectory(folderPath + @"\Downloads\VKmusic\");

             string[] textArray1 = new string[] { folderPath, @"\Downloads\VKmusic\", title.ToString(), ".mp3" };//folderPath, 
            try
            {
                MainWindow.vk1.vk.Audio.Download(url, string.Concat(textArray1));
            }
            catch
            {
                return;
            }
            
        }



    }

}

