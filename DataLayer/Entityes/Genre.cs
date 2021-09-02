using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entityes
{
    public class Genre
    {
        public int Genreid { get; set; }
        public string GenreName { get; set; }
        public int? GameId { get; set; }
    }
}
