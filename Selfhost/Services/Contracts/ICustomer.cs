using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    [ServiceContract]
    public interface ICustomer
    {
        [OperationContract]
        Customer Get(int id);
        Customers All();
    }
}

