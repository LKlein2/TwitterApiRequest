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
            //return $"Created: {CreatedAt} with id: {Id} Text: {Text}";
            return $"id_user: {User.Id} name: {User.Name} screen_name: {User.ScreenName} fallowers_count: {User.FavouritesCount} friends_count: {User.FriendsCount} id_tweet: {Id} text: {Text}";
        }
    }
}
