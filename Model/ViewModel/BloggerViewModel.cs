using System.ComponentModel.DataAnnotations;

namespace it.Model.ViewModel
{
    public class BloggerViewModel
    {
        [Required]
        [MinLength(3), MaxLength(20)]        
        public string name { get; set; }
    }
}
