using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CodeTest.Models
{
    public class PhotoModel
    {
        [JsonPropertyName("id")]
        public int PhotoId { get; set; }
        [JsonPropertyName("albumId")]
        public int AlbumId { get; set; }
        [JsonPropertyName("title")]
        public string PhotoTitle { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("thumbnailUrl")]
        public string ThumbnailUrl { get; set; }
    }
}
