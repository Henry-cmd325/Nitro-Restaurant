using ApiNitroRestaurant.Models;

namespace ApiNitroRestaurant.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly NitroRestaurantContext _context;
        public EmployeeService(NitroRestaurantContext context)
        {
            _context = context;
        }

    }
}
