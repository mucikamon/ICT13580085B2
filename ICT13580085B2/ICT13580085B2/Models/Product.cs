using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ICT13580085B2.Models
{
    public    class Product
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        [MaxLength(200)]
        public string Name { get; set; }

        public string Description { get; set; }
        public string Category { get; set; }
        [NotNull]
        [MaxLength(100)]
        public decimal Productprice { get; set; }
        public decimal Sellprice { get; set; }
        public int Stock { get; set; }

    }
}
