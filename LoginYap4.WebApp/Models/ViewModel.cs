using LoginYap4.BusinessLayer;
using System.Collections.Generic;

namespace LoginYap4.WebApp.Models
{
    public class ViewModel
    {
        public List<usercount> sqlFonksyonKisiSayisi { get; set; }

        public List<userbilgi> procedureGetUserInfo { get; set; }
    }
}