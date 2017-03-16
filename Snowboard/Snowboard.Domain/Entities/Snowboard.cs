using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowboard.Domain.Entities
{
    public class Snowboard
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public byte[] Picture { get; set; }
        public int Number { get; set; }
    }
    //https://metanit.com/sharp/helpdeskmvc/2.1.php
}
