using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeBrewJournal.Data
{
    public class Beer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<Batch> Batches { get; set; }

        public Beer()
        {
            Batches = new List<Batch>();
        }
    }
}