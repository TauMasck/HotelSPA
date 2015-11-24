using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApp.Models
{
    public class TreatmentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Duration { get; set; }
        public string Decription { get; set; }
        public bool Active { get; set; }

        public virtual ClientViewModel Client;
    }
}