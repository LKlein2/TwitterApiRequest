using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsonClass
{
    public class StatusEntities
    {
        [JsonProperty("hashtags")]
        public List<Hashtag> Hashtags { get; set; }

        [JsonProperty("user_mentions")]
        public List<UserMentions> UserMentions { get; set; }

        public string OneLineHashtag()
        {
            string  hs = "";
            foreach (Hashtag h in this.Hashtags)
            {
                hs = hs + "#" + h.Text;
            }
            return hs;
        }
    }
}
