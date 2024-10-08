using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static demo_odata.Models.Enums;

namespace demo_odata.Models
{
    public class Press
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public Category Category { get; set; }
    }
}