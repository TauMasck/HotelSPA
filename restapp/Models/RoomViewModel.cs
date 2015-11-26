using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApp.Models
{
    public class RoomViewModel
    {
        public Guid Id { get; set; }
        public int HowManyPerson { get; set; }
        public double Size { get; set; }
        public double Price { get; set; }
        public bool Available { get; set; }
    }
}