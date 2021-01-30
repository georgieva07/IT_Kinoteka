using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kinoteka.Models
{
    public class Show
    {
        [Key]
        public int id { get; set; }
        public String title { get; set; }
        public String description { get; set; }
        public String image { get; set; }
        public String released_date { get; set; }
        public float rating { get; set; }
        public String type { get; set; } //movie, series, tv show
        public String play_link { get; set; }

    }
}