using System;

namespace Domain
{
    public class StateRegion
    {
        public Guid Id { get; set; }
        public string State { get; set; }
        public string Month { get; set; }
        public int NumberOfSales { get; set; }
    }
}
