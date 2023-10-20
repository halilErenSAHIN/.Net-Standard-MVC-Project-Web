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
    public class GalleryRepository : GenericRepository<GalleryEntity>, IGalleryRepository
    {
        public GalleryRepository(DbContext context) : base(context) { }



    }
}
