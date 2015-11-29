using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApp.Models
{
    public class ClientViewModel
    {
        public Guid Id { get; set; }
        public string NameSurname { get; set; }
        public string IdNumber { get; set; }
        public string Company { get; set; }
        public Guid? RoomNumber { get; set; }
        public bool IsHere { get; set; }
        public bool Vegetarian { get; set; }
        public bool Questionnaire { get; set; }
        public bool Invoice { get; set; }

        //public virtual TreatmentViewModel Treatment;
    }
}