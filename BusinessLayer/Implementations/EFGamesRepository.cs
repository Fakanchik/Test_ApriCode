using BusinessLayer.Interfaces;
using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class EFGamesRepository : IGameRepository
    {
        private EFDBContext context;
        public EFGamesRepository(EFDBContext context)
        {
            this.context = context;
        }
        public void CreateGame(Game game)
        {
            context.Game.Add(game);
            context.SaveChanges();
        }
        public Game GetGameByID(int? Gameid)
        {
            Game _game = context.Game.FirstOrDefault(x => x.id == Gameid);
            _game.Genres = GetGenreByGameName(_game.id);
            return (_game);
        }
        public Game GetGameByName(string GameName)
        {
            Game _game = context.Game.FirstOrDefault(x => x.Name == GameName);
            _game.Genres = GetGenreByGameName(_game.id);
            return (_game);
        }
        public List<Genre> GetGenreByGameName(int gameid)
        {
            Genre[] _genre = context.Genre.Where(x => x.GameId == gameid).ToArray();
            List<Genre> genres = new List<Genre>() { };
            for (int i = 0; i < _genre.Length; i++)
            {
                genres.Add(context.Genre.FirstOrDefault(x => x.GenreName == _genre[i].GenreName));
            }
            return genres;
        }
        public void UpdateGame(Game game)
        {
            var udatevalue = context.Game.SingleOrDefault(x => x.Name == game.Name);
            DeleteGenreByIdGame(udatevalue.id);
            for (int i=0; i < game.Genres.Count; i++)
            {
                game.Genres[i].GameId = udatevalue.id;
            }
            udatevalue.StudioDeveloper = game.StudioDeveloper;
            udatevalue.Genres = game.Genres;
            context.Update(udatevalue);
            context.SaveChanges();
        }
        public void DeleteGame(Game game)
        {
           // DeleteGenreByIdGame(game.id);
            //Game _DeleteGame = new Game() { id=game.id,Name=game.Name,StudioDeveloper=game.StudioDeveloper};
            context.Game.Remove(game); 
            context.SaveChanges();
        }
        public List<Game> GetGamesByGenre(string genre)
        {
            Genre[] _genre = context.Genre.Where(x => x.GenreName == genre).ToArray();
            List<Game> _gameList = new List<Game>() { }; 
            for (int i=0; i < _genre.Length; i++)
            {
                _gameList.Add(GetGameByID(_genre[i].GameId));
            }
            return _gameList;
        }
        public bool CheckGenreByName(string genre)
        {
            Genre _genre = context.Genre.FirstOrDefault(x=>x.GenreName==genre);
            if (_genre != null) return true;
            return false;
        }
        public bool IsGameCreated(string gameName)
        {
            Game _game = context.Game.FirstOrDefault(x => x.Name == gameName);
            if (_game != null) return true;
            return false;
        }
        private void DeleteGenreByIdGame(int? idGame)
        {
            Genre[] deletecotext = context.Genre.Where(x=>x.GameId==idGame).ToArray();
            for (int i = 0; i < deletecotext.Length; i++)
            {
                context.Genre.Remove(deletecotext[i]);              
            }
        }
    }
}
