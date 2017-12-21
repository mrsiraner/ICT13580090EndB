using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ICT13580090EndB.Model
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        [MaxLength(200)]
        public string Catagory { get; set; }
        public string Brand { get; set; }
        public string Gen { get; set; }
        public int Year { get; set; }
        public int Mile { get; set; }
        public string Color { get; set; }
        public Boolean Dle { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Country { get; set; }
        public int Phone { get; set; }


    }
}
