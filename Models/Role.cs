using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
      [Table("[Role]")]
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Slug { get; set; }
        
    }
}