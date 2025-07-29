using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace LoginYap4.Entities
{
    [Table("Songs")]
    public class Song : MyEntityBase //Songs == Notes
    {
        [Required, StringLength(150)]
        public string Name { get; set; }

       
        [Required, AllowHtml, StringLength(10000),DisplayName("Song")]
        public string Text { get; set; }

        [AllowHtml, StringLength(30000), DisplayName("Song 2")]
        public string Text2 { get; set; }


        [AllowHtml, StringLength(100), DisplayName("Salt Text For Clear Display")]

        public string TextSalt { get; set; }
        public string Writer { get; set; }

        [DisplayName("Likes")]
        public int LikeCount { get; set; }


        [Required, StringLength(100)]
        public string Artist { get; set; }
        public string CoveredArtist { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime PublishedCoverDateOnYouTube { get; set; }
        //eğitim

        [DisplayName("Is Draft")]
        public bool IsDraft { get; set; }

        public int CategoryId { get; set; } //kategori tablosu sorgusu çalıştırırken kategori idsini yazar ve 0 sıkıntı 
        public int ViewedNumber { get; set; }
        public int RateNumber { get; set; }


        public virtual SiteUser Owner { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Liked> Likes { get; set; }
        public string Picture { get; set; }

        public Song()
        {
            Comments = new List<Comment>();
            Likes = new List<Liked>();
        }

    }
}