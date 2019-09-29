using System.ComponentModel.DataAnnotations;

namespace HomeBrewJournal.Data
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public string Unit { get; set; }
        public double Amount { get; set; }
    }
}