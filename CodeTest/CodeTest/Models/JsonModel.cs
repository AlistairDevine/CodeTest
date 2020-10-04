using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CodeTest.Models
{
    public class JsonModel
    {
        List<AlbumModel> Albums = new List<AlbumModel>();
        List<PhotoModel> Photos = new List<PhotoModel>();
    }
}
