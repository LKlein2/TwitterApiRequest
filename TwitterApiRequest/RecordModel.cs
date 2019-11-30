using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TwitterApiRequest.Crypt;

namespace TwitterApiRequest
{
    public class RecordModel
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Date")]
        public DateTime Date { get; set; }

        [JsonProperty("Tweet")]
        public string Tweet { get; set; }

        [JsonProperty("HashTags")]
        public string HashTags { get; set; }

        [JsonProperty("UserId")]
        public long UserId { get; set; }

        [JsonProperty("ScreenName")]
        public string ScreenName { get; set; } = "";

        public RecordModel()
        {

        }

        public RecordModel(string line)
        {
            line = line + "  ";
            Id = Convert.ToInt64(line.Substring(0, 20));
            Date = DateTime.Parse(line.Substring(20,8).Insert(6, "-").Insert(4, "-"));
            Tweet = line.Substring(28, 280).Trim();
            HashTags = line.Substring(308, 280).Trim();
            UserId = Convert.ToInt64(line.Substring(589, 20));
            ScreenName = line.Substring(608, 40).Trim();
        }

        public RecordModel(string line, bool encrypt)
        {
            line = line + "  ";
            Id = Convert.ToInt64(line.Substring(0, 20));
            Date = DateTime.Parse(line.Substring(20, 8).Insert(6, "-").Insert(4, "-"));
            Tweet = line.Substring(28, 280).Trim();
            HashTags = EncryptHashtags(line.Substring(308, 280).Trim());
            UserId = Convert.ToInt64(line.Substring(589, 20));
            ScreenName = line.Substring(608, 40).Trim();
        }

        private string EncryptHashtags(string hastags)
        {
            string[] hastagArray = hastags.Split("#");
            string sReturn = "";

            if (hastagArray.Length == 0) return sReturn;

            for (int i = 1; i < hastagArray.Length; i++)
            {
                sReturn += "#" + CesarEncryper.Encrypt(hastagArray[i]);
            }
            
            return sReturn;
        }

        public override string ToString()
        {
            return $"ID: {Id} Date: {Date.ToString("dd/MM/yyyy")} \n" +
                   $"Tweet: {Tweet.Trim()}\n" +
                   $"HashTags: {HashTags.Trim()}\n" +
                   $"User id: {UserId} : {ScreenName.Trim()}";
        }
    }

    public class RecordModelMongo
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("HashTags")]
        public string HashTags { get; set; }
    }
}
