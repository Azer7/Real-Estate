using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA.Model
{
    class ViewProp
    {
        public int Id { get; set; }
        public string Market { get; set; }
        public string Type { get; set; }
        public Nullable<int> Area { get; set; }
        public Nullable<int> Rooms { get; set; }
        public string District { get; set; }
        public string Settlement { get; set; }
        public string Adress { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Owner { get; set; }
        public Nullable<int> Status { get; set; }
    }
}
