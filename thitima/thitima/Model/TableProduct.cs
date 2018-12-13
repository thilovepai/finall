using System;
using System.Collections.Generic;

namespace thitima.Model
{
    public partial class TableProduct
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Price { get; set; }
        public int? UnitPerPrice { get; set; }
        public int? Qty { get; set; }
        public short? Status { get; set; }
    }
}
