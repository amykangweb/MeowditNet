using System.ComponentModel.DataAnnotations;
using System.Linq;
using Meowdit.DAL;

namespace Meowdit.Models
{
    public class Meow
    {
        [Key]
        public int ID { get; set; }
        [Required(AllowEmptyStrings = false)]
        [UniqueMeow(ErrorMessage = "Meow already exists!")]
        public string Word { get; set; }
    }

    public class UniqueMeow : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            MeowContext db = new MeowContext();
            var meow = db.Meows.FirstOrDefault(f => f.Word == (string)value);
            return meow == null;
        }
    }
}