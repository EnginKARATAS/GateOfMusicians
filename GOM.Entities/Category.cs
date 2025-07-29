using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginYap4.Entities
{
    [Table("Categories")]
    public class Category : MyEntityBase
    {
        [Required,StringLength(50)]
        public string Title { get; set; }

        [StringLength(150)]
        public string Description { get; set; }

        public virtual List<Song> Songs { get; set; }
        public Category()
        {
            Songs = new List<Song>();
        }
    }
}