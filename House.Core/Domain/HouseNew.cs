using System;
using System.Collections.Generic;
using System.Text;

namespace House.Core.Domain
{
    public class HouseNew
    {
        public Guid? Id { get; set; }
        public double TotalArea { get; set; }
        public string Address { get; set; }
        public string Details { get; set; }
        public int Price { get; set; }
        public int Rooms { get; set; }
        public int Year { get; set; }
    }
}
