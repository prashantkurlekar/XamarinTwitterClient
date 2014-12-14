using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinTwitterClient.Entities
{
    public class Message
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public string ImageUri { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ReTweets { get; set; }
        public int Favorite { get; set; }
    }
}
