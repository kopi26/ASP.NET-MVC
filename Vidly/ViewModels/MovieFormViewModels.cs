using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModels
    {
        public IEnumerable<GenreType> GenreTypes { get; set; }
        public Movie Movie { get; set; }

        public string Title
        {
            get
            {
                if (Movie.Id != 0 && Movie != null)
                    return "Edit Movie";
                
                return "New Movie";
            }
        }
    }
}