using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SallesWebMvc.Models;
using SallesWebMvc.Models.Enums;

namespace SallesWebMvc.Data
{
    public class SeedingService
    {
        
        private SallesWebMvcContext _context;

        public SeedingService(SallesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if( _context.Department.Any() || 
                _context.Seller.Any() ||
                _context.SalesRecord.Any())
            {
                return; // DB has been seeded
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Electronics");
            Department d3 = new Department(3, "Fashino");
            Department d4 = new Department(4, "Books");

            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2018, 09, 25), 11000.0, SaleStatus.Billed, s1);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1);
            _context.SalesRecord.AddRange(r1);

            _context.SaveChanges();
        } 
    }
}
