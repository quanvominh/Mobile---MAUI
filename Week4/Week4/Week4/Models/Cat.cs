using Newtonsoft.Json;

namespace Week4.Models
{
    public class Cat
    {
        //[JsonProperty("status")]
        //public Status Status { get; set; }

        //[PrimaryKey]
        //[JsonProperty("_id")]
        //public string Id { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("__v")]
        public long V { get; set; }
    }

    public class Status
    {
        [JsonProperty("verified")]
        public object Verified { get; set; }

        [JsonProperty("sentCount")]
        public long SentCount { get; set; }
    }
}

