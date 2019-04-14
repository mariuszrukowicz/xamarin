using MyCookBook.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCookBook.Models
{
    public class Recipe : ISqlModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
        public string Image { get; set; }


    }
}
