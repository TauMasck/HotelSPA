using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApp.Models
{
    public class ClientHistoryViewModel
    {
        //ClientId chyba jest tutaj niepotrzebne
        public Guid ClientId { get; set; }
        public TreatmentViewModel Treatment { get; set; } 
        public bool ThisStay { get; set; }
        public bool IsDone { get; set; }
    }
}