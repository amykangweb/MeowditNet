using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Meowdit.Models
{
    public class Meow
    {
        [Key]
        public int ID { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Word { get; set; }
    }
}