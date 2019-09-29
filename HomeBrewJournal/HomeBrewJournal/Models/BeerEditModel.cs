using System.ComponentModel.DataAnnotations;

namespace HomeBrewJournal.Models
{
    public class BeerEditModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}