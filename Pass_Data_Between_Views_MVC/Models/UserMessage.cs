using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Pass_Data_Between_Views_MVC.Models
{

    public class UserMessage
    {
        [DisplayName("event")]
        public string _event { get; set; }
        public long timestamp { get; set; }
        public long message_token { get; set; }
        public Sender sender { get; set; }
        public Message message { get; set; }
    }

    public class Sender
    {
        public string id { get; set; }
        public string name { get; set; }
        public string avatar { get; set; }
        public string country { get; set; }
        public string language { get; set; }
        public int api_version { get; set; }
    }

    public class Message
    {
        public string type { get; set; }
        public string text { get; set; }
        public string media { get; set; }
        public Location location { get; set; }
        public string tracking_data { get; set; }
    }

    public class Location
    {
        public float lat { get; set; }
        public float lon { get; set; }
    }

}
