using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApp.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int HowManyPerson { get; set; }
        public float Size { get; set; }
        public float Price { get; set; }
        public bool Available { get; set; }
    }
}