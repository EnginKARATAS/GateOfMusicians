using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoginYap4.Entities
{
    [Table("Likes")]
    public class Liked
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  //diğer özellikleri (created on vb ) istemediğimizden miras almadık


        public virtual Song Song{ get; set; }
        public virtual SiteUser LikedUser { get; set; }
    }
}
