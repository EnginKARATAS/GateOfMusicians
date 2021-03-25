using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginYap4.Entities
{
    [Table("Comments")]
    public class Comment : MyEntityBase
    {
        [Required, StringLength(300)]
        public string Text { get; set; }
        public virtual Song Song { get; set; }
        public virtual SiteUser Owner { get; set; }
    }
}