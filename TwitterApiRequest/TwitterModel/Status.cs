using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsonClass
{
    public class Status
    {
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("entities")]
        public StatusEntities Entities { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();
            //sb.Append(String.Format("{0,20} {1,40} {2,10} {3,10} {4,20} {5,280}",User.Id, User.ScreenName, User.FavouritesCount, User.FriendsCount, Id, Text.Replace("\n"," ")));
            sb.Append(String.Format("{0,20}{1,8}{2,280}{3,280}", Id, FormatedDate(), Text.Replace("\n", ""), Entities.OneLineHashtag()));
            return sb.ToString();
        }
        private string FormatedDate()
        {
            return DateTime.ParseExact(this.CreatedAt, "ddd MMM dd HH:mm:ss +ffff yyyy", new System.Globalization.CultureInfo("en-US")).ToString("yyyyMMdd");
        }

    }
}
