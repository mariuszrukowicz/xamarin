using MyCookBook.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCookBook.Models
{
    public class Igredient : ISqlModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }        
        public double Quantity { get; set; }
        [Ignore]
        public string FullProperty => $"- {Name}: {Quantity} {Unit}";

        

    }
}
