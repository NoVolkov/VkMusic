using System;
using System.Collections.Generic;
using System.Text;

namespace VkMusic
{
    public class AudioUnit
    {
        long? id;
        string duration, artist, title;

        public AudioUnit(long? id, string duration, string artist, string title)
        {
            this.id = id;
            this.duration = duration;
            this.artist = artist;
            this.title = title;
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
    }
}
