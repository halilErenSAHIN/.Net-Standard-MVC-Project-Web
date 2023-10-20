using Core.Abstracts.Repositories.Data;
using Core.Concrates.Entities.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.DataTools;

namespace class1.Repositories.Data
{
    public class MediaRepository : GenericRepository<MediaEntity>, IMediaRepository
    {

        public MediaRepository(DbContext context) : base(context) { }


    }
}
