﻿using DataLayer.Repositories;

namespace DataLayer
{
    public class UnitOfWork
    {
        public UserRepository Users { get; }
        public OrderRepository Orders{ get; }
        public PartRepository Parts { get; }
        public OrderPartRepository OrderParts { get; }

        private readonly AppDbContext _dbContext;

        public UnitOfWork
        (
            AppDbContext dbContext,
            UserRepository users,
            OrderRepository orders,
            OrderPartRepository orderParts,
            PartRepository parts
        )
        {
            _dbContext = dbContext;
            Users = users;
            Orders = orders;
            OrderParts = orderParts;
            Parts = parts;
        }

        public void SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch(Exception exception)
            {
                var errorMessage = "Error when saving to the database: "
                    + $"{exception.Message}\n\n"
                    + $"{exception.InnerException}\n\n"
                    + $"{exception.StackTrace}\n\n";

                Console.WriteLine(errorMessage);
            }
        }
    }
}
