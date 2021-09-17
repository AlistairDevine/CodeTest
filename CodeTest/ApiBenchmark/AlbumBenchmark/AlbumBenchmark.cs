using BenchmarkDotNet.Attributes;
using CodeTest.Controllers;
using CodeTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBenchmark.AlbumBenchmark
{
    [MemoryDiagnoser]
    public class AlbumBenchmark
    {
        public const int id = 1;

        //RESEARCH : Implement an interface for the controller???
        private static readonly AlbumController _album = new AlbumController();

        [Benchmark(Baseline = true)]
        public void GetAlbums()
        {
            _album.GetAlbumsController();
        }

        [Benchmark(Baseline = true)]
        public void GetAlbumById()
        {
            _album.GetAlbumById(id);
        }
    }
}
