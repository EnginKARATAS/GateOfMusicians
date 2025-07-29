using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginYap4.Entities
{
    public class Log
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50)]
        public string SongName { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public int ViewedNumber { get; set; }
        [StringLength(50)]
        public string Aciklama { get; set; }
    }
}
