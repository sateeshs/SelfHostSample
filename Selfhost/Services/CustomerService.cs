using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerService : ICustomer
    {
        public Customers All()
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            return new Customer { Id = 1, Address = new Address { }, FirstName = "sa", LastName = "sabb" };
        }
    }
}
