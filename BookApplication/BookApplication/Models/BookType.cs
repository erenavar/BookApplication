﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookApplication.Models
{
    public class BookType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
     
    }
}
