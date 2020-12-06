using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsMatch.Models
{
    public class OrdersVM
    {
        public string GoodsName { get; set; }

        public string PlaceOrder { get; set; }

        public int Nums { get; set; }

        public string CreateTime { get; set; }

        public int Status { get; set; }
    }
}
