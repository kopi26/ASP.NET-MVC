using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModels
    {
        public IEnumerable<GenreType> GenreTypes { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Released Date")]
        public DateTime? ReleasedDate { get; set; }

        [Display(Name = "Number In Stock")]
        [Required]
        [Range(1, 20)]
        public byte? NoInStocks { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreTypeId { get; set; }

        public string Title
        {
            get
            {
               
                
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public MovieFormViewModels()
        {
            Id = 0;
        }

        public MovieFormViewModels(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleasedDate = movie.ReleasedDate;
            NoInStocks = movie.NoInStocks;
            GenreTypeId = movie.GenreTypeId;
        }
    }
}