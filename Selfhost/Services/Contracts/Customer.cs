using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FirstName{get;set;}
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public Address Address { get; set; }
    }
    [CollectionDataContract]
    public class Customers : List<Customer>
    {

    }
}
