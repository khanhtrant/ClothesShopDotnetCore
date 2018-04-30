using System.Collections.Generic;
using ClothesShopDotnetCore.Entities;

namespace ClothesShopDotnetCore.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employees> GetEmployees();
        Employees GetEmployee(int employeeId);
    }
}