using System;
using System.Collections.Generic;
using System.Text;

namespace VkMusic
{
    public class AudioUnit
    {
        long? id, duration;
        string artist, title;

        public AudioUnit(long? id, long? duration, string artist, string title)
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
        public long? getDuration()
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
