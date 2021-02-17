using BCT.SwaggerAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCT.SwaggerAPI.Services
{
    public interface ICustomerService
    {
        int Add(Customer customer);
        int AddRange(IEnumerable<Customer> customers);
        IEnumerable<Customer> GetAll();
        Customer Find(int id);
        int Remove(int id);
        int Update(Customer customer, int id);
    }
}
