using System;
using System.Collections.Generic;
using System.Text;

namespace VkMusic
{
    public class FriendUnit
    {
        private long? id;
        private string fio;
        public FriendUnit(long? i, string f)
        {
            id = i;
            fio = f;
        }
        public long? getIdFriend()
        {
            return id;
        }
        public string getFIOFriend()
        {
            return fio;
        }
    }
}
