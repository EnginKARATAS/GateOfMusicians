using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoginYap4.Entities
{
    [Table("SiteUsers")]
    public class SiteUser : MyEntityBase
    {
        [DisplayName("Name"),
           StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Name { get; set; }

        [DisplayName("Surname"),
           StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Surname { get; set; }

        [DisplayName("Username"),
           Required(ErrorMessage = "{0} alanı gereklidir."),
           StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Username { get; set; }

        [DisplayName("E-Mail"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(70, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Email { get; set; }

        [DisplayName("Password"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Password { get; set; }


        [DisplayName("Is Active")]
        public bool IsActive { get; set; }


        [DisplayName("Is Admin")]
        public bool IsAdmin { get; set; }
        [DisplayName("Scor")]
        public int UserScore { get; set; } //450 point
        [DisplayName("Artist")]
        public bool isArtist { get; set; }
        [StringLength(30), ScaffoldColumn(false)]
        public string ProfileImageFilename { get; set; }
        [Required, ScaffoldColumn(false)]
        public Guid ActivateGuid { get; set; }

        public virtual List<Liked> Likes{ get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Song> Songs { get; set; }

    }
}
