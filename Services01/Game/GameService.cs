using class1.Repositories.Game;
using Core.Abstracts.Repositories.Game;
using Core.Abstracts.Services.Game;
using Core.Concrates.DTOs.Game;
using Core.Concrates.Entities.Game;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Services01.Game
{
    public class GameService : IGameService
    {
        private GameContext _context;
        private GameRepository game;
        private PlayerRepository player;

        public IGameRepository GameRepository => game = game ?? new GameRepository(_context);
        public IPlayerRepository PlayerRepository => player = player ?? new PlayerRepository(_context);

        public GameService()
        {
            _context = GameContext.Create();
        }

        private static IGameService gameService;

        public static IGameService Create()
        {
            if (gameService == null)
            {
                gameService = new GameService();
            }
            return gameService;
        }






        public async Task<IEnumerable<GameListDTO>> GetGames(Expression<Func<GameListDTO, bool>> expression = null)
        {
            return from x in await game.FindAsync()
                   select new GameListDTO
                   {
                       Id = x.Id,
                       Title = x.Title,
                       SubTitle = x.SubTitle,
                       Status = x.Status,
                       Rating = x.Rating,
                       Publisher = x.Publisher.Title,
                       Developer = x.Developer.Title,
                       FeatureMedia = x.FeatureMedia,
                       Logo = x.Logo,
                       PlatformIcons = x.Platforms.Select(y => y.PlatformName.ToString())


                   };
        }
        public async Task AddPlayer(PlayerDTO player, string uid)
        {
            PlayerEntity entity = new PlayerEntity
            {
                Title = player.Name,
                UserId = uid,
            };
            await PlayerRepository.CreateAsync(entity);
            await CommitAsync();
        }

        private async Task CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                _context.Dispose();
            }

        }
    }
}
