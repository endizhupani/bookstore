using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain.Entities;

namespace BookStore.Domain.ViewModels
{
    public class TagViewModel
    {
        public int TagId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Tag name")]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Book> Books { get; set; }
    }
}
