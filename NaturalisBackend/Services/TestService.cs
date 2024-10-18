using NaturalisBackend.Models;
using System.Collections.Generic;
using NaturalisBackend.Database;

namespace NaturalisBackend.Services
{
    public class TestService
    {

        private readonly NaturalisContext _context;
        public TestService(NaturalisContext context)
        {
            _context = context;
        }

        public List<Test> GetAllItems()
        {

            return _context.Test.ToList();
        }
    }
}
