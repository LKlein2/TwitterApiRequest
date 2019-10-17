using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsonClass
{
    public class UserMentions
    {
        [JsonProperty("screen_name")]
        public string ScreenName { get; set; }
    }
}
