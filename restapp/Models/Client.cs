using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApp.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public int IdNumber { get; set; }
        public string Company { get; set; }
        public int RoomNumber { get; set; }
        public bool IsHere { get; set; }
        public bool Vegetarian { get; set; }
        public bool Questionnaire { get; set; }
        public bool Invoice { get; set; }

        public virtual Treatment Treatment;
    }
}