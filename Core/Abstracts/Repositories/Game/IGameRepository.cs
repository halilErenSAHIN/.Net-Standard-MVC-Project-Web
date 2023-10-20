using Core.Concrates.Entities.Game;
using ToolBox.DataTools;

namespace Core.Abstracts.Repositories.Game
{
    public interface IGameRepository : IGenericRepository<GameEntity>
    {
    }

    public interface IPlayerRepository : IGenericRepository<PlayerEntity> { }
}
