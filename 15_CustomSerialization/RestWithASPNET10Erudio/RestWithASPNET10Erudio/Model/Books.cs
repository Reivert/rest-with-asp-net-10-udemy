using RestWithASPNET10Erudio.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNET10Erudio.Model
{
    [Table("books")]
    public class Books : BaseEntity
    {
        [Required]
        [Column("title", TypeName = "varchar(MAX)")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Column("author", TypeName = "varchar(MAX)")]
        public string Author { get; set; } = string.Empty;

        [Required]
        [Column("price")]
        public decimal Price { get; set; }

        [Required]
        [Column("launch_date")]
        public DateTime LaunchDate { get; set; }
    }
}
