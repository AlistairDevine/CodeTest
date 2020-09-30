using CodeTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CodeTest.Services
{
    public class AlbumAndPhotoService
    {
        //Interface????
        public List<PhotoModel> Photos { get; set; }
        public List<AlbumModel> Albums { get; set; }

        public AlbumAndPhotoService()
        {
            //Combine them??????????????
            //(Album) One-to-Many (Photos) relationship
            List<object> data = new List<object>(Albums.Count + Photos.Count);
            data.AddRange(Albums);
            data.AddRange(Photos);
        }

        //GET all Album data
        public List<AlbumModel> GetAllAlbumData()
        {
            return Albums.ToList();
        }
        //GET all Photo data
        public List<PhotoModel> GetAllPhotoData()
        {
            return Photos.ToList();
        }
        //GET Users by Id
        public AlbumModel GetUserById(int id)
        {
            return Albums.FirstOrDefault(x => x.UserId == id);
        }
        
    }
}
