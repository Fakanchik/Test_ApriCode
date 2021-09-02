using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IGameRepository
    {
        //Получение списка игр определенного жанра
        List<Game> GetGamesByGenre(string genre);
        //create game
        void CreateGame(Game game);
        //read game
        Game GetGameByName(string GameName);
        //update game
        void UpdateGame(Game game);
        //delete game
        void DeleteGame(Game game);
        //поиск игр по id
        public Game GetGameByID(int? Gameid);
        public bool CheckGenreByName(string genre);
        public bool IsGameCreated(string gameName);
        public List<Genre> GetGenreByGameName(int gameid);

    }
}
