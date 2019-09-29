using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeBrewJournal.Data
{
    public class Batch
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public double ExpectedOG { get; set; }
        public double ExpectedFG { get; set; }
        public double ExpectedAlcVol { get; set; }

        public double RealOG { get; set; }
        public double RealFG { get; set; }
        public double RealAlcVol { get; set; }

        public int Points { get; set; }
        public string PostMortem { get; set; }

        public IList<Ingredient> Ingredients { get; set; }
        public IList<LogItem> Log { get; set; }

        public Batch()
        {
            Ingredients = new List<Ingredient>();
            Log = new List<LogItem>();
        }
    }
}