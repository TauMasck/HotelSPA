//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TreatmentsHistory
    {
        public System.Guid Id { get; set; }
        public System.Guid Client_id { get; set; }
        public System.Guid Treatment_id { get; set; }
        public int This_stay { get; set; }
        public int Is_done { get; set; }
    
        public virtual Clients Clients { get; set; }
        public virtual Treatments Treatments { get; set; }
    }
}
