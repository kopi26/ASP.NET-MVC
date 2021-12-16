using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

       [Required]
       [StringLength(255)]
        public string Name { get; set; }
        
        [Display(Name="Released Date")]
        public DateTime ReleasedDate { get; set; }
      
        public DateTime DateAdded { get; set; }
        
        [Display(Name="Number In Stock")]
        public byte NoInStocks { get; set; }

        public GenreType GenreType { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte GenreTypeId { get; set; }
    }
}
