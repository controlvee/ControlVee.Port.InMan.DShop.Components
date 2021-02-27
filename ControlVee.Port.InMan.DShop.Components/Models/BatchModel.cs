using System;
using System.Collections.Generic;
using System.Text;

namespace ControlVee.Port.InMan.DShop.Components.Models
{
    public class BatchModel 
    {
        public string ID { get; set; }
        public string NameOf { get; set; }
        public DateTime Started { get; set; }
        public int Total { get; set; }
    }
}
