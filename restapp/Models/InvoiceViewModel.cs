using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApp.Models
{
    public class InvoiceViewModel
    {
        public double Price { get; set; }
        public string ClientNameSurname { get; set; }
        public string Company { get; set; }
    }
}