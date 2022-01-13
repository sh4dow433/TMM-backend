using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TMM_backend.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
     
        [Required]
        public string Title { get; set; }

        [Required]
        public string Message { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
