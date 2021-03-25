using System.Collections.Generic;

namespace LoginYap4.Entities
{
    public class Chord 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HowToShowInFrets { get; set; }

        public virtual ICollection<Song> Song { get; set; }

        public Chord()
        {
            this.Song = new HashSet<Song>();
        }
    }
}