using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoginYap4.Entities
{
    public class MyEntityBase//her tabloda kullanılan değerler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]//datetimelar zaten null geçilemez
        public DateTime CreatedOn { get; set; }
        [Required]//datetimelar zaten null geçilemez
        public DateTime ModifiedOn { get; set; }
        [Required, StringLength(30)]
        public string ModifiedUsername { get; set; }//sitedeki kullanıcımız

    }
}
