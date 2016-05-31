using System.ComponentModel.DataAnnotations;
using System.Linq;
using Meowdit.DAL;

namespace Meowdit.Models
{
    public class Post
    {
        MeowContext db = new MeowContext();

        [Key]
        public int ID { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(255, ErrorMessage = "The title is too long. Please enter a shorter title!")]
        public string Title { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(5000, ErrorMessage = "You have exceeded the max character length.")]
        public string Content { get; set; }

        public string SetTitle()
        {
            var count = Title.Split(null).Length;
            var meows = db.Meows.OrderBy(f => System.Guid.NewGuid()).Take(count);
            var ReplacedTitle = "";
            foreach (var meow in meows)
            {
                ReplacedTitle = ReplacedTitle + " " + meow.Word;
            }
            return ReplacedTitle;
        }

        public string SetContent()
        {
            var count = Content.Split(null).Length;
            var meows = db.Meows.OrderBy(f => System.Guid.NewGuid()).Take(count);
            var ReplacedContent = "";
            foreach (var meow in meows)
            {
                ReplacedContent = ReplacedContent + " " + meow.Word;
            }
            return ReplacedContent;
        }
    }
}