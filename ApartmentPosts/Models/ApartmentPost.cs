using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentPosts.Models
{
    public class ApartmentPost
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int MonthlyRent { get; set; }
        public int Sqm { get; set; }
        public int NumberOfRooms { get; set; }
    }
}
