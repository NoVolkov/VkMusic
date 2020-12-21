using System;
using System.Collections.Generic;
using System.Text;

namespace VkMusic
{
    public class AudioUnit
    {
        long? id;
        string duration, artist, title;
        Uri url;
        public AudioUnit(long? id, string duration, string artist, string title, Uri url)
        {
            this.id = id;
            this.duration = duration;
            this.artist = artist;
            this.title = title;
            this.url = url;
        }


        /*
*     Console.WriteLine($" >{num2} {audio.Artist} - {audio.Title}");
try
{
   string[] textArray1 = new string[] { folderPath, @"\Documents\VKmusic\", num2.ToString(), ". ", audio.Title.ToString(), ".mp3" };
   _api.Audio.Download(audio.Url, string.Concat(textArray1));
}

*/
        public Download GetDownload()
        {
            return new Download(this.title, this.url);
        }
        public long? getId()
        {
            return id;
        }
        public string getDuration()
        {
            return duration;
        }
        public string getArtist()
        {
            return artist;
        }
        public string getTitle()
        {
            return title;
        }
        public Uri GetUrl()
        {
            return url;
        }
        
    }
}
