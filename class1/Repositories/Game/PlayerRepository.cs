using Core.Abstracts.Repositories.Game;
using Core.Concrates.Entities.Game;
using System.Data.Entity;
using ToolBox.DataTools;

namespace class1.Repositories.Game
{



    public class PlayerRepository : GenericRepository<PlayerEntity>, IPlayerRepository
    {
        public PlayerRepository(DbContext context) : base(context)
        {

        }

    }

}
