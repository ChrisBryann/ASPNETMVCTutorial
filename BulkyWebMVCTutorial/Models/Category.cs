using System.ComponentModel.DataAnnotations;

namespace BulkyWebMVCTutorial.Models
{
    public class Category
    {
        [Key] // by default, if prop is Id or [Class Name]Id, then .NET auto assumes it is a primary key
        public int Id { get; set; }
        [Required] // Data annotations
        public string Name { get; set; }
        public int DisplayOrder { get; set; }

    }
}
