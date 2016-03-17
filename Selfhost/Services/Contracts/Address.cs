using System.Runtime.Serialization;

namespace Services.Contracts
{
    [DataContract]
    public class Address
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Street { get; set; }

        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public int Zip { get; set; }
    }
}