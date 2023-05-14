using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class OrderPartRepository:RepositoryBase<OrderPart>
    {
        private readonly AppDbContext dbContext;

        public OrderPartRepository(AppDbContext dbContext):base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
