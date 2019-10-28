using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TwitterApiRequest
{
    public class RecordModel
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Tweet { get; set; }
        public string HashTags { get; set; }
        public long UserId { get; set; }
        public string ScreenName { get; set; } = "";

        public RecordModel(string line)
        {
            Id = Convert.ToInt64(line.Substring(0, 20));
            Date = DateTime.Parse(line.Substring(20,8).Insert(6, "-").Insert(4, "-"));
            Tweet = line.Substring(28, 280);
            HashTags = line.Substring(308, 280);
            UserId = Convert.ToInt64(line.Substring(589, 20));
            ScreenName = line.Substring(607, 40);
        }

        public override string ToString()
        {
            return $"ID: {Id} Date: {Date.ToString("dd/MM/yyyy")} \n" +
                   $"Tweet: {Tweet.Trim()}\n" +
                   $"HashTags: {HashTags.Trim()}\n" +
                   $"User id: {UserId} : {ScreenName.Trim()}";
        }
    }
}
