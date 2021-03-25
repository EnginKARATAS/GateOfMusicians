using LoginYap4.BusinessLayer.Abstract;
using LoginYap4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginYap4.BusinessLayer
{
    public class CategoryManager : ManagerBase<Category>
    {
        public override int Delete(Category category)
        {
            SongManager noteManager = new SongManager();
            LikedManager likedManager = new LikedManager();
            CommentManager commentManager = new CommentManager();

            // Kategori ile ilişkili notların silinmesi gerekiyor.
            foreach (Song note in category.Songs.ToList())
            {

                // Song ile ilişikili like'ların silinmesi.
                foreach (Liked like in note.Likes.ToList())
                {
                    likedManager.Delete(like);
                }

                // Song ile ilişkili comment'lerin silinmesi
                foreach (Comment comment in note.Comments.ToList())
                {
                    commentManager.Delete(comment);
                }

                noteManager.Delete(note);
            }

            return base.Delete(category);
        }
    }
}
