﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required,  Display(Name = "Release Date")]
        
        public DateTime ReleaseDate { get; set; }
        
        public DateTime DateAdded { get; set; }
        
        [Display(Name = "Number in Stocks")]
        [NumberInStockRule]
        public int NumberInStocks { get; set; }

        public int NumberAvailable { get; set; }

        [Required(ErrorMessage = "Please select a Genre")]
        public Genre Genre { get; set; }

        [Required(ErrorMessage = "Please select a Genre")]
        public int GenreId { get; set; }
    }
}