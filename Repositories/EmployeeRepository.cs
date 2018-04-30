using System.Collections.Generic;
using System.Linq;
using ClothesShopDotnetCore.Entities;
using ClothesShopDotnetCore.Services;

namespace ClothesShopDotnetCore.Repositories
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly NorthwindContext _context;

        public EmployeeRepository(NorthwindContext context)
        {
            _context = context;
        }
        public IEnumerable<Employees> GetEmployees()
        {
            return _context.Employees
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();
        }

        public Employees GetEmployee(int employeeId)
        {
            return _context.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
        }
    }
}