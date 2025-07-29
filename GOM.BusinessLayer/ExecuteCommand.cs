using LoginYap4.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginYap4.BusinessLayer
{
    public class ExecuteCommand
    {
        DatabaseContext db;

        public ExecuteCommand()
        {
            db = new DatabaseContext();
        }
        public List<usercount> UserCount()
        {
            return db.Database.SqlQuery<usercount>("select sonaovski.SongCount() as SarkiSayisi  ").ToList();
        }

        public List<userbilgi> UserBilgi(int? id)
        {
            return db.Database.SqlQuery<userbilgi>(@"execute GetUsernameById "+id).ToList();
        }


    }
    public class usercount
    {
        public int SarkiSayisi { get; set; }
    }
    public class userbilgi
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
    }
}
