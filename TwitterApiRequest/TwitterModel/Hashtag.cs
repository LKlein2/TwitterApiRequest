﻿using Newtonsoft.Json;

namespace JsonClass
{
    public partial class Hashtag
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}