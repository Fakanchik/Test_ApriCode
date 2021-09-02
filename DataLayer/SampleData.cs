using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SampleData
    {
        public static void InitData(EFDBContext context)
        {
            if (!context.Game.Any())
            {
                List<Genre> _genres = new List<Genre>() { };
                _genres.Add(new Genre() {GenreName= "Shooter" });
                _genres.Add(new Genre() { GenreName = "First-person shooter" });
                context.Game.Add(new Game() { Name = "CS:GO", StudioDeveloper = "Valve", Genres = _genres });
                context.SaveChanges();
            }
        }
    }
}
