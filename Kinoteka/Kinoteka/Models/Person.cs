using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kinoteka.Models
{
    public class Person
    {
        [Key]
        public int id { get; set; }
        public String name { get; set; }
        public String image { get; set; }
        public String role { get; set; } //actor, host

    }
}