using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace it.Model
{
    public class Blogger
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3),MaxLength(20)]
        [DataType(DataType.Text)]
        [DisplayName("blogger_name")]
        public string Name { get; set; }
    }
}
