using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace demo_odata.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        public string City { get; set; }

        public string Street { get; set; }
    }
}