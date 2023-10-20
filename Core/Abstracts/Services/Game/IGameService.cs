using Core.Abstracts.Repositories.Game;
using Core.Concrates.DTOs.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts.Services.Game
{
    public interface IGameService 
    {
        IGameRepository GameRepository { get; }

        Task<IEnumerable<GameListDTO>> GetGames(Expression<Func<GameListDTO, bool>> expression = null);

        Task AddPlayer(PlayerDTO player, string uid);

    }
}
