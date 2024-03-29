﻿using GloveWizard.Data.Contexts;
using GloveWizard.Infrastructure.Entities;
using GloveWizard.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GloveWizard.Infrastructure.Repositores
{
    public class CustomersRepository : GenericRepository<Customers>, ICustomersRepository
    {
        public CustomersRepository(DataContext context, ILogger logger)
            : base(context, logger) { }

        public override async Task<IEnumerable<Customers>> GetAllAsync()
        {
            return await _context.Customers.Include(Customers => Customers.Contacts).ToListAsync();
        }

        public override async Task<Customers> GetByIdAsync(int id)
        {
            return await _context.Customers
                .Include(Customers => Customers.Contacts)
                .Where(x => x.CustomerID == id)
                .FirstOrDefaultAsync();
        }
    }
}
