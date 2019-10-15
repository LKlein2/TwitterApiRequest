using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsonClass
{
    public class TwitterJson
    {
        [JsonProperty("statuses")]
        public Status[] Statuses { get; set; }
    }
}
