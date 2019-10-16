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
    }
}
