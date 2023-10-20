using Core.Abstracts.Repositories.Game;
using Core.Concrates.Entities.Game;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.DataTools;

namespace class1.Repositories.Game
{


    public class GameRepository : GenericRepository<GameEntity>, IGameRepository
    {
        public GameRepository(DbContext context) : base(context) { }
    }

}
