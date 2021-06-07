using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace productApp.Models
{
    public class Products
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }

        public override string ToString()
        {
            return this.Name + " / (" + Description + ") " + "/ ( le prix :" + Price + ")";
        }
    }
}
