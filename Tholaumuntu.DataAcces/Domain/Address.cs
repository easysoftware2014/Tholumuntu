namespace Tholaumuntu.DataAcces.Domain
{
    public class Address: Entity
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }

    }
}