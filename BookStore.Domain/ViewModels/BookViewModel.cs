﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain.Entities;

namespace BookStore.Domain.ViewModels
{
    public class BookViewModel
    {
        
        public int BookId { get; set; }

        [StringLength(100)]
        [Required]
        public string Title { get; set; }

        [StringLength(100)]
        [Required]
        public string Author { get; set; }

        [StringLength(1000)]
        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Number of pages")]
        public int NumberOfPages { get; set; }

        [Display(Name = "Publication date")]
        public DateTime PublicationDate { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
