using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendorsWebService.Models
{
    public class Vendor
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
    }
}