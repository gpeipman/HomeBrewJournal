﻿using System;
using System.ComponentModel.DataAnnotations;

namespace HomeBrewJournal.Data
{
    public class LogItem
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}