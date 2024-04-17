using System.Text.Json.Serialization;

namespace ReqResApi.DataLayer.Models
{
    public class ResponseCreateUser
    {
        public string name { get; set; }
        public string job { get; set; }
        public string id { get; set; }
        public DateTime createdAt { get; set; }
    }
}
