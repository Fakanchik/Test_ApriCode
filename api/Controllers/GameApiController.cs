using api.Models;
using BusinessLayer;
using DataLayer.Entityes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class GameApiController : ControllerBase
    {
        private GameManager _gameManager;
        public GameApiController(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        [HttpPost]
        [Route("api/create-game")]
        public IActionResult Create(GameRequest game)
        {
            if (ModelState.IsValid)
            {
                Game _newGame = new Game() {Name=game.Name,StudioDeveloper=game.StudioDeveloper, Genres = ReturnListGernes(game.Genres) };
                _gameManager.Games.CreateGame(_newGame);
                return Ok("Game is created.");
            }
            return BadRequest(ModelState);
        }
        [HttpGet]
        [Route("api/search-game")]
        public IActionResult Search(string gameName)
        {
            if (_gameManager.Games.IsGameCreated(gameName)) return Ok(_gameManager.Games.GetGameByName(gameName));
            else return BadRequest("Данная игра не найдена."); 
        }

        [HttpPut]
        [Route("api/update-game")]
        public IActionResult Put(GameRequest game)
        {
            if (ModelState.IsValid)
            {
                if (_gameManager.Games.IsGameCreated(game.Name))
                {
                    Game _newGame = new Game() { Name = game.Name, StudioDeveloper = game.StudioDeveloper, Genres = ReturnListGernes(game.Genres) };
                    _gameManager.Games.UpdateGame(_newGame);
                    return Ok("Game is updated.");
                }
                return BadRequest("Данная игра не найдена.");
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        [Route("api/delete-game")]
        public IActionResult Delete(string gameName)
        {
            if (ModelState.IsValid)
            {
                if (_gameManager.Games.IsGameCreated(gameName))
                {
                    Game _gameData = _gameManager.Games.GetGameByName(gameName);        
                    _gameManager.Games.DeleteGame(_gameData);
                    return Ok("Game is deleted.");
                }
                return BadRequest("Данная игра не найдена.");
            };
            return BadRequest(ModelState);
        }
        [HttpPost]
        [Route("api/search-genre")]
        public IActionResult GetGames(string Genre) 
        {
            Game[] _listGames = _gameManager.Games.GetGamesByGenre(Genre).ToArray();
            return Ok(_listGames);
        }
        private List<Genre> ReturnListGernes(string[] gernesarray)
        {
            List<Genre> _genres = new List<Genre>() { };
            for (int i = 0; i < gernesarray.Length; i++)
            {
                _genres.Add(new Genre() { GenreName = gernesarray[i] });
            }
            return _genres;
        }
    }
}
