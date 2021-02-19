using BCT.SwaggerAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCT.SwaggerAPI.Services
{
    public interface ICustomerIssuesService
    {
        int Add(CustomerIssues customerIssues);
        int AddRange(IEnumerable<CustomerIssues> customerIssues);
        IEnumerable<CustomerIssues> GetAll();
        CustomerIssues Find(int id);
        int Remove(int id);
        int Update(CustomerIssues customerIssues, int id);
    }
}
