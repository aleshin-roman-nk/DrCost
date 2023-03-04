using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrCost.Models.Stuff
{
    public class StuffItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string currencyName { get; set; }
        public decimal currencyPriceInRub { get; set; }
        public decimal price { get; set; }
        public decimal count { get; set; }
        public DateTime Date { get; set; }
        public int budgetId { get; set; }
        public string? budgetDNA { get; set; }
        public int stuffTypeId { get; set; }
        public int? KindOfTagId { get; set; }
        public decimal TotalInRub => currencyPriceInRub * price * count;
        public decimal Total => price * count;
    }
}

/*
CREATE TABLE StuffItems (
    Id                   INTEGER PRIMARY KEY AUTOINCREMENT
                            UNIQUE
                            NOT NULL,
    Name                 VARCHAR NOT NULL,
    Description          VARCHAR NOT NULL,
    currencyName         VARCHAR NOT NULL,
    currencyPriceInRub   DECIMAL,
    price                DECIMAL,
	count                DECIMAL,
	Date                 DATETIME,
	budgetId             INTEGER,
	budgetDNA            VARCHAR,
	stuffTypeId          INTEGER
);

*/