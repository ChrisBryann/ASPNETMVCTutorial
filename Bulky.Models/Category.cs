using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
    public class Category
    {
        [Key] // by default, if prop is Id or [Class Name]Id (CategoryId), then .NET auto assumes it is a primary key
        public int Id { get; set; }
        [Required] // Data annotations
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order must be between 1-100")]
        public int DisplayOrder { get; set; }

    }
}
