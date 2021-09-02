using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entityes
{
    public class Game
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string StudioDeveloper { get; set; }
        public List<Genre> Genres { get; set; }
        public Game()
        {
            Genres = new List<Genre>();
        }
    }
}
