using System;

namespace Domain
{
    public class CountryRegion
    {
        public Guid Id { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
        public int NumberOfSales { get; set; }
    }
}
