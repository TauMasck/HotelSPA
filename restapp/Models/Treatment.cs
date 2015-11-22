using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApp.Models
{
    public class Treatment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Duration { get; set; }
        public string Decription { get; set; }
        public bool Active { get; set; }

        public virtual Client Client;
    }
}