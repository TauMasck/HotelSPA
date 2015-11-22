using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApp.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberPerson { get; set; }
        public float Size { get; set; }
        public float Price { get; set; }
        public bool Available { get; set; }
    }
}