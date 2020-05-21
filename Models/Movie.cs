using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SFF_Api_App.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public int Stock { get; set; }

        public string StudioName { get; set; }

        public Studio Studio { get; set; }

        public bool MaxStock { get; set; }

        public int  MaxStudios { get; set; }

        public int TriviasId  { get; set; }
        public int ReviewId { get; set; }

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
