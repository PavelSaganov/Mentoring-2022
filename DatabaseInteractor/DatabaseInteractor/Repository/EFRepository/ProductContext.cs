using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseInteractor.Repository.EFRepository
{
    public class ProductContext
    {
        public ProductContext(DbContextOptions<TicketManagementContext> options)
                : base(options)
        {
        }

        public DbSet<Area> Areas { get; set; }

        public DbSet<Event> Events { get; set; }
    }
}
