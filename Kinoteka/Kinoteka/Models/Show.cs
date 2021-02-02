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
		[Required]
		[Display(Name = "Title")]
		public String title { get; set; }
		[Display(Name = "Synopsis")]
		public String description { get; set; }
        [Display(Name = "Image")]
        public String image { get; set; }
		[Display(Name = "Release date")]
		public String released_date { get; set; }
		[Required]
		[Display(Name = "Rating")]
		public decimal rating { get; set; }
		[Required]
		[Display(Name = "Play")]
		public String play_link { get; set; }
		[Display(Name = "Directed by")]
		public virtual ICollection<Director> directors { get; set; }
		[Display(Name = "Stars")]
		public virtual ICollection<Actor> cast { get; set; }
        [Display(Name = "Genre")]
        public virtual ICollection<Genre> genres { get; set; }

		public Show()
		{
			this.directors = new List<Director>();
			this.cast = new List<Actor>();
			this.genres = new List<Genre>();
		}

    }
}