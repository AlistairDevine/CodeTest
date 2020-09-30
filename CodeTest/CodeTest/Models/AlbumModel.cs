using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CodeTest.Models
{
    public class AlbumModel
    {
        [JsonPropertyName("id")]
        public int AlbumId { get; set; }
        [JsonPropertyName("userId")]
        public int UserId { get; set; }
        [JsonPropertyName("title")]
        public string AlbumTitle { get; set; }
    }
}
